using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace TicketBooking.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel()
        {
            Username = "";
            Password = "";
            ErrorMessage = "";
        }
        public void OnGet()
        {
        }

        public async void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Login or Password";
                return;
            }

            if (Username == "user1" && Password == "123456")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim ("UserId", "1"),
                    new Claim (ClaimTypes.Name, "User 1"),
                    new Claim (ClaimTypes.Role, "User")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                Response.Redirect("/Index");
                return;
            }


            if (Username == "Admin" && Password == "1234")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim ("UserId", "1"),
                    new Claim (ClaimTypes.Name, "Admin"),
                    new Claim (ClaimTypes.Role, "Admin")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                Response.Redirect("/Index");
                return;
            }

            ErrorMessage = "Invalid Login or Password";
        }
    }
}
