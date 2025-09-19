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
    public class UnitRepository: IUnitRepository
    {

        private readonly InvoiceDbContext _context;
        public UnitRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UnitDto>> GetByIdAsync(int unitId)
        {
            return  await _context.Units
                .Where(u => u.Id == unitId)
                .Select(u => new UnitDto
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }
    }
}
