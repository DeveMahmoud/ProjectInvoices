using ApplicationLayer.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly IStoreRepository _storeService;
        private readonly IITemRepository _itemService;
        private readonly IUnitRepository _unitService;

        public LookupsController(
            IStoreRepository storeService,
            IITemRepository itemService,
            IUnitRepository unitService
            )
        {
            _storeService = storeService;
            _itemService = itemService;
            _unitService= unitService;
        }

        [HttpGet("stores")]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _storeService.GetAllAsync();
            return Ok(stores);
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }
        
        [HttpGet("unit/{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit == null) return NotFound();
            return Ok(unit);
        }

    }
}
