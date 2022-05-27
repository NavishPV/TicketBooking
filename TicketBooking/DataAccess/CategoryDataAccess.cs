using System.Data.SqlClient;
using TicketBooking.Helpers;
using TicketBooking.Models;

namespace TicketBooking.DataAccess
{
    public class CategoryDataAccess
    {
        public string ErrorMessage { get; private set; }



        public List<CategoryModels> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<CategoryModels> details = new List<CategoryModels>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id ,BusType from dbo.Category";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CategoryModels category = new CategoryModels();
                                category.Id = reader.GetInt32(0);
                                category.BusType = reader.GetString(1);
                               
                                details.Add(category);
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

         public CategoryModels GetById(int id)
        {
            try
            {
                CategoryModels category = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id,BusType from dbo.Categroy where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                category = new CategoryModels();
                                category.Id = reader.GetInt32(0);
                                category.BusType = reader.GetString(1);
                            }
                        }
                    }
                }

                return category;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }






    }
}
