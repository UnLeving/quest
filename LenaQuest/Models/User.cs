﻿using Microsoft.AspNetCore.Identity;

namespace LenaQuest.Models
{
    public class User: IdentityUser
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public int QuestExpirience { get; set; }
        public string QuestDetails { get; set; }
    }
}
