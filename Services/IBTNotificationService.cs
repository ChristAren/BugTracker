using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BugTracker.Models;

namespace BugTracker.Services
{
    public interface IBTNotificationService
    {
        // When we talk about a "user" their  are two versions of the user
        // A record in the Users table - represents any person who is registered
        // The other is capital U User - this is the currently logged in user ClaimsPrinciple User
        public Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(ClaimsPrincipal currentUser);
    }
}
