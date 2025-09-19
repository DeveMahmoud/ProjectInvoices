using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class AuthResponseDto
    {
        public string UserId { get; set; }   // ✅ UserId
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
