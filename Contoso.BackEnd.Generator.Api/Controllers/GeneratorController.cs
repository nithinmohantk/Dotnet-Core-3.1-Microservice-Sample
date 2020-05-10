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

    [ApiController]
    [Route("[controller]")]
    public class GeneratorController : ControllerBase
    {

        private readonly ILogger<GeneratorController> _logger;

        public GeneratorController(ILogger<GeneratorController> logger)
        {
            _logger = logger;
        }

        /// <summary>Gets the specified y.</summary>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<IEnumerable<GeneratorResultModel>> Get(int y)
        {
            List<GeneratorResultModel> result = new List<GeneratorResultModel>();
            var processList = Enumerable.Range(1, y).ToList();  //Just to demonstrate how to generate a sequence for Y

            for( int index =0; index < processList.Count; index ++)
            {
                var itemResult = await this.PrepareItem(y, processList[index]);

                result.Add(itemResult);
            }

            return result;
        }

        /// <summary>Prepares the item.</summary>
        /// <param name="y">The y.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private async Task<GeneratorResultModel> PrepareItem( int y, int index)
        {

            Random rng = new Random();
            int number = rng.Next(Constants.GENERATOR_RAND_MIN, Constants.GENERATOR_RAND_MAX);
            return new GeneratorResultModel
            {
                Timestamp = DateTime.Now.AddDays(index),
                Number = rng.Next(Constants.GENERATOR_RAND_MIN, Constants.GENERATOR_RAND_MAX),
                Summary = await GetSummary(number)
            }; 
        }

        /// <summary>Gets the summary.</summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private  async Task<string> GetSummary(int num)
        {
            Random rng = new Random();
            await Task.Delay(rng.Next(Constants.GENERATOR_RAND_DELAY_MIN, Constants.GENERATOR_RAND_DELAY_MAX));

            return $"summary-{num}";
        }
    }
}
