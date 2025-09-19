using ApplicationLayer.DTO;
using ApplicationLayer.Iservices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Irepository
{
    public class ITemRepository : IITemRepository
    {
        private readonly InvoiceDbContext _context;
        public ITemRepository(InvoiceDbContext context) => _context = context;
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            return await _context.Items
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    UnitId = i.UnitId,
                })
                .ToListAsync();
        }
    }
}
