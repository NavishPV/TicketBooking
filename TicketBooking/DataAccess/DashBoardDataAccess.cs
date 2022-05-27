using System.Data.SqlClient;
using TicketBooking.Helpers;
using TicketBooking.Models;

namespace TicketBooking.DataAccess
{
    public class DashBoardDataAccess
    {
        
        public string ErrorMessage { get; set; }

        public DashBoardDataAccess()
        {
            ErrorMessage = "";
        }
        
        public DashBoardModels GetAll()
        {
            try
            {

                var db = new DashBoardModels();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "select count(*) as CustomerId from Customer; select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))

                    {
                        db.CustomerCount = Convert.ToInt32(cmd.ExecuteScalar());


                    }
                   
                    sqlStmt = "select count(*) as BusCount from Bus";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.BusCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    sqlStmt = "select count(*) as TicketsCount from Tickets";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.TicketsCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                }





                return db;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





    }
}

