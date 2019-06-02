using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.ViewModels
{
    public class SelectedUserEditorViewModel
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int QuestExpirience { get; set; }
        public bool isSelected { get; set; }
    }
}
