using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.Models
{
    public class UserProfileContext: DbContext
    {
        public UserProfileContext(DbContextOptions<UserProfileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserProfile> Profiles { get; set; }
    }
}
