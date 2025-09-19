using ApplicationLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Iservices
{
    public interface IITemRepository
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
    }
}
