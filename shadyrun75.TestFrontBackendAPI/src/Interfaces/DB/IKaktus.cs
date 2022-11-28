using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.Interfaces.DB
{
    public interface IKaktus
    {
        public IEnumerable<Models.Data.IKaktus> Get();
        public void Add(Models.Data.IKaktus value);
        public void Add(Models.Data.IKaktus[] value);
        public void Edit(Models.Data.IKaktus value);
        public void Edit(Models.Data.IKaktus[] value);
        public void Remove(Int64 id);
        public void Remove(Int64[] id);
    }
}
