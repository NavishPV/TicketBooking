using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TicketBooking.DataAccess;
using TicketBooking.Models;

namespace TicketBooking.Pages.Bus
{
    public class EditModel : PageModel
    {



        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "DriverName")]
        [Required]
        public string DriverName { get; set; }


        [BindProperty]
        [Display(Name = "Category")]
        [Required]
        public int SelectedCategoryId { get; set; }
        [BindProperty]
        public List<SelectListItem> CategoryList { get; set; }


        [BindProperty]
        [Display(Name = "V_Number")]
        [Required]
        public string V_Number { get; set; }

        [BindProperty]
        [Display(Name = "StartLocation")]
        [Required]
        public string StartLocation { get; set; }

        [BindProperty]

        public List<SelectListItem> StartLocations { get; set; }



        [BindProperty]
        [Display(Name = "EndLocation")]
        [Required]
        public string EndLocation { get; set; }

        [BindProperty]

        public List<SelectListItem> EndLocations { get; set; }


        [BindProperty]
        [Display(Name = "Cost")]
        [Required]
        public int Cost { get; set; }




        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public EditModel()
        {
            DriverName = "";
            SelectedCategoryId = 0;
            V_Number = "";
            StartLocation = "";
            EndLocation = "";
            CategoryList = GetCategory();
            Cost = 0;
            StartLocations = GetStartLocations();
            EndLocations = GetEndLocations();
        }



        private List<SelectListItem> GetStartLocations()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            selectItems.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            selectItems.Add(new SelectListItem { Text = "Hosur", Value = "Hosur" });
            selectItems.Add(new SelectListItem { Text = "Dharmapuri", Value = "Dharmapuri" });
            selectItems.Add(new SelectListItem { Text = "Vellore", Value = "Vellore" });
            return selectItems;

        }


        private List<SelectListItem> GetEndLocations()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Erode", Value = "Erode" });
            selectItems.Add(new SelectListItem { Text = "Salem", Value = "Salem" });
            selectItems.Add(new SelectListItem { Text = "Kovai", Value = "Kovai" });
            selectItems.Add(new SelectListItem { Text = "Mysore", Value = "Mysore" });
            selectItems.Add(new SelectListItem { Text = "Goa", Value = "Goa" });
          
            return selectItems;

        }

        private List<SelectListItem> GetCategory()
        {
            var categoryDataAccess = new CategoryDataAccess();
            var category = categoryDataAccess.GetAll();
            var categorylist = new List<SelectListItem>();

            foreach (var g in category)
            {
                categorylist.Add(new SelectListItem
                {
                    Text = g.BusType,
                    Value = g.Id.ToString()
                });
            }

            return categorylist;
        }

        public void OnGet(int id)
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var busData = new BusDataAccess();
            var emp = busData.GetById(id);

            if (emp != null)
            {
                DriverName = emp.DriverName;
                SelectedCategoryId = emp.CategoryId;
                V_Number = emp.V_Number;
                StartLocation = emp.StartLocation;
                EndLocation = emp.EndLocation;
                Cost = emp.Cost;
            


            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {

            StartLocations = GetStartLocations();
            EndLocations = GetEndLocations();
            CategoryList = GetCategory();

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }


            //Data Access
            var buscategory = new BusDataAccess();
            var newbus = new BusModels()
            {
                Id = Id,
                DriverName = DriverName,
                CategoryId = SelectedCategoryId,
                V_Number = V_Number,
                StartLocation = StartLocation,
                EndLocation = EndLocation,
                Cost = Cost



            };
            var updatebus = buscategory.Update(newbus);

            if (updatebus != null && updatebus.Id > 0)
            {
                SuccessMessage = $"Successfully Updated Customer{updatebus.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Oh Snap! Add Falied. Please Try Again";
            }

        }
    }
}