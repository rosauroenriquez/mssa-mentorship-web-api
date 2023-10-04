using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IChatThreadRepository
    {
        bool CreateThread();
        bool Save();
        ChatThread GetChatThread(int threadId);
    }
}
