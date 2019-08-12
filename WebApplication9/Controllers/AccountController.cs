using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]Login model)
        {

            var user = new IdentityUser { UserName = model.UserName, PasswordHash = model.Password };

            var result = _userManager.CreateAsync(user, model.Password);
            if (!result.Result.Succeeded)
            {
                return BadRequest(result.Result.Errors);
            }
          
            return Ok();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            if (login == null)
            {
                return BadRequest("Invalid client request");
            }

            var theUser =  await _userManager.FindByNameAsync(login.UserName);
            if (theUser != null && await  _userManager.CheckPasswordAsync(theUser, login.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tom_peeters123456789"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
               var roles = await _userManager.GetRolesAsync(theUser);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.UserName));
                foreach (string item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }  

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44372",
                    audience: "http://localhost:44372",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}