using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IGoalRepository
    {
        bool Save();
        bool CreateGoal(Goal goal);
        bool UpdateGoal(Goal goal);

        bool GoalExists(int goalId);
        Task <List<Goal>> GetGoalsAsync(string searchInput, string searchType);

        Goal GetGoalDetails(int goalId);
    }
}
