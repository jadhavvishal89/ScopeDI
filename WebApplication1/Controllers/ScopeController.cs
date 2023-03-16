using DotNetDIScope.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Implementation;
using WebApplication1.Services;

namespace DotNetDIScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScopeController : ControllerBase
    {
        private readonly ILogger<ScopeController> _logger;
        private readonly IScopedService _ScopedService1;
        private readonly IScopedService _ScopedService2;
        private readonly ItransientServices _transientServices1;
        private readonly ItransientServices _transientServices2;
        private readonly ISingltonService _singltonService1;
        private readonly ISingltonService _singltonService2;
        public ScopeController(ILogger<ScopeController> logger,
            IScopedService  scopedService1,
            IScopedService scopedService2,
            ItransientServices transientServices1,
            ItransientServices transientServices2,
            ISingltonService singltonService1,
            ISingltonService singltonService2)
            
        {
            _logger = logger;
            _ScopedService1 = scopedService1;
            _ScopedService2 = scopedService2;
            _transientServices1 = transientServices1;
            _transientServices2 = transientServices2;
            _singltonService1 = singltonService1;
            _singltonService2 = singltonService2;
        }

        [HttpGet(Name = "GetScopeDI")]
        public string Get()
        {
            _logger.LogInformation("Calling Get");
            
            string FirstCall= String.Format("Scoped = {0}\nTrasient = {1}\nSingleton = {2}\n\n\n",
                _ScopedService1.GetGuid(),
                _transientServices1.GetGuid(),
                _singltonService1.GetGuid());

            string SecondCall= String.Format("Scoped = {0}\nTrasient = {1}\nSingleton = {2}",
                _ScopedService2.GetGuid(),
                _transientServices2.GetGuid(),
                _singltonService2.GetGuid());
            return string.Concat(FirstCall, SecondCall);
        }
        [HttpPost(Name = "GetSecondScopeDI")]
        //[HttpPost("{id:int}")]
        public string post(int id = 1)
        {
            string FirstCall = String.Format("Scoped = {0}\nTrasient = {1}\nSingleton = {2}\n\n\n",
                _ScopedService1.GetGuid(),
                _transientServices1.GetGuid(),
                _singltonService1.GetGuid());

            string SecondCall = String.Format("Scoped = {0}\nTrasient = {1}\nSingleton = {2}",
                _ScopedService2.GetGuid(),
                _transientServices2.GetGuid(),
                _singltonService2.GetGuid());
            return string.Concat(FirstCall, SecondCall);
        }
    }
}
