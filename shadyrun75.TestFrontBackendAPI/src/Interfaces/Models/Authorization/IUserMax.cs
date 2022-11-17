namespace shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization
{
    public interface IUserMax : IUser
    {
        public List<string> Roots { get; set; }
    }
}
