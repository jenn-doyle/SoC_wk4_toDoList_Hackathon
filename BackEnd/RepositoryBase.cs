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
            Host = "ec2-54-155-99-116.eu-west-1.compute.amazonaws.com", // e.g. ec2-1-2-3-4@eu-west-1.compute.amazonaws.com
            Database = "d1ss0ltfdcsqh8", // e.g. ksdjfhsafnfas
            Username = "sdzqrbjpqogmhb", // e.g. lksfhdslkfsdflk
            Password = "6182d000590ba763943e4d726aec70993b5c4e9560a7ac0d2eed16a1b525ad87",// e.g KJZDldfj34567dslkfjsdlfksdjflsdkfjsdlkfjsdl34567fkjdsgDRTYUI
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