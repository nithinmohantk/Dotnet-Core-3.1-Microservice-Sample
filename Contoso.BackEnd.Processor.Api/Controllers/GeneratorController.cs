using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.BackEnd.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contoso.BackEnd.Processor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneratorController : ControllerBase
    {

        private readonly ILogger<GeneratorController> _logger;

        public GeneratorController(ILogger<GeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GeneratorResultModel> Get()
        {
            return null;
        }
    }
}
