using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Iservices
{
    public interface IUnitRepository
    {
        Task<IEnumerable<UnitDto>> GetByIdAsync(int unitId);

    }
}
