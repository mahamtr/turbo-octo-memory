using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BANKEST2.Core.Entities;
using BANKEST2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BANKEST2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthService _authService;


        public AuthenticationController(IConfiguration config,IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserRequestInfo login)
        {
            IActionResult response = Unauthorized();
            if (_authService.AuthenticateUser(login.UserName,login.PassWord))
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserRequestInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var payload = new JwtPayload(
                   issuer: _config["JWT:Issuer"],
                   audience: _config["JWT:Audience"],
                   claims: claims,
                   notBefore: DateTime.UtcNow,
                   expires: DateTime.UtcNow.AddMinutes(2)
               ) ;

            var token = new JwtSecurityToken(
                    header,
                    payload
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}