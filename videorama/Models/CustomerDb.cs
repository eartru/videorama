using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Videorama.Models;
using System.Collections.Generic;
using System;
using videorama.ViewModels;

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

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Get customer by this id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer</returns>
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

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List<Customer></returns>
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

        /// <summary>
        /// Get the detail of a specific customer
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns>Customer</returns>
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

        /// <summary>
        /// Update a specific customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
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
            cmd.Parameters.AddWithValue("@UserName", customer.Username);
            
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

        /// <summary>
        /// Update the password of a specific customer
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns>bool</returns>
        public bool UpdateCustomerPasword(PasswordViewModel passwordViewModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateUserPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", passwordViewModel.IdUser);
            cmd.Parameters.AddWithValue("@Password", passwordViewModel.Password);

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

        /// <summary>
        /// Remove specific customer
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns>bool</returns>
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