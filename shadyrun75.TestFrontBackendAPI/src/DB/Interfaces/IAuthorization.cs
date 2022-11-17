namespace shadyrun75.TestFrontBackendAPI.DB.Interfaces
{
    public interface IAuthorization
    {
        IEnumerable<User> GetUsers(int offset, int limit);
        void InsertUser(User user);
        void UpdateUser(User user);
        User GetUser(int id);
        User GetUser(string username);
        void DeleteUser(int id);
    }
}