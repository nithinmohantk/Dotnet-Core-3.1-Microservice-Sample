using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.BackEnd.Generator.Api.BLL
{
    public class MultiplicationEngine
    {

        static Random _r = new Random();

        public int Multiply(int max)
        {
            int n = _r.Next(1, max);
            return n;
        }
    }
}
