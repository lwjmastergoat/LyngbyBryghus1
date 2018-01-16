using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;

namespace LyngbyBrygRepo
{
    public class ProduktTabellen
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public string Billede { get; set; }
        public decimal Pris { get; set; }
        public decimal Alkohol { get; set; }
        public int Farve { get; set; }
        public int Bitterhed { get; set; }
        public string Gærtype { get; set; }

    }
}
