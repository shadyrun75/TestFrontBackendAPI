using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.Models.Data
{
    public class Kaktus : IKaktus
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
