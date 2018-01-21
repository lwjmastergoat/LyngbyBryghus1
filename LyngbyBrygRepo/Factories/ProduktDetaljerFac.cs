using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using LyngbyBrygRepo;
using LyngbyBrygRepo.Models;

namespace LyngbyBrygRepo.Factories
{
    public class ProduktDetaljerFac: AutoFac<ProduktKategoriJoin>
    {

    public ProduktKategoriJoin GetDetails(int ID)
        {
            string SQL = "SELECT ProduktTabellen.ID, KategoriID, ProduktTabellen.Navn, Beskrivelse, Billede, Pris, Alkohol, Farve, Bitterhed, Gaertype, KategoriTabel.Navn AS 'KategoriensNavn' FROM ProduktTabellen INNER JOIN KategoriTabel ON ProduktTabellen.KategoriID = KategoriTabel.ID WHERE ProduktTabellen.ID =" + "@ID";

            return ExecuteSQL<ProduktKategoriJoin>(SQL)[0];
                

        }



    }
}
