using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace lyngbybryghys
{
    public class NyhederOptions
    {
        public List<ProduktTabel> Produkter { get; set; }
        public List<Nyhedstabel> Nyheder { get; set; }

    }
}