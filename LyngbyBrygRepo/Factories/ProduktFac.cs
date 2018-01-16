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
        public List<ProduktTabellen> GetProducts()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID";

            return ExecuteSQL<ProduktTabellen>(SQL);
        }

        public List<ProduktTabellen> GetBy()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID WHERE KategoriTabel.ID =" + "@ID";

            return ExecuteSQL<ProduktTabellen>(SQL);
        }
        




    }
}
