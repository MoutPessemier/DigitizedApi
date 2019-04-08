using DigitizedApi.DTO;
using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigitizedApi.Controllers {
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVisitorRepository _visitorRepository;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IVisitorRepository visitorRepository
            , IConfiguration configuration) {
            _singInManager = signInManager;
            _userManager = userManager;
            _visitorRepository = visitorRepository;
            _config = configuration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model) {
            var user = await _userManager.FindByNameAsync(model.Email);
            if(user != null) {
                var result = await _singInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded) {
                    string token = GetToken(user);
                    return Created("", token);
                }
            }
            return BadRequest();
        }

        private string GetToken(IdentityUser user) {
            //payload claims
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email), //subject claim
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)//extra (een voorbeeld van extra claims mee te geven)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="model"></param>
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<String>> Register(RegisterDTO model) {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            Visitor visitor = new Visitor(model.FirstName + " " + model.LastName, model.Email, model.PhoneNumber, model.Country);

            var visitorInDb = _visitorRepository.GetAll().FirstOrDefault(v => v.Email == visitor.Email);
            if(visitorInDb != null) {
                return BadRequest("User already in the database");
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                _visitorRepository.AddVisitor(visitor);
                _visitorRepository.SaveChanges();
                string token = GetToken(user);
                return Created("", token);
            }
            return BadRequest();
        }
    }
}