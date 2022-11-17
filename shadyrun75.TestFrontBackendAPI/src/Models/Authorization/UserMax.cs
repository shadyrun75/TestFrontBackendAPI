using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization;

namespace shadyrun75.TestFrontBackendAPI.Models.Authorization
{
    public class UserMax : User, IUserMax
    {
        public List<string> Roots { get; set; }
    }
}