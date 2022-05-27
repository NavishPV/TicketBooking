using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DashBoardModels Dashboard { get; set; }


        public string ErrorMessage { get; set; }

        [FromQuery(Name = "action")]
        public string Action { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Dashboard = new DashBoardModels();
        }



        public void OnGet()
        {
            DashBoardModels dashboard = new DashBoardModels();
            if (!String.IsNullOrEmpty(Action) && Action.ToLower() == "logout")
            {
                Logout();
                return;
            }

            var d = new DashBoardDataAccess();
            Dashboard = d.GetAll();



        }



        public void OnPost()

        {
            Logout();
        }

        private void Logout()
        {
            HttpContext.SignOutAsync();
            Response.Redirect("/Index");
        }






    }


}
