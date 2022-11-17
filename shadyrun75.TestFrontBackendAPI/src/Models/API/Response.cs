using shadyrun75.TestFrontBackendAPI.Models.Exceptions;

namespace shadyrun75.TestFrontBackendAPI.Models.API
{
    public class Response<T>
        where T : class
    {
        public T Data { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
