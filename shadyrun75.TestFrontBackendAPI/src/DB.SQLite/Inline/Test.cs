using Microsoft.Data.Sqlite;
using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data;
using shadyrun75.TestFrontBackendAPI.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Inline
{
    public class Test : BaseContext, ITest
    {
        public Test(GetConnection connection) : base(connection) { }

        public IEnumerable<IKaktus> Get()
        {
            List<IKaktus> result = new();
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"SELECT Id, Title, Category, ImageUrl, Price FROM Test ";
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        Kaktus value = new();
                        value.Id = reader.GetInt64(0);
                        value.Title = reader.GetString(1);
                        value.Category = reader.GetString(2);
                        value.ImageUrl = reader.GetString(3);
                        value.Price = reader.GetDouble(4);
                        result.Add(value);
                    }
            }
            return result;
        }
    }
}
