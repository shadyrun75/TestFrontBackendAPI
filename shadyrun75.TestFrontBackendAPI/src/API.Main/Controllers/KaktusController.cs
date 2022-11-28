using Microsoft.AspNetCore.Mvc;
using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.Models.API;
using shadyrun75.TestFrontBackendAPI.Models.Data;

namespace shadyrun75.TestFrontBackendAPI.API.Main.Controllers
{
    [ApiController]
    [Route("Kaktus")]
    public class KaktusController : ControllerBase
    {
        IWorker _worker;
        public KaktusController(IWorker worker)
        {
            _worker = worker;
        }
        
        [HttpGet]
        public IEnumerable<Kaktus> Get()
        {
            return _worker.Kaktus.Get().Select(x => new Kaktus(x));
        }

        [HttpPost("Add")]
        public Response Add(Kaktus value) 
        { 
            try
            {
                _worker.Kaktus.Add(value);
                return new Response();
            }
            catch (Exception ex) 
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }

        [HttpPost("AddSeveral")]
        public Response Add(Kaktus[] value)
        {
            try
            {
                _worker.Kaktus.Add(value);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }

        [HttpPost("Update")]
        public Response Update(Kaktus value) 
        {
            try
            {
                _worker.Kaktus.Edit(value);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }

        [HttpPost("UpdateSeveral")]
        public Response UpdateSeveral(Kaktus[] values)
        {
            try
            {
                _worker.Kaktus.Edit(values);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }

        [HttpDelete("Delete")]
        public Response Delete(long id)
        {
            try
            {
                _worker.Kaktus.Remove(id);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteSeveral")]
        public Response Delete(long[] id)
        {
            try
            {
                _worker.Kaktus.Remove(id);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response(false, new Models.Exceptions.Error() { Type = Models.Exceptions.ErrorType.INTERNAL, Message = ex.Message });
            }
        }
    }
}