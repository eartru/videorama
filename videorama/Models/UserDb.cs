using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Videorama.Models;

namespace videorama.Models
{
    public class UserDb
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["VideoramaDb"].ToString();
            con = new SqlConnection(constring);
        }

        /// <summary>
        /// Check existing user by userName and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>User</returns>
        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            connection();

            User userFound = new User();
            SqlCommand cmd = new SqlCommand("GetUserByUserNameAndPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userFound.IdUser = Convert.ToInt32(dr["IdUser"]);
                userFound.Username = dr["Username"].ToString();
                userFound.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
            }

            return userFound;
        }
        
        /// <summary>
        /// Check existing user by userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User</returns>
        public User GetUserByUserName(string userName)
        {
            connection();

            User userFound = new User();
            SqlCommand cmd = new SqlCommand("GetUserByUserName", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", userName);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userFound.IdUser = Convert.ToInt32(dr["IdUser"]);
                userFound.Username = dr["Username"].ToString();
                userFound.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
            }

            return userFound;
        }

        /// <summary>
        /// Check existing user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        public User GetUserByEmail(string email)
        {
            connection();

            User userFound = new User();
            SqlCommand cmd = new SqlCommand("GetUserByEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userFound.IdUser = Convert.ToInt32(dr["IdUser"]);
                userFound.Username = dr["Username"].ToString();
                userFound.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
            }

            return userFound;
        }
    }
}