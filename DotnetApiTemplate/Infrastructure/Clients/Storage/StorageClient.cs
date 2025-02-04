using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Net.Mime;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;
using Domain.Errors;
using Domain.Result;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using MimeDetective;
using MimeDetective.Engine;
using System.Collections.Immutable;
using Application.Clients.Storage;

namespace Infrastructure.Clients;

public class StorageClient: IStorageClient
{

    private IMinioClient minioClient;
    private string bucketName;
    private readonly ILogger<StorageClient> _logger;

    public StorageClient(MinIOSettings settings, ILogger<StorageClient> logger)
    {
        minioClient = new MinioClient()
            .WithEndpoint(endpoint: $"{settings.Host}:{settings.Port}")
            .WithCredentials(accessKey: settings.AccessKey, secretKey: settings.SecretKey)
            .WithSSL()
            .Build();

        bucketName = settings.BucketName;

        IContentInspector Inspector = new ContentInspectorBuilder()
        {
            Definitions = MimeDetective.Definitions.DefaultDefinitions.All()
        }.Build();

        _logger = logger;

    }

    #region Get
    public async Task<Result<Stream>> GetAsync(string path)
    {

        _logger.LogInformation(message: "Start");

        try
        {

            // Check whether the object exists using StatObjectAsync(). If the object is not found,
            // StatObjectAsync() will throw an exception.
            //StatObjectArgs statObjectArgs = new StatObjectArgs()
            //    .WithBucket(bucket: "prova")
            //    .WithObject(obj: path);
            //_ = await minioClient.StatObjectAsync(args: statObjectArgs);


            ////var getObjectArgs = new GetObjectArgs()
            ////    .WithBucket("prova")
            ////    .WithObject(path)
            ////    .WithCallbackStream(async (stream, cancellationToken) =>
            ////    {
            ////        var fileStream = File.Create("aaaaaaa");
            ////        await stream.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
            ////        await fileStream.DisposeAsync().ConfigureAwait(false);
            ////        var writtenInfo = new FileInfo("aaaaaaa");
            ////        var file_read_size = writtenInfo.Length;
            ////        // Uncomment to print the file on output console
            ////        // stream.CopyTo(Console.OpenStandardOutput());
            ////        Console.WriteLine(
            ////            $"Successfully downloaded object with requested offset and length {writtenInfo.Length} into file");
            ////        stream.Dispose();
            ////    });
            ////_ = await minioClient.GetObjectAsync(getObjectArgs).ConfigureAwait(false);

            MemoryStream memoryStream = new MemoryStream();
            GetObjectArgs getArgs = new GetObjectArgs()
                    .WithBucket(bucket: bucketName)
                    .WithObject(obj: path)
                    .WithCallbackStream(async stream =>
                    {
                        await stream.CopyToAsync(destination: memoryStream);
                    });
            // Retrieve the object from MinIO and write it to the memory stream
            _ = await minioClient.GetObjectAsync(args: getArgs);

            memoryStream.Seek(0, SeekOrigin.Begin); // Reset position
            return memoryStream;
        }
        catch (BucketNotFoundException e)
        {
            return GenericErrors.NotFoundError(entityType: "bucket", id: bucketName);
        }
        catch (ObjectNotFoundException e)
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
    public async Task<Result<string>> PostAsync(string path, Stream stream)
    {

        BucketExistsArgs bucketArgs = new BucketExistsArgs().WithBucket(bucket: bucketName);

        bool bucketExists = await minioClient.BucketExistsAsync(
                args: bucketArgs
        );

        if (!bucketExists)
        {
            return GenericErrors.NotFoundError(entityType: "bucket", id: bucketName);
        }

        IContentInspector Inspector = new ContentInspectorBuilder()
        {
            Definitions = MimeDetective.Definitions.DefaultDefinitions.All()
        }.Build();

        ImmutableArray<DefinitionMatch> results = Inspector.Inspect(content: stream);
        ImmutableArray<MimeTypeMatch> resultsByMimeType = results.ByMimeType();
        string contentType = resultsByMimeType.First()?.MimeType ?? "application/octet-stream";

        PutObjectArgs putObjectArgs = new PutObjectArgs()
                                            .WithBucket(bucket: bucketName)
                                            .WithObject(obj: path)
                                            .WithStreamData(data: stream)
                                            .WithObjectSize(size: stream.Length)
                                            .WithContentType(type: contentType);

        await minioClient.PutObjectAsync(args: putObjectArgs);

        return path;
    }

    #endregion
}
