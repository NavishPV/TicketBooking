namespace TicketBooking.Models
{
    public class RoutesModels
    {

        public String StartLocation { get; set; }

        public String EndLocation { get; set; }

        public DateTime JourneyDate { get; set; }


        public string Num_Of_Seats { get; set; }




        public RoutesModels()
        {

            StartLocation = "";
            EndLocation = "";
            JourneyDate = DateTime.Now;
            Num_Of_Seats = "";



        }




    }
}
