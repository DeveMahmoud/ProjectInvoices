using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Store: BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Invoice> Invoices { get; set; }


    }
}
