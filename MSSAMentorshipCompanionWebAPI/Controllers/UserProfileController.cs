using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MSSAMentorshipCompanionWebAPI.Dto;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;
using MSSAMentorshipCompanionWebAPI.Repository;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : Controller
    {
        
        #region DATABASE HOOKUP
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserProfile>))]
        public async Task<IActionResult> GetProfiles() 
        {
            var userProfiles = await _userProfileRepository.GetProfiles();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(userProfiles);        
        }

        [HttpGet("{userID}")]
        [ProducesResponseType(200, Type = typeof(UserProfile))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProfile(string userID) 
        {
            if (! await _userProfileRepository.ProfileExists(userID))
                return NotFound();
            var userProfile = await _userProfileRepository.GetProfile(userID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(userProfile);
        }

        [HttpGet("{searchInput}&{range}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserProfile>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProfilesBySearch(string searchInput, int range)
        {
            var userProfiles = await _userProfileRepository.GetProfilesBySearch(searchInput,range);
            if (userProfiles.IsNullOrEmpty())
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(userProfiles);
        }

        [HttpPost] // for creating
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfile user)
        {
            if (user == null)
                return BadRequest(ModelState);

            var existingUser = await _userProfileRepository.GetProfile(user.UserID);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "User ID already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (! await _userProfileRepository.CreateUserProfile(user))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");

        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileDto user)
        {
            if (user == null)
                return BadRequest(ModelState);

            if (! await _userProfileRepository.ProfileExists(user.UserID))
                return NotFound();

            var userMap = _mapper.Map<UserProfile>(user);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (! await _userProfileRepository.UpdateUserProfile(userMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
