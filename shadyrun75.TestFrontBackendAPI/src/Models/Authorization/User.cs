using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization;

namespace shadyrun75.TestFrontBackendAPI.Models.Authorization
{
    public class User : IUser
    {
        public Int64 Id { get; set; }
        public string Login { get; set; }
        public string Display { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}