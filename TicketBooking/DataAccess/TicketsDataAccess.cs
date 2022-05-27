using System.Data.SqlClient;
using TicketBooking.Helpers;
using TicketBooking.Models;

namespace TicketBooking.DataAccess
{
    public class TicketsDataAccess
    {

        public string ErrorMessage { get; private set; }



        public List<TicketsModels> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<TicketsModels> details = new List<TicketsModels>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id,CustomerId,BusId,JourneyDate,Num_Of_Seats,Status from dbo.Tickets where CustomerId = 1";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TicketsModels tickets = new TicketsModels();
                                tickets.Id = reader.GetInt32(0);
                                tickets.CustomerId= reader.GetInt32(1);
                                tickets.BusId= reader.GetInt32(2);
                                tickets.JourneyDate=reader.GetDateTime(3);
                                tickets.Num_Of_Seats=reader.GetString(4);
                                tickets.Status=reader.GetString(5);
                                
                                details.Add(tickets);
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

        public TicketsModels GetById(int id)
        {
            try
            {
                TicketsModels tickets = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id,CustomerId,BusId,JourneyDate,Num_Of_Seats,Status from dbo.Tickets from dbo.Tickets where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                tickets = new TicketsModels();
                                tickets.Id = reader.GetInt32(0);
                                tickets.CustomerId = reader.GetInt32(1);
                                tickets.BusId = reader.GetInt32(2);
                                tickets.JourneyDate = reader.GetDateTime(3);
                                tickets.Num_Of_Seats = reader.GetString(4);
                                tickets.Status = reader.GetString(5);

                            }
                        }
                    }
                }

                return tickets;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


        public TicketsModels Insert(TicketsModels newTickets)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Helpers.Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Tickets (CustomerId,BusId,JourneyDate,Num_Of_Seats,Status ) VALUES ('{newTickets.CustomerId}', " +
                        $" '{newTickets.BusId}', '{newTickets.JourneyDate.ToString("yyyy-MM-dd")}', '{newTickets.Num_Of_Seats}', '{newTickets.Status}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newTickets.Id = idInserted;
                            return newTickets;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return null;
            }
        }

        public TicketsModels Update(TicketsModels upTickets)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Tickets SET CustomerId = '{upTickets.CustomerId}', " +
                        $"BusId = '{upTickets.BusId}'," +
                        $"JourneyDate = '{upTickets.JourneyDate.ToString("yyyy-MM-dd")}'," +
                        $"Num_Of_Seats = '{upTickets.Num_Of_Seats}'," +
                        $"Status = '{upTickets.Status}'" +
                  
                        $"where Id = {upTickets.Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return upTickets;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }

    }
}
