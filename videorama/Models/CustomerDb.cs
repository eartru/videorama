using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Videorama.Models;
using System;

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

            cmd.Parameters.AddWithValue("@UserName", customer.Username);
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

        // **************** GET CUSOMER BY THIS ID *********************
        public Customer GetCustomerById(int id)
        {
            connection();

            Customer customerFound = new Customer();
            SqlCommand cmd = new SqlCommand("GetCustomerById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                customerFound.IdUser = Convert.ToInt32(dr["IdUser"]);
                customerFound.Email = dr["Email"].ToString();
                customerFound.Username = dr["Username"].ToString();
                customerFound.FirstName = dr["Firstname"].ToString();
                customerFound.LastName = dr["Lastname"].ToString();
                customerFound.Address = dr["AddressCustomer"].ToString();
                customerFound.PostalCode = dr["PostalCode"].ToString();
                customerFound.Town = dr["Town"].ToString();
                customerFound.Country = dr["Country"].ToString();
            }

            return customerFound;
        }
    }
}