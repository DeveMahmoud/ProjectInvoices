using ApplicationLayer.DTO;
using ApplicationLayer.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoicerepository _invoiceService;
        public InvoiceController(IInvoicerepository invoiceService) => _invoiceService = invoiceService;


        //MVC HTML
        public IActionResult CreateInvoice()
        {
            return View();
        }


        // API 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceCreateDto dto)
        {
            var created = await _invoiceService.CreateInvoiceAsync(
                dto,
                 User?.FindFirst("userId")?.Value
                //User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
            );

            return Ok(created);
        }

    }
}
