using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class DBContext
    {
        public string ConnectionString { get; set; }

        public DBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<cadastro> GetAllCadastro()
        {
            List<cadastro> list = new List<cadastro>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from usuarios", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new cadastro()
                        {
                            user_email = reader["user_email"].ToString(),
                            user_senha = reader["user_senha"].ToString()
                        });
                    }
                }
                return list;
            }
        }

    }
}
