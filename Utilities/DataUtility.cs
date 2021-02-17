using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace BugTracker.Utilities
{
    public class DataUtility
    {

        public static string GetConnectionString(IConfiguration configuration)
        {
            //The default connection string will come from appSettings like usual
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //It will be automatically overwritten if we are running on Heroku
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        public static string BuildConnectionString(string databaseUrl)
        {
            //Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            //Provides a simple way to create and manage the contents of connection strings used by the NpgsqlConnection class
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }

        public static async Task ManageDataAsync(IHost host)
        {

            // This technique is used to obtain references to services that get registered in 
            // the ConfigureServices method of the Startup class.

            using var svcScope = host.Services.CreateScope();
            var svcProvider = svcScope.ServiceProvider;

            //This dbContextSvc knows how to talk to the DB (aka _context)
            //  Service 1: An instance of ApplicationDbContext
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();

            //Service 2: An instance of RoleManager

            var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Service 3: An instance of UserManager

            var userManagerSvc = svcProvider.GetRequiredService<UserManager<BTUser>>();

            //This is the programmatic equivalent of Update-Database
            await dbContextSvc.Database.MigrateAsync();
        }
    }
}
