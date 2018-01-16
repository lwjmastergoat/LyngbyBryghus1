using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;    

namespace LyngbyBrygRepo
{
    public class KundeTabel
    {
        public int ID { get; set; }

        public string Navn { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public int Abonnent { get; set; }

        public string Adresse { get; set; }

        public int PostNummer { get; set; }

        public string ByNavn { get; set; }

        public int Mobil { get; set; }
    }
}
