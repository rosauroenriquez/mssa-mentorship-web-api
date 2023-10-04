using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    public class MentorshipRepository : IMentorshipRepository
    {
        private readonly DataContext _dataContext;

        public MentorshipRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateMentorship(Mentorship mentorship)
        {
            
            _dataContext.Add(mentorship);
            return Save();
        }

        public List<Mentorship> GetMentorships(string userId)
        {
            return _dataContext.Mentorships.Where(p => p.StudentID == userId).ToList();
        }

        public Mentorship GetMentorship(int mentorshipId)
        {
            return _dataContext.Mentorships.Where(p => p.MentorshipId == mentorshipId).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}
