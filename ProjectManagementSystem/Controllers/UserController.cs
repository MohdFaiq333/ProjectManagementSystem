using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PMS.Core.Service;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ProjectManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IPmsService _pmsService;
        private IConfiguration _config;
        public UserController(IPmsService pmsService,IConfiguration config)
        {
            _pmsService = pmsService;
            _config = config;
        }
        [HttpPost]
        public IActionResult Login( string email, string password)
        {
            if (!(string.IsNullOrWhiteSpace(email)||(string.IsNullOrWhiteSpace(password))))
            {
                int UserId = _pmsService.UserLogin(email, password);
                if (UserId != 0)
                {
                    var tokenstring = GenerateJSONWebToken(email);
                    return Ok(new { token = tokenstring });
                }
                return Unauthorized();
            }
            return BadRequest(); 

        }
        private string GenerateJSONWebToken(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddSeconds(30),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
