using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;
using MSSAMentorshipCompanionWebAPI.Repository;

namespace MSSAMentorshipCompanionWebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : Controller
    {
        private IChatMessageRepository _chatMessageRepository;
        private IMapper _mapper;

        public ChatMessageController(IChatMessageRepository chatMessageRepository, IMapper mapper)
        {
            _chatMessageRepository = chatMessageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChatMessage>))]
        public IActionResult GetChatMessages([FromQuery] int threadId)
        {
            if (threadId == null)
                return NotFound();
            var chatMessages = _chatMessageRepository.GetMessages(threadId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(chatMessages);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateChatMessage([FromBody] ChatMessage chatMessage)
        {
            if (chatMessage == null || !ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_chatMessageRepository.CreateChatMessage(chatMessage))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


    }
}
