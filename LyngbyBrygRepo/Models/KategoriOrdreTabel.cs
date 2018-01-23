using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyngbyBrygRepo.Models
{
    public class KategoriOrdreTabel
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public int OrdreDetaljerID { get; set; }
    }
}
