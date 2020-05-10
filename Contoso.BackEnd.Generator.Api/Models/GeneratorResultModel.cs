using System;

namespace Contoso.BackEnd.Generator.Api
{
    public class GeneratorResultModel
    {
        public DateTime Timestamp { get; set; }

        public int Number { get; set; }

        public int Hash => 32+ (int)(Number / 333.55586);

        public string Summary { get; set; }
    }
}
