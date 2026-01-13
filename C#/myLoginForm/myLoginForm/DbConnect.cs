using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace myLoginForm
{
    internal class DbConnect
    {
        private string conString = "Server = Localhost; database = userdb; Uid = root ";


        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(conString);

            }
        }
}
