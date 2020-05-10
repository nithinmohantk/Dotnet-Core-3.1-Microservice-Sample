using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contoso.BackEnd.Generator.Api.Controllers
{
    using Contoso.Core;
    using System.Diagnostics;
    using System.Threading;
    //using Models;
    using Contoso.BackEnd.BusinessLogic.Models;
    using Contoso.BackEnd.BusinessLogic;

    [ApiController]
    [Route("api/[controller]")]
    public class GeneratorController : ControllerBase
    {

        private readonly ILogger<GeneratorController> _logger;
        private readonly IRandomGeneratorEngine _engine;

        /// <summary>Initializes a new instance of the <see cref="GeneratorController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public GeneratorController(ILogger<GeneratorController> logger, IRandomGeneratorEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        /// <summary>Gets the specified y.</summary>
        /// <param name="y">The range.</param>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<GeneratorResultModel> Get(int range)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GeneratorResultModel result = new GeneratorResultModel();
            try
            {
              
                result.TimestampReceived = DateTime.Now;
                result.Result = await _engine.Generate(range);
                result.TimeElapsedInSecs = (int)watch.ElapsedMilliseconds / 1000;
                result.TimestampCompletion = DateTime.Now;
            }
            catch(Exception ex)
            {

            }

            return result;
        }

       
    }
}
