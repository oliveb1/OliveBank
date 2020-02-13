using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;

namespace OliveBank.sqlHandler
{
    class sqlBasics
    {
        public string constring = "Data Source=LAPTOP-EH8S1KN2\\SQLEXPRESS;Initial Catalog=OliveBank;Integrated Security=True";
       
    }

    class sqlAccountHandlers : sqlBasics
    {
        static byte[] GenerateSaltedHash(byte[] plainText, int size)
        {
            byte[] salt = new byte[size];
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for(int i=0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for(int i=0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        public void CreateUserAccount(string username, string password, string firstName, string lastName, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(constring))
            {
                sqlConnection.Open();
                try
                {
                    byte[] hashedPassed = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), 256);
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO employeeAccount (username, password, firstName, lastName, email) VALUES (@USERNAME, @HASH, @FNAME, @LNAME, @EMAIL)", sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@USERNAME", username);
                        cmd.Parameters.AddWithValue("@HASH", hashedPassed);
                        cmd.Parameters.AddWithValue("@FNAME", firstName);
                        cmd.Parameters.AddWithValue("@LNAME", lastName);
                        cmd.Parameters.AddWithValue("@EMAIL", email);
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("User Created.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                sqlConnection.Close();
            }
        }
    }
}
