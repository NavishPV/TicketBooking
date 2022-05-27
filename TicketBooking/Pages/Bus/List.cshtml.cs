using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Bus
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public List<BusModels> BusList { get; set; }


        public ListModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            BusList = new List<BusModels>();

        }
        public void OnGet()
        {


            var customerData = new BusDataAccess();
            BusList = customerData.GetAll();


        }

    }
}