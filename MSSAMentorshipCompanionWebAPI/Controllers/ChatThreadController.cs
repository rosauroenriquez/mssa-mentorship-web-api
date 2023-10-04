using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatThreadController : Controller
    {
        private readonly IChatThreadRepository _threadRepository;
        private readonly IMapper _mapper;

        public ChatThreadController(IChatThreadRepository threadRepository, IMapper mapper)
        {
            _threadRepository = threadRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ChatThread))]
        public IActionResult GetChatThread([FromQuery] int chatThreadId) 
        {
            if (chatThreadId == null || !ModelState.IsValid)
                return BadRequest(ModelState);
            var chatThread = _threadRepository.GetChatThread(chatThreadId);
            return Ok(chatThread);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatChatThread() 
        {
            if (!_threadRepository.CreateThread()) 
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }                
            
            return NoContent();
        }
    }
}
