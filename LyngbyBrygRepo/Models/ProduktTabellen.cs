﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Duser;

namespace LyngbyBrygRepo
{
    public class ProduktTabellen
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public string Navn { get; set; }
        [AllowHtml]
        public string Beskrivelse { get; set; }
        public string Billede { get; set; }
        public decimal Pris { get; set; }

        public decimal Alkohol { get; set; }
        public int Farve { get; set; }
        public int Bitterhed { get; set; }
        public string Gaertype { get; set; }


    }
}
