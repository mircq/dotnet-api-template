namespace Persistence.Settings;

public class SQLDatabaseSettings
{
    //public string Host { get; }
    //public int Port { get; }

    //public string User { get; }

    //public string Password { get; }

    //public string Name { get; }


    //public SQLDatabaseSettings(IConfiguration configuration)
    //{
    //    Console.WriteLine(" bbbbbbbbbbbbbbbbbb");

    //    Host = configuration["SQL_DATABASE_HOST"] ?? throw new ArgumentNullException("Database connection string not found.");
    //    Port = Int32.Parse(s: configuration["SQL_DATABASE_PORT"]);
    //    User = configuration["SQL_DATABASE_USER"] ?? throw new ArgumentNullException("Database connection string not found.");
    //    Password = configuration["SQL_DATABASE_PASSWORD"] ?? throw new ArgumentNullException("Database connection string not found.");
    //}

    public string Host { get; set; }
    public int Port { get; set; }
    public string Name { get; set; }
    public string User { get; set; }
    public string Password { get; set; }

}
