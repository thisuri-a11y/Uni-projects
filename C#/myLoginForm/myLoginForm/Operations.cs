using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace myLoginForm
{
    internal class Operations
    {
        DbConnect obj = new DbConnect();

        //public Operation() { }

        public bool checkConnection()
        {
            {
                try
                {
                    MySqlConnection connection = obj.GetConnection();
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (Exception) { return false; }
            }
        }

        public bool validUser(User user)
        {
            string sql = "SELECT COUNT(*) FROM userr WHERE username = @username";

            using (var con = obj.GetConnection())
            {
                con.Open();

                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", user.username);

                    object result = cmd.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    return count == 0;
                }
            }
        }

        public bool addUser(User user)
        {
            string sql = $"INSERT INTO userr (firstname,lastname,username,password) VALUES ('{user.firstname}','{user.lastname}','{user.username}','{user.password}')";
            var con = obj.GetConnection();
            con.Open();

            var cmd = new MySqlCommand(sql, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool login(User user)
        {
            string sql = $"SELECT COUNT(*) FROM userr WHERE username='{user.username}' AND password='{user.password}'";
            
            using (var con = obj.GetConnection())
            {
                con.Open();

                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count == 1;
                }
            }

        }

        /* public User viewU(string username) {
             string sql = $"SELECT * FROM userr WHERE username='{username}'";
             User user = null;
             var con = obj.GetConnection();
                 con.Open();   

                 using (MySqlCommand cmd = new MySqlCommand(sql, con)) {
                     using (MySqlDataReader reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             user = new User()
                             {
                                 firstname = reader.GetString("firstname"),
                                 lastname = reader.GetString("lastname"),
                                 username = reader.GetString("username"),
                                 password = reader.GetString("password")
                             };
                         }
                     }
                 }
                 return user;
             } */
        public User view(string username)
        {
            string sql = $"SELECT * FROM userr WHERE  username ='{username}'";
            User user = null;
            var con = obj.GetConnection();
            con.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, con)) {
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            firstname = reader.GetString("firstname"),
                            lastname = reader.GetString("lastname"),
                            username = reader.GetString("username"),
                            password = reader.GetString("password")
                        };
                    }
                }
            }
            return user;
        }

        public bool deleteUser(string username)
        {
            string sql = $"DELETE FROM userr WHERE username = '{username}'";

            using (var con = obj.GetConnection())
            {
                con.Open();

                using (var cmd = new MySqlCommand(sql, con))
                {
                    int rowsEffected = cmd.ExecuteNonQuery();

                    if (rowsEffected > 0)
                    {
                        MessageBox.Show($"Deleted {rowsEffected} Records");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"No data Removed");
                        return false;
                    }
                }
            }
        }

        public bool updateUser(string username, string newUseName)
        {
            string sql = $"UPDATE userr set username = '{newUseName}' WHERE username = '{username}'";

            using (var con = obj.GetConnection())
            {

                con.Open();
                using (var cmd = new MySqlCommand(sql, con))
                {

                    int updated = cmd.ExecuteNonQuery();

                    if (updated != 0)
                    {
                        MessageBox.Show($"Updated {username} to {newUseName}");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User Dosen't Exist");
                        return false;
                    }
                }
            }
        }
    }
}

