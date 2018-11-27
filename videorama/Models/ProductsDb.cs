﻿using System;
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
            cmd.Parameters.AddWithValue("@ReleaseDate", product.ReleaseDate);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
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
        public List<Tuple<Product, Type>> GetProductsByType(int type)
        {
            connection();
            List<Tuple<Product, Type>> productsList = new List<Tuple<Product, Type>>();

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
                    new Tuple<Product, Type>(new Product
                    {
                        IdProduct = Convert.ToInt32(dr["IdProduct"]),
                        Title = Convert.ToString(dr["Title"]),
                        ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        Picture = Convert.ToString(dr["Picture"]) == "" ? 
                        Convert.ToString("/Content/Images/visuel_non_disponible.jpeg"): Convert.ToString(dr["Picture"]),
                        IdType = Convert.ToInt32(dr["IdTYpe"])
                    }, new Type
                    {
                        IdType = Convert.ToInt32(dr["IdType"]),
                        TypeName = Convert.ToString(dr["TypeName"]),
                    }));
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

        // ********** VIEW PRODUCT MORE IMPORTANT INFO BY HIS TYPE ********************
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
                        Price = Convert.ToDouble(dr["Price"])
                    });
            }
            return productsList;
        }
        
        // ********** VIEW ALL PRODUCT DETAILS BY HIS ID ********************
        public Tuple<Product, List<Person>> GetProductsDetail(int id)
        {
            connection();
            Product product = new Product();
            List<Person> personList = new List<Person>();
            Tuple<Product, List<Person>> tuple = new Tuple<Product, List<Person>>(null, null);

            SqlCommand cmd = new SqlCommand("GetProductDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProduct", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    personList.Add(new Person
                    {
                        FirstName = Convert.ToString(dr["Firstname"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Profession = new Profession
                        {
                            Title = Convert.ToString(dr["ProfessionTitle"])
                        }
                    });

                    tuple = new Tuple<Product, List<Person>>(
                        new Product
                        {
                            IdProduct = Convert.ToInt32(dr["IdProduct"]),
                            Title = Convert.ToString(dr["ProductTitle"]),
                            Picture = Convert.ToString(dr["Picture"]),
                            Synopsis = Convert.ToString(dr["Synopsis"]),
                            ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                            Price = Convert.ToDouble(dr["Price"]),
                            Stock = Convert.ToInt32(dr["Stock"])
                        },
                        personList
                    );
                }
                

                return tuple;
                  
            }
                
            
            return null;
        }
    }
}