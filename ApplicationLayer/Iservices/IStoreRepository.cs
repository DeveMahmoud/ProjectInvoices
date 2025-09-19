using ApplicationLayer.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Iservices
{
    public interface IStoreRepository
    {
        Task<IEnumerable<StoreDto>> GetAllAsync();

    }
}
