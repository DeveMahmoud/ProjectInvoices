using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Iservices
{
    public interface IInvoicerepository
    {

        Task<InvoiceDto> CreateInvoiceAsync(InvoiceCreateDto dto, string createdBy = null);
        Task<InvoiceDto> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
    }
}

