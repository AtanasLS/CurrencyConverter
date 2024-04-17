namespace infrastructure;

public class Utilities
{
    public static readonly string PGPASS = new(Environment.GetEnvironmentVariable("PGPASS"));

    public static readonly string connectionString = 
                                "Server=localhost:5432;Database=CurrencyConverted;User Id=appuser;Password=secret;";

}
