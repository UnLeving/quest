using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.ViewModels
{
    public class EditUserViewModel
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public int QuestExpirience { get; set; }
    }
}
