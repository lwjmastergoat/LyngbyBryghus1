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
        public List<ProduktKategoriJoin> GetProducts()
        {
            String SQL = "SELECT ProduktTabellen.ID, KategoriID, ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Gaertype, KategoriTabel.Navn AS 'KategoriensNavn' FROM ProduktTabellen INNER JOIN KategoriTabel ON ProduktTabellen.KategoriID = KategoriTabel.ID";

            return ExecuteSQL<ProduktKategoriJoin>(SQL);
        }

    }
}
