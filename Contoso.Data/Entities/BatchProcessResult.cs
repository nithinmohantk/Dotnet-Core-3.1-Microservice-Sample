using System;

namespace Contoso.Data.Entities
{
    public class BatchProcessResult : BaseEntity
    {
      
        public string Number { get; set; }

        public int Result { get; set; }
        
    }
}
