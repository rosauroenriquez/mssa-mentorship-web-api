using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IMentorshipRepository
    {
        bool Save();
        bool CreateMentorship(Mentorship mentorship);
        List<Mentorship> GetMentorships(string userId);

        Mentorship GetMentorship(int mentorshipId);

    }
}
