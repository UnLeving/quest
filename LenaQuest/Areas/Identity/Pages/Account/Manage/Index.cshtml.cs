using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LenaQuest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LenaQuest.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserProfileContext _context;
        [BindProperty]
        public UserProfile Profile { get; set; }
        public IndexModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UserProfileContext context)
        {
            _context = context;
            Profile = new UserProfile();
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Display(Name = "Login")]
        public string Username { get; set; }
        //public UserProfile userProfile { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var _profiles = _context.Profiles.Where(p => p.Email == userName);
            Profile = _profiles.FirstOrDefault();

            Username = userName;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
