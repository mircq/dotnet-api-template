namespace Infrastructure.Settings.Storage;

public class StorageSettings
{
    public string Host { get; set; }

    public int Port { get; set; }

    public string SecretKey { get; set; }

    public string AccessKey { get; set; }

    public string BucketName { get; set; }
}
