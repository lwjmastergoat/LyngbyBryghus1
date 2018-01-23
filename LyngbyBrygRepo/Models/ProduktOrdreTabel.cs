using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyngbyBrygRepo.Models
{
    public class ProduktOrdreTabel
    {
        public int ID { get; set; }
        public int ProduktID { get; set; }
        public int OrdreDetaljerID { get; set; }
    }
}
