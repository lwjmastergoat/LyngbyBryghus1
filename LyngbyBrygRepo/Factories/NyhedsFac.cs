using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duser;
using LyngbyBrygRepo.Models;

namespace LyngbyBrygRepo.Factories
{
    public class NyhedsFac:AutoFac<Nyhedstabel>
    {
        public List<Nyhedstabel> GetNews()

            // Henter alle nyheder ordnet efter Dato, nyeste først. Joinet med bruger så Navnet på skribent fremkommer.
        {
            String SQL = "SELECT NyhedsTabel.ID, Overskrift, Underoverskrift, Indhold, Dato, NyhedsTabel.Image, BrugerID, BrugerTabel.Navn FROM NyhedsTabel JOIN BrugerTabel ON BrugerTabel.ID = NyhedsTabel.BrugerID ORDER BY Dato DESC";

            return ExecuteSQL<Nyhedstabel>(SQL);
        }


    }
}
