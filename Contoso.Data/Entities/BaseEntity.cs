using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Data.Entities
{
    public class BaseEntity
    {

        public Guid Id { get; set; }

        public DateTime CreatedDt
        { 
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime ModifiedDt
        {
            get;
            set;
        }

        public string ModifiedBy
        {
            get;
            set;
        }

    }
}
