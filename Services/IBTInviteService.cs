using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models.ViewModels;

namespace BugTracker.Services
{
    public interface IBTInviteService
    {
        public Task<string> InviteWizardAsync(InviteViewModel inviteViewModel);
    }
}
