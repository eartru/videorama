using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Videorama.Models
{
    public class ProductsDb
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["VideoramaDb"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW PRODUCT *********************
        public bool AddProduct(Product product)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", product.Title);
            cmd.Parameters.AddWithValue("@Synopsis", product.Synopsis);
            string prix = product.Price.ToString().Replace(',', '.');
            cmd.Parameters.AddWithValue("@Price", prix);
            cmd.Parameters.AddWithValue("@IdType", product.TypeP.IdType);
            cmd.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);
            cmd.Parameters.AddWithValue("@Picture", product.Picture);


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

        // ********** VIEW ALL PRODUCTS FOR ADMIN ********************
        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetAllProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
                        Stock = Convert.ToInt32(dr["Stock"]),
                        TypeP = new Type
                        {
                            IdType = Convert.ToInt32(dr["IdType"]),
                            TypeName = Convert.ToString(dr["TypeName"])
                        }
                    });
            }
            return productsList;
        }

        // ********** VIEW PRODUCT DETAILS BY TYPE ********************
        public List<Product> GetTopNProducts(int nb)
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetTopNProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NbProducts", nb);
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
                        Title = Convert.ToString(dr["Title"])
                    });
            }
            return productsList;
        }

        // ********** VIEW PRODUCT DETAILS BY TYPE ********************
        public List<Product> GetProductsByType(int type)
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetProductsByType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdType", type);
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
                        ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        Picture = Convert.ToString(dr["Picture"]) == "" ? 
                        Convert.ToString("/Content/Images/visuel_non_disponible.jpeg"): Convert.ToString(dr["Picture"]),
                        TypeP = new Type
                        {
                            IdType = Convert.ToInt32(dr["IdType"]),
                            TypeName = Convert.ToString(dr["TypeName"]),
                        }
                    });
            }
            return productsList;
        }

        // ********** VIEW NEW PRODUCTS ********************
        public List<Product> GetNewProducts()
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetNewProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
                        Synopsis = Convert.ToString(dr["Synopsis"]).Substring(0,255),
                        Picture = Convert.ToString(dr["Picture"]) == "" ?
                        Convert.ToString("/Content/Images/visuel_non_disponible.jpeg") : Convert.ToString(dr["Picture"])
                    });
            }
            return productsList;
        }

        // ********** VIEW PRODUCT DETAILS BY TYPE ********************
        public List<Product> SearchProductByNameAndType(int type, string name)
        {
            connection();
            List<Product> productsList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetProductByNameAndType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdType", type);
            cmd.Parameters.AddWithValue("@Name", name);
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
                        ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                        Stock = Convert.ToInt32(dr["Stock"])
                    });
            }
            return productsList;
        }
    }
}