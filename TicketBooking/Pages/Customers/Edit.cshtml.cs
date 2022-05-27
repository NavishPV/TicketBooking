using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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

        public EditModel()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Mobile = "";
            City = "";
            State = "";
            Password = "123456";
        }
        public void OnGet(int id)
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var customerData = new CustomerDataAccess();
            var emp = customerData.GetById(id);

            if (emp != null)
            {
                FirstName = emp.FirstName;
                LastName = emp.LastName;
                Email = emp.Email;
                Mobile = emp.Mobile;
                City = emp.City;
                State = emp.State;
                Password=emp.Password;
                
            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }


        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please Try again";
                return;

            }


            var customerData = new CustomerDataAccess();
            var newcustomer = new CustomerModels
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email =Email,
                Mobile = Mobile,
                City= City,
                State = State,
                Password = Password,
               
            };

            var updateCustomer = customerData.Update(newcustomer);

            if (updateCustomer != null && updateCustomer.Id > 0)
            {
                SuccessMessage = $"Successfully Updated Customer{updateCustomer.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Oh Snap! Add Falied. Please Try Again";
            }

        }
    }
}
