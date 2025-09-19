using ApplicationLayer.DTO;
using ApplicationLayer.Iservices;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IAuthRepository _authService;

        public LoginController(IAuthRepository authService)
        {
            _authService = authService;
        }

        //MVC HTML
        public IActionResult LoginForm()
        {
            return View();
        }

        // API 
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.Login(dto);
                return Json(result); 
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
    }
}
