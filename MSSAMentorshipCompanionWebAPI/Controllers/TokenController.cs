using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MSSAMentorshipCompanionWebAPI.Dto;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        private readonly IMapper _mapper;

        public TokenController(IUserCredentialsRepository userCredentialsRepository, IMapper mapper)
        {
            _userCredentialsRepository = userCredentialsRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var user =  _mapper.Map<UserCredentialsDto>(await _userCredentialsRepository.Authenticate(model.EmailAddress,model.HashedPassword));
            if (user == null)
            {
                return Unauthorized();
            }

            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID),
                new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("V€r¥ $ecret (not!)"));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expires = token.ValidTo
            });
        }
    }
}
