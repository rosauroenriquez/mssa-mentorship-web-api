using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSAMentorshipCompanionWebAPI.Dto;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;
using MSSAMentorshipCompanionWebAPI.Repository;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MentorshipController: Controller
    {
        #region DATABASE HOOKUP
        private readonly IMentorshipRepository _mentorshipRepository;
        private readonly IMapper _mapper;

        public MentorshipController(IMentorshipRepository mentorshipRepository, IMapper mapper)
        {
            _mentorshipRepository = mentorshipRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMentorship([FromBody] Mentorship mentorship) 
        {
            if (mentorship == null)
                return BadRequest(ModelState);

            var existingMentorship = _mentorshipRepository.GetMentorship(mentorship.MentorshipId);

            if (existingMentorship != null)
            {
                ModelState.AddModelError("", "Mentorship Already Exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_mentorshipRepository.CreateMentorship(mentorship))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully Created");
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Mentorship>))]
        [ProducesResponseType(400)]
        public IActionResult GetMentorships([FromQuery] string userId)
        {
            var mentorships = _mentorshipRepository.GetMentorships(userId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mentorships);
        }

        [HttpGet("{mentorshipId}")]
        [ProducesResponseType(200, Type = typeof(Mentorship))]
        [ProducesResponseType(400)]
        public IActionResult GetMentorship(int mentorshipId)
        {
            var mentorship = _mentorshipRepository.GetMentorship(mentorshipId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mentorship);
        }
    }
}
