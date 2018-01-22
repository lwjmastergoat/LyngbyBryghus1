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
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<int> KategoriID { get; set; }

        public bool AbonnementID { get; set; }



    }
}
