using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Customers
{
    public class AddModel : PageModel
    {
       
        [BindProperty]
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }


        [BindProperty]
        [Display(Name = "LastName")]
        [Required]
        public string LastName { get; set; }



        [BindProperty]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Display(Name = "Mobile")]
        [Required]
        public string Mobile { get; set; }



        [BindProperty]
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }



        [BindProperty]
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }



        [BindProperty]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }



        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public AddModel()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Mobile = "";
            City = "";
            State = "";
            Password = "123456";
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please Try again";
                return;

            }


            var customerdata = new CustomerDataAccess();
            var newcustomer = new CustomerModels
            {
               
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Mobile = Mobile,
                City = City,
                State = State,
                Password= Password,

            };

            var insertcustomer = customerdata.Insert(newcustomer);

            if (insertcustomer != null && insertcustomer.Id > 0)
            {
                SuccessMessage = $"Successfully inserted Customer{insertcustomer.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Oh Snap! Add Falied. Please Try Again";
            }

        }
    }
}
