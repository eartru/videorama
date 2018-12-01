using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using videorama.ViewModels;
using System.Data.SqlTypes;
using System.Security.Claims;
using System.Web.Mvc;

namespace Videorama.Models
{
    public class RentDb
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["VideoramaDb"].ToString();
            con = new SqlConnection(constring);
        }

        // ************** GET ALL RENTS FOR ADMIN *******************
        public List<Tuple<Rent, Customer>> GetRents()
        {
            connection();
            List<Tuple<Rent, Customer>> rentsList = new List<Tuple<Rent, Customer>>();

            SqlCommand cmd = new SqlCommand("GetRents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                rentsList.Add(
                    new Tuple<Rent, Customer>(new Rent
                    {
                        IdRent = Convert.ToInt32(dr["IdRent"]),
                        RentDate = Convert.ToDateTime(dr["RentDate"]),
                        ReturnBackDate = Convert.ToDateTime(dr["ReturnBackDate"])
                    },
                    new Customer
                    {
                        IdUser = Convert.ToInt32(dr["IdCustomer"]),
                        FirstName = Convert.ToString(dr["Firstname"]),
                        LastName = Convert.ToString(dr["Lastname"]),
                    }));
            }
            return rentsList;
        }

        // **************** ADD NEW RENT WiTH PRODUCT *********************
        public bool AddRent(DateTime getRentDate, int idUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> productList)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewRent", con);
            cmd.CommandType = CommandType.StoredProcedure;          

            cmd.Parameters.AddWithValue("@GetDate", getRentDate);
            cmd.Parameters.AddWithValue("@IdCustomer", idUser);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt != null)
            {
                int idNewRent = Convert.ToInt32(dt.Rows[0]["IdRent"]);               

                foreach(var idProduct in productList)
                {
                    if (idProduct.Value != "")
                    {
                        SqlCommand cmd2 = new SqlCommand("AddProductInRent", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@IdRent", idNewRent);
                        cmd2.Parameters.AddWithValue("@IdProduct", Convert.ToInt32(idProduct.Value));

                        con.Open();

                        try
                        {
                            cmd2.ExecuteNonQuery();
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

            return true;
        }

        // ********** VIEW RENTS BY CUSTOMER ********************
        public List<Tuple<Rent, Product>> GetRentByCustomer(int idCustomer)
        {
            connection();
            List<Tuple<Rent, Product>> rentsList = new List<Tuple<Rent, Product>>();

            SqlCommand cmd = new SqlCommand("GetRentByCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCustomer", idCustomer);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                rentsList.Add(
                    new Tuple<Rent, Product>(new Rent
                    {
                        IdRent = Convert.ToInt32(dr["IdRent"]),
                        ReturnBackDate = Convert.ToDateTime(dr["ReturnBackDate"])
                    },
                    new Product
                    {
                        IdProduct = Convert.ToInt32(dr["IdProduct"]),
                        Title = Convert.ToString(dr["Title"]),
                        Picture = Convert.ToString(dr["Picture"]) == "" ?
                        Convert.ToString("/Content/Images/visuel_non_disponible.jpeg") : Convert.ToString(dr["Picture"])
                    }));
            }
            return rentsList;
        }

        public List<Rent> GetDistinctRentByCustomer(int idCustomer)
        {
            connection();
            List<Rent> rentsList = new List<Rent>();

            SqlCommand cmd = new SqlCommand("GetDistinctRentByCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCustomer", idCustomer);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                rentsList.Add(
                    new Rent
                    {
                        IdRent = Convert.ToInt32(dr["IdRent"]),
                        ReturnBackDate = Convert.ToDateTime(dr["ReturnBackDate"])
                    });
            }
            return rentsList;
        }

        public List<Product> GetRentProducts(int idRent)
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetRentProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdRent", idRent);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productsList.Add(
                    new Product
                    {
                        IdProduct = Convert.ToInt32(dr["IdProduct"]),
                        Title = Convert.ToString(dr["Title"]),
                        Picture = Convert.ToString(dr["Picture"]) == "" ?
                        Convert.ToString("/Content/Images/visuel_non_disponible.jpeg") : Convert.ToString(dr["Picture"])
                    });
            }
            return productsList;
        }

        public BillViewModel GetRentDetails(int idRent)
        {
            connection();
            BillViewModel rentDetails = new BillViewModel();

            SqlCommand cmd = new SqlCommand("GetRentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdRent", idRent);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            rentDetails.Customer = new Customer
            {
                IdUser = Convert.ToInt32(dt.Rows[0]["IdCustomer"]),
                LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                Address = Convert.ToString(dt.Rows[0]["AddressCustomer"]),
                PostalCode = Convert.ToString(dt.Rows[0]["PostalCode"]),
                Town = Convert.ToString(dt.Rows[0]["Town"]),
                Country = Convert.ToString(dt.Rows[0]["Country"])
            };
            rentDetails.Rent = new Rent
            {
                IdRent = Convert.ToInt32(dt.Rows[0]["IdRent"]),
                RentDate = Convert.ToDateTime(dt.Rows[0]["RentDate"]),
                ReturnBackDate = Convert.ToDateTime(dt.Rows[0]["ReturnBackDate"])
            };
            List<Product> listProducts = new List<Product>();

            decimal total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                listProducts.Add(
                    new Product
                    {
                        Title = Convert.ToString(dr["Title"]),
                        Price = Convert.ToDecimal(dr["Price"])
                    }
                );
                total += Convert.ToDecimal(dr["Price"]);
            }
            rentDetails.Products = listProducts;
            rentDetails.Total = total;

            return rentDetails;
        }

        public bool UpdateRentReturnedBack(int IdRent)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateRentReturnedBack", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdRent", IdRent);

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