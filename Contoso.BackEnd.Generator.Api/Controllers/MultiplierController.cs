using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Contoso.BackEnd.Generator.Api.Controllers
{
    using Contoso.BackEnd.BusinessLogic;
    using Contoso.BackEnd.BusinessLogic.Models;
    using Core.Extensions;
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplierController : ControllerBase
    {

        private readonly ILogger<MultiplierController> _logger;
        IMultiplicationEngine _engine ;

        /// <summary>Initializes a new instance of the <see cref="MultiplierController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public MultiplierController(ILogger<MultiplierController> logger, IMultiplicationEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        /// <summary>Gets the specified y.</summary>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        [HttpGet]

        public async Task<MultiplierResultModel> Get(int multiplier)
        {
            MultiplierResultModel result = new MultiplierResultModel();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            result.TimestampReceived = DateTime.Now;

            result.Result = Enumerable.Range(1, multiplier).Multiply(multiplier);

            result.TimeElapsedInSecs = (int)watch.ElapsedMilliseconds / 1000;
            result.TimestampCompletion = DateTime.Now;


            return result;
        }
    }
}
