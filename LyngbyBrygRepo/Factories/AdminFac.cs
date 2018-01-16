using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;
using System.Data.SqlClient;

namespace LyngbyBrygRepo.Factories
{
    public class AdminFac
    {

        public AdminTabel Login(string Navn, string Password)
        {
            string SQL = "SELECT * FROM AdminTabel WHERE Navn=@Navn AND Password=@Password";

            using (SqlCommand cmd = new SqlCommand(SQL, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Navn", Navn);
                cmd.Parameters.AddWithValue("@Password", Password);

                Mapper<AdminTabel> mapper = new Mapper<AdminTabel>();
                SqlDataReader reader = cmd.ExecuteReader();

                AdminTabel user = new AdminTabel();

                if (reader.Read())
                {
                    user = mapper.Map(reader);
                }

                reader.Close();
                cmd.Connection.Close();

                return user;
            }
        }
    }
}
