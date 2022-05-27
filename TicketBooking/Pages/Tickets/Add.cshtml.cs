using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Tickets
{
    public class AddModel : PageModel
    {
        //[BindProperty]
        //[Display(Name = "Customer")]
        //[Required]
        public int SelectedCustomerId { get; set; }
        [BindProperty]
        public List<SelectListItem> CustomerList { get; set; }


        [BindProperty]
        [Display(Name = "Bus")]
        [Required]
       
        public int SelectedBusId { get; set; }
        [BindProperty]
        public List<SelectListItem> BusList { get; set; }


        [BindProperty]
        [Display(Name = "JourneyDate")]
        [Required]
        public DateTime JourneyDate { get; set; }

        [BindProperty]
        [Display(Name = "NumOfSeats")]
        [Required]
        public string Num_Of_Seats { get; set; }



        //[BindProperty]
        //[Display(Name = "Status")]
        //[Required]
        public string Status { get; set; }





        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public AddModel()
        {
            SelectedCustomerId=0;
            SelectedBusId = 0;
            JourneyDate =DateTime.Now;
            Num_Of_Seats = "";
            Status = "";
            CustomerList = GetCustomer();
            BusList = GetBus();




        }

        private List<SelectListItem> GetCustomer()
        {
            var customerDataaccess = new CustomerDataAccess();
            var customer = customerDataaccess.GetAll();
            var customerlist = new List<SelectListItem>();

            foreach (var g in customer)
            {
                customerlist.Add(new SelectListItem
                {
                    Text = $"{ g.FirstName} - {g.LastName} - {g.Mobile}",

                    Value = g.Id.ToString()
                });
            }

            return customerlist;
        }


        private List<SelectListItem> GetBus()
        {
            var busDataAccess = new BusDataAccess();
            var bus = busDataAccess.GetAll();
            var buslist = new List<SelectListItem>();

            foreach (var g in bus)
            {
                buslist.Add(new SelectListItem
                {
                    Text = $"{g.DriverName} - {g.V_Number} - {g.StartLocation} - {g.EndLocation}",

                    Value = g.Id.ToString()
                });
            }

            return buslist;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {

            CustomerList = GetCustomer();
            BusList = GetBus();

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please Try again";
                return;

            }


            var ticketdata = new TicketsDataAccess();
            var newtickets = new TicketsModels
            {

                //CustomerId = SelectedCustomerId,
                CustomerId = 1,
                BusId = SelectedBusId,
                JourneyDate = JourneyDate,
                Num_Of_Seats = Num_Of_Seats,
                Status = "Booked"
                

            };

            var insertTickets = ticketdata.Insert(newtickets);

            if (insertTickets != null && insertTickets.Id > 0)
            {
                SuccessMessage = $"Successfully inserted Customer{insertTickets.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Oh Snap! Add Falied. Please Try Again";
            }

        }
    }
}
