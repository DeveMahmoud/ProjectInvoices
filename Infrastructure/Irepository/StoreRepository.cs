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
    public class StoreRepository: IStoreRepository
    {
        private readonly InvoiceDbContext _context;
        public StoreRepository(InvoiceDbContext context) => _context = context;

        public async Task<IEnumerable<StoreDto>> GetAllAsync()
        {
            return await _context.Stores
                .Select(s => new StoreDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

    }
}
