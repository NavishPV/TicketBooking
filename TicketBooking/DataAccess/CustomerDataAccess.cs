using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TicketBooking.Models;
using TicketBooking.Helpers;

namespace TicketBooking.DataAccess
{
    public class CustomerDataAccess
    {
        public string ErrorMessage { get; private set; }
        

       
        public List<CustomerModels> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<CustomerModels> details = new List<CustomerModels>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id,FirstName,LastName,Email,Mobile,City,State,Password from dbo.Customer";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CustomerModels customer = new CustomerModels();
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Email = reader.GetString(3);
                                customer.Mobile = reader.GetString(4);
                                customer.City = reader.GetString(5);
                                customer.State = reader.GetString(6);
                                customer.Password = reader.GetString(7);
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

        public CustomerModels GetById(int id)
        {
            try
            {
                CustomerModels customer = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, FirstName, LastName, Email,Mobile,City,State,Password from dbo.Customer where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                customer = new CustomerModels();
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Email = reader.GetString(3);
                                customer.Mobile = reader.GetString(4);
                                customer.City = reader.GetString(5);
                                customer.State = reader.GetString(6);
                                customer.Password = reader.GetString(7);
                            }
                        }
                    }
                }

                return customer;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


        public CustomerModels Insert(CustomerModels newcustomer)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Helpers.Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Customer (FirstName,LastName, Email, Mobile, City , State,Password ) VALUES ('{newcustomer.FirstName}', " +
                        $" '{newcustomer.LastName}', '{newcustomer.Email}', '{newcustomer.Mobile}', '{newcustomer.City}','{newcustomer.State}','{newcustomer.Password}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newcustomer.Id = idInserted;
                            return newcustomer;
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

         public CustomerModels Update(CustomerModels upcustomer)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Customer SET FirstName = '{upcustomer.FirstName}', " +
                        $"LastName = '{upcustomer.LastName}'," +
                        $"Email = '{upcustomer.Email}'," +
                        $"Mobile = '{upcustomer.Mobile}'," +
                        $"City = '{upcustomer.City}'," +
                        $"State ='{upcustomer.State}',"+
                         $"Password ='{upcustomer.Password}'" +


                        $"where Id = {upcustomer.Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return upcustomer;
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

