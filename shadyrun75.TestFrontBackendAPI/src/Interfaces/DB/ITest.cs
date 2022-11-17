using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.Interfaces.DB
{
    public interface ITest
    {
        public IEnumerable<IKaktus> Get();
    }
}
