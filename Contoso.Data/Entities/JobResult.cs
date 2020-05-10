using System;

namespace Contoso.Data.Entities
{
    public class JobResult : BaseEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        public int Result { get; set; }
        
    }
}
