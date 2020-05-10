using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Entities
{
    public class JobInfo : BaseEntity
    {
        public int MaxCount
        {
            get;
            set;
        }

        public JobType JobType
        {
            get;set;
        }

        public JobStatus JobStatus
        {
            get; set;
        }

        public DateTime CreatedTime { get; set; }

        public DateTime CompletionTime { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }
}
