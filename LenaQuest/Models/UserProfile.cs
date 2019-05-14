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
        public string Name { get; set; }
        public string SureName { get; set; }
        public string City { get; set; }
        public int QuestExpiriencs { get; set; }

        public virtual string Email { get; set; }
    }
}
