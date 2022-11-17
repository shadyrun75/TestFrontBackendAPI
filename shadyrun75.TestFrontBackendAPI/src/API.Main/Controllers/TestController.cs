using Microsoft.AspNetCore.Mvc;
using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.Interfaces.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.API.Main.Controllers
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        IWorker _worker;
        public TestController(IWorker worker)
        {
            _worker = worker;
        }

        [HttpGet]
        public IEnumerable<IKaktus> Get()
        {
            return _worker.Test.Get();
        }
    }
}
