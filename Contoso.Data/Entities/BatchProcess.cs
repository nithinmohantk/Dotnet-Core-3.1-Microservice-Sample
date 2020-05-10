using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Entities
{
    public class BatchProcess : BaseEntity
    {

        public List<BatchProcessResult> Results { get; set; }

    }
}
