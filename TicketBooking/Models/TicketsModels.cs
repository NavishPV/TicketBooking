namespace TicketBooking.Models
{
    public class TicketsModels
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }


        public int BusId { get; set; }


        public DateTime JourneyDate { get; set; }

        public string Num_Of_Seats { get; set; }

        public string Status { get; set; }




        public TicketsModels()
        {

            Id = 0;
            CustomerId = 0;
            BusId = 0;
            JourneyDate= DateTime.Now;
            Num_Of_Seats = "";
            Status = "";


        }

    }
}





