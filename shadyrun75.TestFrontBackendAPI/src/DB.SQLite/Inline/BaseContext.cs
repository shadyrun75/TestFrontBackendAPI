using Microsoft.Data.Sqlite;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Inline
{
    public class BaseContext
    {
        public delegate SqliteConnection GetConnection();
        public GetConnection Connection;
        
        public BaseContext(GetConnection connection)
        {
            Connection = connection;
        }
    }
}
