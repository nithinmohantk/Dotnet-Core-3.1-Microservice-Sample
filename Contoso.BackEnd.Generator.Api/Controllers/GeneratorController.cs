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
    using Models;

    [ApiController]
    [Route("api/[controller]")]
    public class GeneratorController : ControllerBase
    {

        private readonly ILogger<GeneratorController> _logger;

        /// <summary>Initializes a new instance of the <see cref="GeneratorController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public GeneratorController(ILogger<GeneratorController> logger)
        {
            _logger = logger;
        }

        /// <summary>Gets the specified y.</summary>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<GeneratorResultModel> Get(int y)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GeneratorResultModel result = new GeneratorResultModel();
            List<GeneratorItemModel> resultList = new List<GeneratorItemModel>();
            Task<GeneratorItemModel>[] workers = new Task<GeneratorItemModel>[y];
            result.TimestampReceived = DateTime.Now;
            try
            {

                for (int index = 0; index < y; index++)
                {
                    //1.this logic will be slower, as it works sequentially to complete each await. 
                    //var itemResult = await this.PrepareItem(y, processList[index]);
                    //result.Add(itemResult);

                    //Option 2: Parallel, create tasks and keep them in an array and invoke them all.
                    var task = this.PrepareItem(y, index);
                    _logger.LogInformation($"Creating Task: {index} ");
                    workers[index] = task;
                }

                Task.WaitAll(workers);

                foreach (var task in workers)
                {

                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        if (task.Result != null)
                            resultList.Add(task.Result);
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            result.Result = resultList;

            result.TimeElapsedInSecs = (int)watch.ElapsedMilliseconds / 1000;
            result.TimestampCompletion = DateTime.Now;

            return result;
        }

        /// <summary>Prepares the item.</summary>
        /// <param name="y">The y.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private async Task<GeneratorItemModel> PrepareItem( int y, int index)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
             
            // Output a message from the calling thread.
            _logger.LogInformation($"Processing through thread '{Thread.CurrentThread.Name}'.");
            Random rng = new Random();
            int number = rng.Next(Constants.GENERATOR_RAND_MIN, Constants.GENERATOR_RAND_MAX);
            var result = new GeneratorItemModel
            {
                Number = number,
            };
            result.Summary = await GetSummary(number); // delay is currently introduced into this call to make it more realistic through dependency delays :-) 
            result.TimeElapsedInSecs = (int) watch.ElapsedMilliseconds / 1000;
            result.Timestamp = DateTime.Now;
            return result;
        }

        /// <summary>Gets the summary.</summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private  async Task<string> GetSummary(int num)
        {
            Random rng = new Random();
            await Task.Delay(rng.Next(Constants.GENERATOR_RAND_DELAY_MIN, Constants.GENERATOR_RAND_DELAY_MAX) * 1000);
            Console.WriteLine($"...Running task thread: {Thread.CurrentThread.Name}");

            return $"summary-{num}";
        }
    }
}
