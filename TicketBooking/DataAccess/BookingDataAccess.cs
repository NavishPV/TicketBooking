using System.Data.SqlClient;
using TicketBooking.Helpers;
using TicketBooking.Models;

namespace TicketBooking.DataAccess
{
    public class BookingDataAccess
    {
        public string ErrorMessage { get; private set; }



        public List<BookingModels> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<BookingModels> details = new List<BookingModels>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = " select d.FirstName,b.StartLocation,b.EndLocation,c.JourneyDate,c.Num_Of_Seats,b.Cost,c.Status " +
                                    "from[dbo].[category] as a " +
                                    "inner join[dbo].[bus] as b on a.id = b.CategoryId " +
                                    "inner join[dbo].[tickets] as c on b.id = c.busid " +
                                    "inner join[dbo].[customer] as d on c.CustomerId = d.id ";



                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                BookingModels customer = new BookingModels();
                                customer.FirstName = reader.GetString(0);
                                customer.StartLocation = reader.GetString(1);
                                customer.EndLocation = reader.GetString(2);
                                customer.JourneyDate = reader.GetDateTime(3);
                                customer.Num_Of_Seats = reader.GetString(4);
                                customer.Cost = reader.GetInt32(5);
                                customer.Status= reader.GetString(6);
                                details.Add(customer);



                               
                                
                            }
                        }
                    }
                }

                return details;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





    }
}
