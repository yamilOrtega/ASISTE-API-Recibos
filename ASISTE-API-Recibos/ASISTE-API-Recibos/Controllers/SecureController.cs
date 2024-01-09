using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASISTE_API_Recibos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [HttpGet("secureData")]
        [Authorize] // Requires a valid JWT token obtained from the first API
        public IActionResult GetSecureData()
        {
            
            var username = User.Identity.Name; 
            var isAdmin = User.IsInRole("Admin"); 

            return Ok(new { Username = username, IsAdmin = isAdmin, Data = "This is secure from second API" });
        }
    }
}
