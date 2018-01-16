using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyngbyBrygRepo.Models;
using Duser;

namespace LyngbyBrygRepo.Factories
{
    public class ProduktFac:AutoFac<ProduktTabel>
    {
        public List<ProduktTabel> GetAll()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID";

            return ExecuteSQL<ProduktTabel>(SQL);
        }

        public List<ProduktTabel> GetBy()
        {
            String SQL = "SELECT ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gærtype, KategoriTabel.Navn FROM ProduktTabellen JOIN KategoriTabel on ProduktTabellen.KategoriID = KategoriTabel.ID WHERE KategoriTabel.ID =" + "@ID";

            return ExecuteSQL<ProduktTabel>(SQL);
        }
        




    }
}
