using System.Globalization;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;
using Domain.Errors;
using Domain.Result;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Infrastructure.Clients;

public class MinIOClient: IMinIOClient
{

    private IMinioClient minioClient;
    private readonly ILogger<MinIOClient> _logger;

    public MinIOClient(ILogger<MinIOClient> logger)
    {
        _logger = logger;

        minioClient = new MinioClient()
            .WithEndpoint(endpoint: "localhost:9000")
            .WithCredentials(accessKey: "dG9BvRBdhrGoSN2S5CaV", secretKey: "saMrqqd5N5izgQFQ5qT2jOB4DG4udvG1gJrcQ9y7")
            .WithSSL()
            .Build();
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
                    .WithBucket(bucket: "prova")
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
            return GenericErrors.NotFoundError(entityType: "bucket", id: "prova");
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


    #endregion
}
