using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyngbyBrygRepo;
using LyngbyBrygRepo.Models;

namespace LyngbyBryghus.ViewModels
{
    public class Forsiden
    {
        public List<Nyhedstabel> Nyheder { get; set; }

        public string Overskrift { get; set; }

        public string Indhold { get; set; }
    }
}