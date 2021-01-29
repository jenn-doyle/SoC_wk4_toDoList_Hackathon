using System.Data;
using Npgsql;


public class BaseRepository
{
    // Generate new connection based on connection string
    private NpgsqlConnection SqlConnection()
    {
        // This builds a connection string from our separate credentials
        // TODO: add your connection settings
        var stringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = "ec2-99-81-238-134.eu-west-1.compute.amazonaws.com", // e.g. ec2-1-2-3-4@eu-west-1.compute.amazonaws.com
            Database = "ded4bdlpifphol", // e.g. ksdjfhsafnfas
            Username = "syotqorcuaxgfr", // e.g. lksfhdslkfsdflk
            Password = "3ea6c399b6a794be1b653659e2470d9ead6155381a6f3142fe133cdc880445ef",// e.g KJZDldfj34567dslkfjsdlfksdjflsdkfjsdlkfjsdl34567fkjdsgDRTYUI
            Port = 5432, // e.g 5432
            SslMode = Npgsql.SslMode.Require, // Heroku Specific Setting
            TrustServerCertificate = true // Heroku Specific Setting
        };

        return new NpgsqlConnection(stringBuilder.ConnectionString);
    }

    // Open new connection and return it for use
    public IDbConnection CreateConnection()
    {
        var connection = SqlConnection();
        connection.Open();
        return connection;
    }

}