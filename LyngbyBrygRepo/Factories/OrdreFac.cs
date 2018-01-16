using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyngbyBrygRepo.Models;
using Duser;

namespace LyngbyBrygRepo.Factories
{
    public class OrdreFac:AutoFac<OrdreDetaljerTabel>
    {

        public List<OrdreDetaljerTabel> GetAll()

            //Henter alle ordre ud fra ID, (Bruger ID), så brugeren kan gå ind og se samtlige  ordre de har placeret.
        {
            String SQL = "SELECT OrdreDetaljerTabel.ID, ProduktID, Antal, OrdreDetaljerTabel.BrugerID, KategoriID, Dato, OrdreID FROM OrdreDetaljerTabel JOIN KundeOrdreTabel ON OrdreDetaljerTabel.ID = KundeOrdreTabel.ID WHERE OrdreDetaljerTabel.BrugerID =" + "@ID";

            return ExecuteSQL<OrdreDetaljerTabel>(SQL);

        }





    }
}
