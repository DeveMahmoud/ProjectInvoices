using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class InvoiceDto
    {
        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public int StoreId { get; set; }

        public decimal Total { get; set; }
        public decimal Taxes { get; set; }
        public decimal Net { get; set; }

        public List<InvoiceItemDto> Items { get; set; } = new();
    }
}
