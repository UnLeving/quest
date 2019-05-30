﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public int QuestExpirience { get; set; }
        public string QuestDetails { get; set; }
    }
}
