


using System.Data.SqlClient;
using TicketBooking.Helpers;
using TicketBooking.Models;

namespace TicketBooking.DataAccess
{
    public class BusDataAccess
    {

        public string ErrorMessage { get; private set; }



        public List<BusModels> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<BusModels> details = new List<BusModels>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id,CategoryId,DriverName,V_Number,StartLocation,EndLocation,Cost from dbo.Bus";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                BusModels bus = new BusModels();
                                bus.Id = reader.GetInt32(0);
                                bus.CategoryId = reader.GetInt32(1);
                                bus.DriverName = reader.GetString(2);
                                bus.V_Number = reader.GetString(3);
                                bus.StartLocation = reader.GetString(4);
                                bus.EndLocation = reader.GetString(5);
                                bus.Cost = reader.GetInt32(6);
                                details.Add(bus);
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

        public BusModels GetById(int id)
        {
            try
            {
                BusModels bus = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, CategoryId, DriverName, V_Number,StartLocation,EndLocation,Cost from dbo.Bus where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                bus = new BusModels();
                                bus.Id = reader.GetInt32(0);
                                bus.CategoryId = reader.GetInt32(1);
                                bus.DriverName = reader.GetString(2);
                                bus.V_Number = reader.GetString(3);
                                bus.StartLocation = reader.GetString(4);
                                bus.EndLocation = reader.GetString(5);
                                bus.Cost = reader.GetInt32(6);
                               
                            }
                        }
                    }
                }

                return bus;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        public BusModels Insert(BusModels newbus)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Helpers.Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Bus (DriverName, CategoryId, V_Number, StartLocation, EndLocation, Cost ) VALUES ('{newbus.DriverName}', " +
                        $" {newbus.CategoryId}, '{newbus.V_Number}', '{newbus.StartLocation}', '{newbus.EndLocation}',{newbus.Cost}); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newbus.Id = idInserted;
                            return newbus;
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
        public BusModels Update(BusModels upbus)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Bus SET DriverName = '{upbus.DriverName}', " +
                        $" CategoryId = {upbus.CategoryId}," +
                        $" V_Number = '{upbus.V_Number}'," +
                        $" StartLocation = '{upbus.StartLocation}'," +
                        $" EndLocation = '{upbus.EndLocation}'," +
                        $" Cost = {upbus.Cost} " +
                        $" where Id = {upbus.Id} ";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return upbus;
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

        public int Delete(int id)
        {
            try
            {
                ErrorMessage = String.Empty;
                int numOfRows = 0;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM Tickets  Where Id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        numOfRows = cmd.ExecuteNonQuery();
                    }
                }
                return numOfRows;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return 0;
            }
        }
    }
}
