using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Tickets
{
    public class ListModel : PageModel
    {

        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public List<TicketsModels> TicketList { get; set; }


        public ListModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            TicketList = new List<TicketsModels>();

        }
        public void OnGet()
        {


            var customerData = new TicketsDataAccess();
            TicketList = customerData.GetAll();


        }

    }
}

