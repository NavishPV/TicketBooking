using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Tickets
{
    public class EditModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        [BindProperty]
        [Display(Name = "Customer")]
        [Required]
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



        [BindProperty]
        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }





        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public EditModel()
        {
            SelectedCustomerId = 0;
            SelectedBusId = 0;
            JourneyDate = DateTime.Now;
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
                    Text = $"{g.FirstName} - {g.LastName} - {g.Mobile}",

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
        public void OnGet(int id )
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var customerData = new TicketsDataAccess();
            var emp = customerData.GetById(id);

            if (emp != null)
            {
                SelectedCustomerId = emp.CustomerId;
                SelectedBusId = emp.BusId;
                JourneyDate = emp.JourneyDate;
                Num_Of_Seats = emp.Num_Of_Seats;
                Status = emp.Status;
               

            }

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

                CustomerId = SelectedCustomerId,
                BusId = SelectedBusId,
                JourneyDate = JourneyDate,
                Num_Of_Seats = Num_Of_Seats,
                Status = Status


            };

            var uptickets = ticketdata.Update(newtickets);

            if (uptickets != null && uptickets.Id > 0)
            {
                SuccessMessage = $"Successfully Updated Customer{uptickets.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Oh Snap! Add Falied. Please Try Again";
            }

        }
    }
}