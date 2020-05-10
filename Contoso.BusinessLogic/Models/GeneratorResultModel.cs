using System;
using System.Collections;
using System.Collections.Generic;

namespace Contoso.BackEnd.BusinessLogic.Models
{
    public class GeneratorResultModel : BaseModel
    {
          public List<GeneratorItemModel> Result
            {
                get;
                set;
            }

    }


    public class GeneratorItemModel
    {
        

        public int Number { get; set; }

        public long Hash => 32 + (long)(Number / 2333.55586);  //just some random stupid logic

        public string Summary { get; set; }

        public DateTime Timestamp { get; set; }
        public int TimeElapsedInSecs { get; set; }
    }
}
