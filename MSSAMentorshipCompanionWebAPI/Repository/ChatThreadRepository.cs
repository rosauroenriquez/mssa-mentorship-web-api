using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    public class ChatThreadRepository : IChatThreadRepository
    {
        private readonly DataContext _dataContext;

        public ChatThreadRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateThread()
        {
            var newThread = new ChatThread();
            _dataContext.Add(newThread);
            return Save();
        }


        public ChatThread GetChatThread(int threadId)
        {
            var chatThread = _dataContext.ChatThreads.Where(p =>  p.ThreadId == threadId).FirstOrDefault();
            chatThread.ChatMessages = _dataContext.ChatMessages.Where(p => p.ThreadId == threadId).ToList();
            return chatThread;
        }

        public bool Save()
        {
            var result = _dataContext.SaveChanges();
            return result > 0;
        }
    }
}
