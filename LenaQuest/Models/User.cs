using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.Models
{
    public class User: IdentityUser
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public int QuestExpiriencs { get; set; }
    }
}
