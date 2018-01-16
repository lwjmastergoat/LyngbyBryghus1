using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;

namespace LyngbyBrygRepo
{
    public class OrdreDetaljerTabel
    {
        public int ID { get; set; }
        public int ProduktID { get; set; }
        public int Antal { get; set; }
        public int BrugerID { get; set; }
        public int KategoriID { get; set; }
        public DateTime Dato { get; set; }
        public int OrdreID { get; set; }
    }
}
