using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;

namespace LyngbyBrygRepo.Models
{
    public class Nyhedstabel
    {
        public int ID { get; set; }

        public string Overskrift { get; set; }

        public string Underoverskrift { get; set; }

        public string Indhold { get; set; }

        public DateTime Dato { get; set; }

        public int BrugerID { get; set; }

        public string Image { get; set; }






    }
}
