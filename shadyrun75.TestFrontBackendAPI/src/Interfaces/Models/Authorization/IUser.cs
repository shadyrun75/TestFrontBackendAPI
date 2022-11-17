namespace shadyrun75.TestFrontBackendAPI.Interfaces.Models.Authorization
{
    public interface IUser
    {
        public Int64 Id { get; set; }
        public string Login { get; set; }
        public string Display { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
