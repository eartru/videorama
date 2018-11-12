using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
        public List<Product> GetRentByCustomer(int idCustomer)
        {
            connection();
            List<Product> rentsList = new List<Product>();

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
                    new Product
                    {
                        Title = Convert.ToString(dr["Title"])
                    });
            }
            return rentsList;
        }
    }
}