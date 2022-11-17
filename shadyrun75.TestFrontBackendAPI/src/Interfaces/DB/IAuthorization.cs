using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization;

namespace shadyrun75.TestFrontBackendAPI.Interfaces.DB
{
    public interface IAuthorization
    {
        /// <summary>
        /// Getting list of users
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="isActive">If null getting all users, if true getting active users, if false getting not active users</param>
        /// <returns></returns>
        IEnumerable<IUser> GetUsers(int offset, int limit, ref int count, bool? isActive = null);
        IUserMax GetUserById(Int64 id);
        IUserMax GetUserByLogin(string login);
        void InsertUser(IUserMax user);
        void UpdateUser(IUserMax user);
        void DeleteUser(string id);
    }
}