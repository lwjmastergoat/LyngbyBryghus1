using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace lyngbybryghys
{
    public class BestillingOptions
    {
        public List<ProduktTabel> Produkter { get; set; }
        public List<KategoriTabel> Kategorier { get; set; }

    }
}