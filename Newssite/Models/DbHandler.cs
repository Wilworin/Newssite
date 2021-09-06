using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Newssite.Pages
{
    /// <summary>
    /// This class handles all access to the database.
    /// </summary>
    public class DbHandler
    {
        /// <summary>
        /// Loads all news from the database.
        /// </summary>
        /// <returns></returns>
        public List<News> GetNewsFromDb()
        {
            List<News> NewsList = new();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Newssite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = "SELECT * FROM News ORDER BY Posted DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NewsList.Add(new News(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4)));
                                //Console.WriteLine("{0} {1}", reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return NewsList;
        }

        /// <summary>
        /// Saves the supplied News to the database
        /// </summary>
        /// <param name="header"></param>
        /// <param name="newstext"></param>
        /// <param name="posted"></param>
        /// <param name="poster"></param>
        public void SaveNewsToDb(string header, string newstext, DateTime posted, string poster)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Newssite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = $"INSERT INTO News ([Header], [NewsText], [Posted], [Poster]) VALUES ('{ header}', '{ newstext}', '{ posted}', '{ poster}')";
            Console.WriteLine(queryString);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Checks the database if there exist a user with the supplied userName and passWord.  
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns>true or false</returns>
        public bool CheckIfUser(string userName, string passWord)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Newssite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = $"SELECT * FROM [User] WHERE UserName = '{userName}' AND PassWord = '{passWord}'";

            bool isUserVerified = false;

            Console.WriteLine(queryString);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isUserVerified = reader.HasRows;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return isUserVerified;
        }
    }
}
