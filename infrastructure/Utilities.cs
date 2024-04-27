namespace infrastructure;

public class Utilities
{
    public static readonly string PGPASS = new(Environment.GetEnvironmentVariable("PGPASS"));

    public static readonly string devConnectionString = "Server=localhost:5432;Database=CurrencyConverted;User Id=appuser;Password=secret;";
    public static readonly string connectionString = 
                                "Server=app-database:5432;Database=CurrencyConverted;User Id=appuser;Password=secret;";
}
