using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Random rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new GeneratorResultModel
            {
                Date = DateTime.Now.AddDays(index),
                Number = rng.Next(1, 100),
                Summary = "todo-something"
            })
            .ToArray();
        }
    }
}
