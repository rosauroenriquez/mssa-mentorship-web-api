using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MSSAMentorshipCompanionWebAPI.Dto;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;
using MSSAMentorshipCompanionWebAPI.Repository;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredentialsController : Controller
    {

        #region DATABASE HOOKUP
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        private readonly IMapper _mapper;

        public UserCredentialsController(IUserCredentialsRepository userCredentialsRepository, IMapper mapper)
        {
            _userCredentialsRepository = userCredentialsRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserCredentials>))]
        public async Task<IActionResult> GetUserCredentials()
        {
            var userCredentials = _mapper.Map<List<UserCredentialsDto>>(await _userCredentialsRepository.GetUsers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userCredentials);
        }

        //Querying a USER by userID (single parameter query)
        [HttpGet("{userID}")]
        [ProducesResponseType(200, Type = typeof(UserCredentials))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUser(string userID)
        {
            //Validation to check if user exists
            if (!await _userCredentialsRepository.UserExists(userID))
                return NotFound();

            //var user = _mapper.Map<UserCredentialsDto>(_userCredentialsRepository.GetUser(userID));
            var user = await _userCredentialsRepository.GetUser(userID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        ////Authenticating a user using UserID and password
        //[HttpGet("{userID}&{password}")]
        //[ProducesResponseType(200, Type = typeof(bool))]
        //[ProducesResponseType(400)]
        //public IActionResult GetAuthStatus(string userID, string password)
        //{
        //    //Validation to check if user exists
        //    if (!_userCredentialsRepository.UserExists(userID))
        //        return NotFound();

        //    //var user = _mapper.Map<UserCredentialsDto>(_userCredentialsRepository.LoginSuccess(userID,password));

        //    bool status = _userCredentialsRepository.Authenticate(userID, password);
        //    //var user = _userCredentialsRepository.GetUser(userID);
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    return Ok(status);
        //}

        [HttpPost] // for creating
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] UserCredentials user)
        {
            if (user == null)
                return BadRequest(ModelState);

            var existingUser = await _userCredentialsRepository.GetUser(user.UserID);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "User ID already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _userCredentialsRepository.CreateUser(user))
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
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordDto user)
        {
            if (user == null)
                return BadRequest(ModelState);

            //if (!_userCredentialsRepository.UserExists(user.UserID))
            //    return NotFound();

            var userToUpdate = await _userCredentialsRepository.GetUser(user.UserID);
            if (userToUpdate == null)
                return NotFound();

            //var userMap = _mapper.Map<UserCredentials>(user);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _userCredentialsRepository.UpdatePassword(userToUpdate, user.HashedPassword))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpPut("{userID}&{reset}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ResetPassword(string userID, bool reset)
        {
            if (userID == null || !reset)
                return BadRequest(ModelState);

            var userToUpdate = await _userCredentialsRepository.GetUser(userID);
            if (userToUpdate == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _userCredentialsRepository.ResetPassword(userToUpdate))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
