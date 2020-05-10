using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Entities
{
    public class Job : BaseEntity
    {
        
        public List<BatchProcess> Batches { get; set; }

        public JobInfo Info
        {
            get;
            set;
        }
    }
}
