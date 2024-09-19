using Microsoft.AspNetCore.Mvc;
using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Domain.Model;

namespace poc_dependency_injection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class demoController : ControllerBase
    {
        private readonly IScopedService _scopedService;
        private readonly IScopedService _scopedService2;

        private readonly ITransientService _transientService;
        private readonly ITransientService _transientService2;

        private readonly ISingletonService _singletonService;
        private readonly ISingletonService _singletonService2;

        public demoController(IScopedService scopedService, IScopedService scopedService2, ITransientService transientService,
            ITransientService transientService2, ISingletonService singletonService, ISingletonService singletonService2)
        {
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _transientService = transientService;
            _transientService2 = transientService2;
            _singletonService = singletonService;
            _singletonService2 = singletonService2;
        }

        [HttpGet("scoped")]
        public async Task<ActionResult<ResultModel>> Scoped()
        {
            BaseResultModel firstRequest = await _scopedService.GetResult();
            BaseResultModel secondRequest = await _scopedService2.GetResult();

            ResultModel result = new();
            result.Results.Add(firstRequest);
            result.Results.Add(secondRequest);
            result.NameDI = "Scoped";
            result.DescriptionDI = _scopedService.GetDescription();

            return result is null ? NoContent() : Ok(result);
        }

        [HttpGet("transient")]
        public async Task<ActionResult<ResultModel>> Transient()
        {
            var firstRequest = await _transientService.GetResult();
            var secondRequest = await _transientService2.GetResult();

            ResultModel result = new();
            result.Results.Add(firstRequest);
            result.Results.Add(secondRequest);
            result.NameDI = "Transient";
            result.DescriptionDI = _transientService.GetDescription();

            return result is null ? NoContent() : Ok(result);
        }

        [HttpGet("singleton")]
        public async Task<ActionResult<ResultModel>> Singleton()
        {
            var firstRequest = await _singletonService.GetResult();
            var secondRequest = await _singletonService2.GetResult();

            ResultModel result = new();
            result.Results.Add(firstRequest);
            result.Results.Add(secondRequest);
            result.NameDI = "Singleton";
            result.DescriptionDI = _singletonService.GetDescription();

            return result is null ? NoContent() : Ok(result);
        }
    }
}