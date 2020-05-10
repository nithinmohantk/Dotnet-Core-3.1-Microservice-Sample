using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso
{
    public enum JobStatus
    {
         New,
         Scheduled,
         InProgress,
         Complete,
         Errored,
         Cancelled,
         Retry,
         LongRetry,
    }
}
