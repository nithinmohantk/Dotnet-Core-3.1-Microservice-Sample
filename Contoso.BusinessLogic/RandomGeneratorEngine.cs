using Contoso.BackEnd.BusinessLogic.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.BackEnd.BusinessLogic
{
    public class RandomGeneratorEngine : IRandomGeneratorEngine
    {
        private readonly ILogger<RandomGeneratorEngine> _logger;

        /// <summary>Initializes a new instance of the <see cref="RandomGeneratorEngine" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public RandomGeneratorEngine(ILogger<RandomGeneratorEngine> logger)
        {
            _logger = logger;
        }
        /// <summary>Generates the specified range.</summary>
        /// <param name="range">The range.</param>
        /// <returns></returns>
        public async Task<List<GeneratorItemModel>> Generate(int range)
        {
            List<GeneratorItemModel> resultList = new List<GeneratorItemModel>();
            Task<GeneratorItemModel>[] workers = new Task<GeneratorItemModel>[range];

            try
            {

                for (int index = 0; index < range; index++)
                {
                    //Option 2: Parallel, create tasks and keep them in an array and invoke them all.
                    var task = this.PrepareItem(range, index);
                    _logger.LogInformation($"Creating Task: {index} ");
                    workers[index] = task;
                }

                Task.WaitAll(workers);

                foreach (var task in workers)
                {

                    if (task.Status == TaskStatus.RanToCompletion && task.Result != null)
                    {
                        resultList.Add(task.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return resultList;
        }

        /// <summary>Prepares the item.</summary>
        /// <param name="y">The y.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private async Task<GeneratorItemModel> PrepareItem(int y, int index)
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
            result.TimeElapsedInSecs = (int)watch.ElapsedMilliseconds / 1000;
            result.Timestamp = DateTime.Now;
            return result;
        }

        /// <summary>Gets the summary.</summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "<Pending>")]
        private async Task<string> GetSummary(int num)
        {
            Random rng = new Random();
            await Task.Delay(rng.Next(Constants.GENERATOR_RAND_DELAY_MIN, Constants.GENERATOR_RAND_DELAY_MAX) * 1000);
            Console.WriteLine($"...Running task thread: {Thread.CurrentThread.Name}");

            return $"summary-{num}";
        }
    }
}
