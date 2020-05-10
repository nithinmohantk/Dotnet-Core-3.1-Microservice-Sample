using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.BackEnd.BusinessLogic
{
    public class MultiplicationEngine : IMultiplicationEngine
    {

        private readonly ILogger<MultiplicationEngine> _logger;

        /// <summary>Initializes a new instance of the <see cref="MultiplicationEngine" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public MultiplicationEngine(ILogger<MultiplicationEngine> logger)
        {
            _logger = logger;
        }
        static Random _r = new Random();

        public int Multiply(int max)
        {
            int n = _r.Next(1, max);
            return n;
        }
    }
}
