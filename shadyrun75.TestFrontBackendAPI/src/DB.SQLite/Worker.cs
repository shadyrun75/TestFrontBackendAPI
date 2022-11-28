using Microsoft.Data.Sqlite;
using shadyrun75.TestFrontBackendAPI.DB.SQLite.Inline;
using shadyrun75.TestFrontBackendAPI.Interfaces.DB;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite
{
    public class Worker : IWorker
    {
        readonly string _connectionString;
        public Worker(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};Cache=Shared";
            Authorization = new Authorization(GetConnection);
            Kaktus = new Kaktus(GetConnection);
        }

        SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public IAuthorization Authorization { get; }

        public IKaktus Kaktus { get; }
    }
}
