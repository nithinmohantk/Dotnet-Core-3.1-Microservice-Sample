using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Entities
{
    public class Job : BaseEntity
    {
        
        public List<JobResult> Results { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime CompletionTime { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }
}
