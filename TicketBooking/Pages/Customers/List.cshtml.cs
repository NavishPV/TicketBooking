using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Customers
{
    public class ListModel : PageModel
    {

        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public List<CustomerModels> CustomerList { get; set; }


        public ListModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            CustomerList = new List<CustomerModels>();

        }
        public void OnGet()
        {


            var customerData = new CustomerDataAccess();
            CustomerList = customerData.GetAll();


        }
       
    }
}



