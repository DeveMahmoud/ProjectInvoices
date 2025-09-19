using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class InvoiceItemDto
    {
        public int ItemId { get; set; }
        public int UnitId { get; set; }

        public decimal Price { get; set; }    // من UI
        public decimal Qty { get; set; }      // من UI
        public decimal Total { get; set; }    // من UI (Price * Qty)
        public decimal Discount { get; set; } // من UI
        public decimal Net { get; set; }      // من UI (Total - Discount)
    }
}
