using shadyrun75.TestFrontBackendAPI.Models.Exceptions;

namespace shadyrun75.TestFrontBackendAPI.Models.API
{
    public class Response
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }

        public Response(bool success = true) 
        { 
            Success = success;
        } 

        public Response(bool success, Error error)
        {
            Success = success;
            Errors = new List<Error>() { error };
        }

        public Response(bool success, IEnumerable<Error> errors)
        {
            Success = success;
            var temp = new List<Error>();
            temp.AddRange(errors);
            Errors = temp;
        }
    }
    public class Response<T>
        where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}