namespace Persistence.Settings;

public class NoSQLDatabaseSettings
{
    public string NoSQLDatabaseHost { get; }
    public int NoSQLDatabasePort { get; }

    public string NoSQLDatabaseUser { get; }

    public string NoSQLDatabasePassword { get; }

    public NoSQLDatabaseSettings(IConfiguration configuration)
    {


        NoSQLDatabaseHost = configuration["NO_SQL_DATABASE_HOST"] ?? throw new ArgumentNullException("Database connection string not found.");
        // TODO manage missing case
        NoSQLDatabasePort = Int32.Parse(configuration["NO_SQL_DATABASE_PORT"]);
        NoSQLDatabaseUser = configuration["NO_SQL_DATABASE_USER"] ?? throw new ArgumentNullException("Database connection string not found.");
        NoSQLDatabasePassword = configuration["NO_SQL_DATABASE_PASSWORD"] ?? throw new ArgumentNullException("Database connection string not found.");
    }
}
