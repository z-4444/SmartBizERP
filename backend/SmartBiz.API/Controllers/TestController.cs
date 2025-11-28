using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartBiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController() { }

        [HttpGet("public")]
        public IActionResult Public()
        {
            string[] passwords = new string[]
            {
                "AdminPass123!",
                "ManagerPass123!",
                "StaffPass123!",
                "CustPass123!",
                "CustPass123!"
            };

            foreach (var password in passwords)
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(password);
                Console.WriteLine($"Password: {password} => Hash: {hashed}");
            }
            return Ok(new { Message = "This is a public endpoint. No authentication required." });
        }


    }
}
