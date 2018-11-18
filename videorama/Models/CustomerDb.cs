using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Videorama.Models;

namespace videorama.Models
{
    public class CustomerDb
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["VideoramaDb"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW CUSTORMER *********************
        public bool AddCustomer(Customer customer)
        {
            connection();
            SqlCommand cmd = new SqlCommand("PutCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FristName", customer.FirstName);
            cmd.Parameters.AddWithValue("@Name", customer.LastName);
            cmd.Parameters.AddWithValue("@Password", customer.Password);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Adress", customer.Address);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Town", customer.Town);
            cmd.Parameters.AddWithValue("@Country", customer.Country);

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }

            

        }
        
        
    }
}