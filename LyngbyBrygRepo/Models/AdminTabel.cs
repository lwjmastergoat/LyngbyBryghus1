using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;

namespace LyngbyBrygRepo
{
    public class AdminTabel
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Rolle { get; set; }
    }
}
