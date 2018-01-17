using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyngbyBrygRepo.Models;
using Duser;

namespace LyngbyBrygRepo.Factories
{
    public class ProduktFac:AutoFac<ProduktTabellen>
    {
        // Finder alle produkter, Joiner med kategoritabellen, så kategorien på øllen også fremgør.
        public List<ProduktTabellen> GetProducts()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID";

            return ExecuteSQL<ProduktTabellen>(SQL);
        }

        // Finder alle produkter med en vis kategori ID, dvs. eks. lyse øl, mørke øl osv.

        public List<ProduktTabellen> GetBy()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID WHERE KategoriTabel.ID =" + "@ID";

            return ExecuteSQL<ProduktTabellen>(SQL);
        }
        




    }
}
