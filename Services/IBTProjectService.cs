using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services
{
    public interface IBTProjectService
    {
        //Is the user on a project?
        public Task<bool> IsUserOnProjectAsync(string userId, int projectId);

        //All users on the project
        public Task<IEnumerable<BTUser>> UsersOnProjectAsync(int projectId);

        //All users not on the project
        public Task<IEnumerable<BTUser>> UsersNotOnProjectAsync(int projectId);

        //Assign/Add user to a project
        public Task AddUserToProjectAsync(string userId, int projectId);

        //Remove user from project
        public Task RemoveUserFromProjectAsync(string userId, int projectId);

        //All projects for one user
        public Task<IEnumerable<Project>> ListUserProjectsAsync(string userId);

        //Developers on Projects
        public Task<IEnumerable<BTUser>> DevelopersOnProjectAsync(int projectId);

        //Submitters on Project
        public Task<IEnumerable<BTUser>> SubmittersOnProjectAsync(int projectId);

        //Project Manager on Project
        public Task<BTUser> ProjectManagerOnProjectAsync(int projectId);
    }
}
