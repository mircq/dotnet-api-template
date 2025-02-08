using Domain.Errors;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using MimeDetective;
using Application.Clients.Storage;
using Infrastructure.Settings.Storage;
using Minio.DataModel;
using Minio.DataModel.Response;
using System.Collections.Immutable;
using MimeDetective.Engine;


namespace Infrastructure.Clients;

public class StorageClient: IStorageClient
{

    private readonly IMinioClient _minioClient;
    private readonly string bucketName;
    private readonly ILogger<StorageClient> _logger;

    public StorageClient([FromServices] StorageSettings settings, ILogger<StorageClient> logger)
    {
        _minioClient = new MinioClient()
            .WithEndpoint(endpoint: $"{settings.Host}:{settings.Port}")
            .WithCredentials(accessKey: settings.AccessKey, secretKey: settings.SecretKey)
            //.WithSSL()
            .Build();

        bucketName = settings.BucketName;

        IContentInspector Inspector = new ContentInspectorBuilder()
        {
            Definitions = MimeDetective.Definitions.DefaultDefinitions.All()
        }.Build();

        _logger = logger;

    }

    #region Get
    public async Task<Result<FileEntity>> GetAsync(string path)
    {

        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: path={path}");

        if (!await BucketExists())
        {
            return GenericErrors.NotFoundError(entityType: "bucket", id: bucketName);
        }

        try
        {

            StatObjectArgs statObjectArgs = new StatObjectArgs()
               .WithBucket(bucket: bucketName)
               .WithObject(obj: path);
            ObjectStat objectStat = await _minioClient.StatObjectAsync(args: statObjectArgs);

            MemoryStream memoryStream = new();
            GetObjectArgs getArgs = new GetObjectArgs()
                    .WithBucket(bucket: bucketName)
                    .WithObject(obj: path)
                    .WithCallbackStream(async stream =>
                    {
                        await stream.CopyToAsync(destination: memoryStream);
                    });
            
            ObjectStat getObjectStat = await _minioClient.GetObjectAsync(args: getArgs);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new FileEntity{ 
                Stream = memoryStream, 
                ContentType = getObjectStat.ContentType, 
                FileName = objectStat.ObjectName.Split("/").Last()
            };
        }
        catch (BucketNotFoundException)
        {
            return GenericErrors.NotFoundError(entityType: "bucket", id: bucketName);
        }
        catch (ObjectNotFoundException)
        {
            return GenericErrors.NotFoundError(entityType: "file", id: path);
        }
        catch (Exception e)
        {
            return GenericErrors.GenericError(message: e.Message);
        }
    }
    #endregion

    #region Post
    public async Task<Result<string>> PostAsync(string path, IFormFile file)
    {


        if (!await BucketExists())
        {
            return GenericErrors.NotFoundError(entityType: "bucket", id: bucketName);
        }

        using (var stream = file.OpenReadStream())
        {
            IContentInspector Inspector = new ContentInspectorBuilder()
            {
                Definitions = MimeDetective.Definitions.DefaultDefinitions.All()
            }.Build();

            ImmutableArray<DefinitionMatch> results = Inspector.Inspect(content: stream);
            string contentType = results.ByMimeType().Count() == 0 ? "application/octet-stream" : results.ByMimeType().First()?.MimeType;
            stream.Position = 0;

            PutObjectArgs putObjectArgs = new PutObjectArgs()
            .WithBucket(bucket: bucketName)
            .WithObject(obj: path)
            .WithStreamData(data: stream)
            .WithObjectSize(size: -1)
            .WithContentType(type: contentType);

            PutObjectResponse putObjectResponse = await _minioClient.PutObjectAsync(args: putObjectArgs);

        }
        
        return path;
    }

    #endregion

    private async Task<bool> BucketExists()
    {
        BucketExistsArgs bucketArgs = new BucketExistsArgs()
            .WithBucket(bucket: bucketName);

        bool bucketExists = await _minioClient.BucketExistsAsync(
                args: bucketArgs
        ).ConfigureAwait(false);

        return bucketExists;
    }
}
