namespace TicketBooking.Models
{
    public class BusModels
    {
        public int Id { get; set; }


        public string DriverName { get; set; }


        public string V_Number { get; set; }


        public string StartLocation { get; set; }



        public string EndLocation { get; set; }



        public int CategoryId { get; set; }


       

        public int Cost { get; set; }



        public BusModels()
        {
            Id = 0;
            CategoryId = 0;
            DriverName = "";
            V_Number = "";
            StartLocation = "";
            EndLocation = "";
            Cost = 0;
        }

        public bool IsValid()
        {
            if (DriverName == null || DriverName.Trim() == "" || DriverName.Trim().Length > 30)
            {
                return false;
            }

            if (V_Number == null || V_Number.Trim() == "" || V_Number.Trim().Length > 30)
            {
                return false;
            }

            if (StartLocation == null || StartLocation.Trim() == "" || StartLocation.Trim().Length > 30)
            {
                return false;
            }


            if (StartLocation == null || StartLocation.Trim() == "" || StartLocation.Trim().Length > 30)
            {
                return false;
            }

            if (EndLocation == null || EndLocation.Trim() == "" || EndLocation.Trim().Length > 30)
            {
                return false;
            }

            if (CategoryId == 0)
            {
                return false;
            }

            if (Cost == 0)
            {
                return false;
            }


            return true;



        }
    }
}
