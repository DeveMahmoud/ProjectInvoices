using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class InvoiceCreateDto
    {
        public string InvoiceNo { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
        public int StoreId { get; set; }

        public decimal Total { get; set; }   // Subtotal from UI (sum of item Net)
        public decimal Taxes { get; set; }   // from UI
        public decimal Net { get; set; }     // from UI (Total + Taxes)
        public string CreatedById { get; set; } = string.Empty;

        public List<InvoiceItemDto> Items { get; set; } = new();
    }
}
