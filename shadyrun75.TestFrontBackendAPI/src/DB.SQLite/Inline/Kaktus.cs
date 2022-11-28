using Microsoft.Data.Sqlite;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Inline
{
    public class Kaktus : BaseContext, Interfaces.DB.IKaktus
    {
        public Kaktus(GetConnection connection) : base(connection) { }

        public IEnumerable<Interfaces.Models.Data.IKaktus> Get()
        {
            List<Interfaces.Models.Data.IKaktus> result = new();
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"SELECT Id, Title, Category, ImageUrl, Price, Description FROM Kaktus ";
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        Models.Data.Kaktus value = new();
                        value.Id = reader.GetInt64(0);
                        value.Title = reader.GetString(1);
                        value.Category = reader.GetString(2);
                        value.ImageUrl = reader.GetString(3);
                        value.Price = reader.GetDouble(4);
                        value.Description = reader.IsDBNull(5) ? null : reader.GetString(5);
                        result.Add(value);
                    }
            }
            return result;
        }

        public void Add(Interfaces.Models.Data.IKaktus value)
        {
            Insert(new Interfaces.Models.Data.IKaktus[] { value });
        }

        public void Add(Interfaces.Models.Data.IKaktus[] value)
        {
            Insert(value);
        }

        public void Edit(Interfaces.Models.Data.IKaktus value)
        {
            Update(new Interfaces.Models.Data.IKaktus[] { value });            
        }

        public void Edit(Interfaces.Models.Data.IKaktus[] value)
        {
            Update(value);
        }

        public void Remove(long id)
        {
            Delete(new long[] { id });
        }
                
        public void Remove(long[] id)
        {
            Delete(id);
        }

        void Insert(Interfaces.Models.Data.IKaktus[] value)
        {
            int index = -1;
            foreach (var item in value)
            {
                index++;
                if (!item.Check(out var message))
                    throw new Exception($"[{index}] Failed! {message}");
            }
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"INSERT INTO Kaktus (Title, Category, ImageUrl, Price, Description) " +
                    $"VALUES (@title, @category, @imageUrl, @price, @description)";
                foreach (var item in value)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("title", item.Title);
                    command.Parameters.AddWithValue("category", item.Category);
                    command.Parameters.AddWithValue("imageUrl", item.ImageUrl);
                    command.Parameters.AddWithValue("price", item.Price);
                    if (item.Description?.Length > 0)
                        command.Parameters.AddWithValue("description", item.Description);
                    else
                        command.Parameters.AddWithValue("description", DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        void Update(Interfaces.Models.Data.IKaktus[] value)
        {
            int index = -1;
            foreach (var item in value)
            {
                index++;
                if (!item.Check(out var message))
                    throw new Exception($"[{index}] Failed! {message}");
                if (item.Id <= 0)
                    throw new Exception($"[{index}] For update object field Id must be more than 0.");
            }
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"UPDATE Kaktus SET Title = @title, Category = @category, ImageUrl = @imageUrl, Price = @price, " +
                    $"Description = @description " +
                    $"WHERE Id = @id";
                foreach (var item in value)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("title", item.Title);
                    command.Parameters.AddWithValue("category", item.Category);
                    command.Parameters.AddWithValue("imageUrl", item.ImageUrl);
                    command.Parameters.AddWithValue("price", item.Price);
                    if (item.Description?.Length > 0)
                        command.Parameters.AddWithValue("description", item.Description);
                    else
                        command.Parameters.AddWithValue("description", DBNull.Value);
                    command.Parameters.AddWithValue("id", item.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        void Delete(long[] value)
        {
            if (value.Count(x => x < 0) > 0)
                throw new Exception("For delete object field Id must be more than 0.");

            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"DELETE FROM Kaktus WHERE Id = @id";
                foreach (var item in value)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("id", item);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
