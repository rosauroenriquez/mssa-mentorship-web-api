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
    public class GoalController : Controller
    {
        #region DATABASE HOOKUP
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GoalController(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }
        #endregion

        [HttpGet("{searchInput}&{searchType}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Goal>))]
        public async Task<IActionResult> GetGoals(string searchInput, string searchType)
        {
            var goals = await _goalRepository.GetGoalsAsync(searchInput,searchType);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(goals);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Goal))]
        public IActionResult GetGoalDetails([FromQuery] int goalId)
        {
            var goalDetails = _goalRepository.GetGoalDetails(goalId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(goalDetails);
        }

        [HttpPost] // for creating
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGoal([FromBody] Goal goal)
        {
            if (goal == null)
                return BadRequest(ModelState);

            var existingGoal = _goalRepository.GetGoalDetails(goal.GoalId);

            if (existingGoal != null)
            {
                ModelState.AddModelError("", "Existing Goal");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_goalRepository.CreateGoal(goal))
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
        public IActionResult UpdateGoal([FromBody] Goal goal)
        {
            if (goal == null)
                return BadRequest(ModelState);

            if (!_goalRepository.GoalExists(goal.GoalId))
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_goalRepository.UpdateGoal(goal))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
