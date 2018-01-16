using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace LyngbyBryghus.ViewModels
{
    public class Bestilling
    {
        public List<ProduktTabellen> Produkter { get; set; }

        public List<KategoriTabel>  Kategorier { get; set; }




    }
}