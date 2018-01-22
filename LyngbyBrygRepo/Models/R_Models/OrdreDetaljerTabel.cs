using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using LyngbyBrygRepo.Models;

namespace LyngbyBrygRepo.Models.R_Models
{
    public class OrdreDetaljerTabel
    {
        public int ID { get; set; }
        public List<int> ProduktID { get; set; }

        public string Navn { get; set; }

        public List<int> KategoriID { get; set; }

        public List<int> AbonnementID { get; set; }



    }
}
