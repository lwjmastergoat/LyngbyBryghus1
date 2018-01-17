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

        public List<OrdreDetaljerTabel> GetOrders()

            //Henter alle ordre ud fra ID, (Bruger ID), så brugeren kan gå ind og se samtlige  ordre de har placeret. (Måske burde sorteres efter ordre ID også?)
        {
            String SQL = "SELECT OrdreDetaljerTabel.ID, ProduktID, Antal, OrdreDetaljerTabel.BrugerID, KategoriID, Dato, OrdreID FROM OrdreDetaljerTabel JOIN KundeOrdreTabel ON OrdreDetaljerTabel.ID = KundeOrdreTabel.ID WHERE OrdreDetaljerTabel.BrugerID =" + "@ID";

            return ExecuteSQL<OrdreDetaljerTabel>(SQL);

        }





    }
}
