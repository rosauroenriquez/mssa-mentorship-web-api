using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IChatMessageRepository
    {
        bool Save();
        bool CreateChatMessage(ChatMessage chat);
        List<ChatMessage> GetMessages(int threadId);
    }
}
