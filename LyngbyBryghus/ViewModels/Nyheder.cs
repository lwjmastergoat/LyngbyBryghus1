using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo;
using LyngbyBrygRepo.Models;


namespace LyngbyBryghus.ViewModels
{
    public class Nyheder
    {
        public List<ProduktTabellen> Produkter { get; set; }

        public List<Nyhedstabel> Nyhederne { get; set; }


    }
}