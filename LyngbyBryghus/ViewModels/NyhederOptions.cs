using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace LyngbyBryghus
{
    public class NyhederOptions
    {
        public List<ProduktTabellen> Produkter { get; set; }
        public List<Nyhedstabel> Nyheder { get; set; }

    }
}