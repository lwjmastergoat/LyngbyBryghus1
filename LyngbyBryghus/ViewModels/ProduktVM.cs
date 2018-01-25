using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo;

namespace LyngbyBryghus.ViewModels
{
    public class ProduktVM
    {
        public ProduktTabellen Produkter { get; set; }

        public List<KategoriTabel> Kategorier { get; set; }
    }
}