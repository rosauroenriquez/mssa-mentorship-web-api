using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly DataContext _dataContext;

        public GoalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateGoal(Goal goal)
        {
            goal.GoalThread = new ChatThread();
            _dataContext.Add(goal);
            return Save();
        }

        public Goal GetGoalDetails(int goalId)
        {
            return _dataContext.Goals.Where(p => p.GoalId == goalId).FirstOrDefault();
        }

        public async Task <List<Goal>> GetGoalsAsync(string searchInput, string searchType)
        {
            
            switch (searchType) 
            {
                case "status":
                    return await _dataContext.Goals.Where(p => p.Status == searchInput).ToListAsync();
                case "mentorshipid":
                    return await _dataContext.Goals.Where(p => p.MentorshipId == int.Parse(searchInput)).ToListAsync();
                case "goalid":
                    return await _dataContext.Goals.Where(p => p.GoalId == int.Parse(searchInput)).ToListAsync();
                default:
                    return await _dataContext.Goals.Where(p => p.StudentId == searchInput).ToListAsync();
            }

        }

        public bool GoalExists(int goalId)
        {
            return _dataContext.Goals.Where(p => p.GoalId == goalId).Any();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }

        public bool UpdateGoal(Goal goal)
        {
            _dataContext.Update(goal);
            return Save();
        }
    }
}
