using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int QuestExpiriencs { get; set; }
    }
}
