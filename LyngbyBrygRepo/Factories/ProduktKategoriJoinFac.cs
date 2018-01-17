using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using LyngbyBrygRepo.Models.R_Models;
using LyngbyBrygRepo.Models;

namespace LyngbyBrygRepo
{
    public class ProduktKategoriJoinFac: AutoFac<ProduktKategoriJoin>
    {

        // Finder alle produkter, Joiner med kategoritabellen, så kategorien på øllen også fremgør.
        public List<ProduktTabellen> GetProducts()
        {
            String SQL = "SELECT ProduktTabellen.ID, ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn, KategoriID, KategoriTabel.ID FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID";

            return ExecuteSQL<ProduktTabellen>(SQL);
        }

    }
}
