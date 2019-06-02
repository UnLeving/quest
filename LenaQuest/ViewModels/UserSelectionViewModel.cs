using System.Collections.Generic;
using System.Linq;

namespace LenaQuest.ViewModels
{
    public class UserSelectionViewModel
    {
        public List<SelectedUserEditorViewModel> Users { get; set; }

        public UserSelectionViewModel()
        {
            Users = new List<SelectedUserEditorViewModel>();
        }

        public IEnumerable<string> GetSelectedUsersEmails()
        {
            return (from user in this.Users where user.isSelected select user.Email).ToList();
        }
    }
}