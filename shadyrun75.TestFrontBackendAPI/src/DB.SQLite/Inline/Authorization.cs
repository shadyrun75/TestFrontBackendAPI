using Microsoft.Data.Sqlite;
using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization;
using shadyrun75.TestFrontBackendAPI.Models.Authorization;

namespace shadyrun75.TestFrontBackendAPI.DB.SQLite.Inline
{
    public class Authorization : BaseContext, IAuthorization
    {
        public Authorization(GetConnection connection) : base(connection)
        {
        }

        public IEnumerable<IUser> GetUsers(int offset, int limit, ref int count, bool? isActive = null)
        {
            List<IUser> result = new();
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = "SELECT COUNT(Id) FROM Users ";
                if (isActive != null)
                    command.CommandText += isActive == true ? "WHERE IsActive = 1 " : "WHERE IsActive = 0 ";
                count = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = $"SELECT Id, Login, Display, IsActive FROM Users ";
                if (isActive != null)
                    command.CommandText += isActive == true ? "WHERE IsActive = 1 " : "WHERE IsActive = 0 ";
                if (limit > 0)
                    command.CommandText += $" LIMIT {limit} OFFSET {limit * offset}";
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        User user = new();
                        user.Id = reader.GetInt64(0);
                        user.Login = reader.GetString(1);
                        user.Display = reader.GetString(2);
                        user.IsActive = reader.GetBoolean(3);
                        result.Add(user);
                    }
            }
            return result;
        }

        public IUserMax GetUserById(Int64 id)
        {
            UserMax user = new();
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"SELECT Id, Login, Display, IsActive FROM Users WHERE Id = @id";
                command.Parameters.AddWithValue("Id", id);
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt64(0);
                        user.Login = reader.GetString(1);
                        user.Display = reader.GetString(2);
                        user.IsActive = reader.GetBoolean(3);
                    }
                command.CommandText = "SELECT Roots.Code FROM UsersRoots JOIN Roots ON Roots.Id = UsersRoots.RootId WHERE UsersRoots.UserId = @id";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Id", id);
                user.Roots = new();
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        user.Roots.Add(reader.GetString(0));
                    }
            }
            return user;
        }

        public IUserMax GetUserByLogin(string login)
        {
            UserMax user = new();
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"SELECT Id, Login, Display, IsActive FROM Users WHERE Login = @login";
                command.Parameters.AddWithValue("Login", login);
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt64(0);
                        user.Login = reader.GetString(1);
                        user.Display = reader.GetString(2);
                        user.IsActive = reader.GetBoolean(3);
                    }
                command.CommandText = "SELECT Roots.Code FROM UsersRoots JOIN Roots ON Roots.Id = UsersRoots.RootId WHERE UsersRoots.UserId = @id";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Id", user.Id);
                user.Roots = new();
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        user.Roots.Add(reader.GetString(0));
                    }
            }
            return user;
        }

        public void InsertUser(IUserMax user)
        {
            using (var connection = Connection())
            using (var command = new SqliteCommand("", connection))
            {
                command.CommandText = $"INSERT INTO Users (Login, Display, IsActive, PasswordHash) VALUES (@login, @display, @isActive, @passwordHash)";
                command.Parameters.AddWithValue("login", user.Login);
                command.Parameters.AddWithValue("display", user.Display);
                command.Parameters.AddWithValue("isActive", user.IsActive);
                command.Parameters.AddWithValue("passwordHash", user.Password);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(IUserMax user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

    }
}
