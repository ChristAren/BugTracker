using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services
{
    public class BTNotificationService : IBTNotificationService
    {
        //I need to access the databse to get the notification
        //I need the UserManager to convert the ClaimsPrincipal to BTUser
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;

        public BTNotificationService(
             ApplicationDbContext context,
             UserManager<BTUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(ClaimsPrincipal currentUser)
        {
           BTUser user = await _userManager.GetUserAsync(currentUser);

            var userNotifications = _context.Notifications.Where(n => n.RecipientId == user.Id).Include(n => n.Sender);
            var unreadNotifications = await userNotifications.Where(n => !n.Viewed).ToListAsync();

            //var undreadNotifications = _context.Notifications.Where(n => n.RecipientId == user.Id && !n.Viewed).ToList();

            return unreadNotifications;
        }
    }
}
