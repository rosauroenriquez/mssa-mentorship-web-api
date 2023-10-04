using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly DataContext _dataContext;

        public ChatMessageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateChatMessage(ChatMessage chat)
        {
            _dataContext.Add(chat);
            return Save();
        }

        public List<ChatMessage> GetMessages(int threadId)
        {
            return _dataContext.ChatMessages.Where(p =>  p.ThreadId == threadId).ToList();
        }

        public bool Save()
        {
            var result = _dataContext.SaveChanges();
            return result > 0;
        }
    }
}
