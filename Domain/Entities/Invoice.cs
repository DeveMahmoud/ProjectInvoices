using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice: BaseEntity
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public decimal Total { get; set; }
        public decimal Taxes { get; set; }
        public decimal Net { get; set; }
        public string CreatedById { get; set; } = string.Empty;

        public ICollection<InvoiceItem> Items { get; set; }
    }
}
