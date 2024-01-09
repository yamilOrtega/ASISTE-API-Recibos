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
            // Accessible only if the request has a valid JWT token
            // The user's identity can be retrieved using User.Identity

            var username = User.Identity.Name; // Get the username from the token's claims
            var isAdmin = User.IsInRole("Admin"); // Check if the user has the "Admin" role

            // Your secure data retrieval logic goes here

            return Ok(new { Username = username, IsAdmin = isAdmin, Data = "This is secure from second API" });
        }
    }
}
