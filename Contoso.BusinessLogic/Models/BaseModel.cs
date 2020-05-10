using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.BackEnd.BusinessLogic.Models
{
    public class BaseModel
    {

        public string StatusCode
        {
            get;set;
        }

        public string StatusMsg
        {
            get; set;
        }

        public string StatusDesc
        {
            get; set;
        }


        public DateTime TimestampReceived { get; set; }
        public DateTime TimestampCompletion { get; set; }
        public int TimeElapsedInSecs { get; set; }
    }
}
