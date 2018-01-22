using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyngbyBrygRepo.Models;
using Duser;
using LyngbyBrygRepo;
using System.Data.SqlClient;

namespace LyngbyBrygRepo.Factories
{
    public class KundeFac : AutoFac<KundeTabel>
    {
        public KundeTabel Login(string Navn, string Password)
        {
            string SQL = "SELECT * FROM KundeTabel WHERE Navn=@Navn AND Password=@Password";

            using (SqlCommand cmd = new SqlCommand(SQL, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Navn", Navn);
                cmd.Parameters.AddWithValue("@Password", Password);

                Mapper<KundeTabel> mapper = new Mapper<KundeTabel>();
                SqlDataReader reader = cmd.ExecuteReader();

                KundeTabel kunde = new KundeTabel();

                if (reader.Read())
                {
                    kunde = mapper.Map(reader);
                }

                reader.Close();
                cmd.Connection.Close();

                return kunde;
            }
        }
    }
}
