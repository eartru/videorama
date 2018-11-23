using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Videorama.Models;
using System.Collections.Generic;
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
            SqlCommand cmd = new SqlCommand("GetCustomerDetail", con);
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

        public List<Customer> GetCustomers()
        {
            connection();
            List<Customer> customersList = new List<Customer>();

            SqlCommand cmd = new SqlCommand("GetCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                customersList.Add(
                    new Customer
                    {
                        IdUser = Convert.ToInt32(dr["IdUser"]),
                        FirstName = Convert.ToString(dr["Firstname"]),
                        LastName = Convert.ToString(dr["Lastname"]),
                        Address = Convert.ToString(dr["AddressCustomer"]),
                        PostalCode = Convert.ToString(dr["PostalCode"]),
                        Town = Convert.ToString(dr["Town"]),
                        Country = Convert.ToString(dr["Country"]),
                        Email = Convert.ToString(dr["Email"])
                    });
            }
            return customersList;
        }

        public Customer GetCustomerDetail(int idCustomer)
        {
            connection();
            Customer customer = new Customer();

            SqlCommand cmd = new SqlCommand("GetCustomerDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCustomer", idCustomer);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt != null)
            {
                customer = new Customer
                {
                    IdUser = Convert.ToInt32(dt.Rows[0]["IdUser"]),
                    FirstName = Convert.ToString(dt.Rows[0]["Firstname"]),
                    LastName = Convert.ToString(dt.Rows[0]["Lastname"]),
                    Address = Convert.ToString(dt.Rows[0]["AddressCustomer"]),
                    PostalCode = Convert.ToString(dt.Rows[0]["PostalCode"]),
                    Town = Convert.ToString(dt.Rows[0]["Town"]),
                    Country = Convert.ToString(dt.Rows[0]["Country"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"]),
                    Username = Convert.ToString(dt.Rows[0]["Username"])
                };
                return customer;
            }

            return null;
        }

        public bool UpdateCustomer(Customer customer)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCustomer", customer.IdUser);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
            cmd.Parameters.AddWithValue("@Town", customer.Town);
            cmd.Parameters.AddWithValue("@Country", customer.Country);

            if (customer.Username != null)
            {
                cmd.Parameters.AddWithValue("@UserName", customer.Username);
            }

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

        public bool DeleteCustomer(int idCustomer)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCustomer", idCustomer);

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