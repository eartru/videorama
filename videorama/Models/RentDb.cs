using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using videorama.ViewModels;

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

        // **************** ADD NEW RENT *********************
        public bool AddRent(Rent rent)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@InProgress", rent.InProgress);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
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

        public BillViewModel GetRentDetailsForBill(int idCustomer, int idRent)
        {
            connection();
            BillViewModel rentDetails = new BillViewModel();

            SqlCommand cmd = new SqlCommand("GetRentDetailsForBill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCustomer", idCustomer);
            cmd.Parameters.AddWithValue("@IdRent", idRent);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            rentDetails.Customer = new Customer
            {
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
                RentDate = Convert.ToDateTime(dt.Rows[0]["RentDate"])
            };
            List<Product> listProducts = new List<Product>();

            double total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                listProducts.Add(
                    new Product
                    {
                        Title = Convert.ToString(dr["Title"]),
                        Price = Convert.ToDouble(dr["Price"])
                    }
                );
                total += Convert.ToDouble(dr["Price"]);
            }
            rentDetails.Products = listProducts;
            rentDetails.Total = total;

            return rentDetails;
        }
    }
}