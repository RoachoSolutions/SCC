using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC.Couries.RedPack
{
    public class clsInit
    {



        public clsInit()
        {
            SCC.DAL.Config.couries _redpack = new DAL.Config.couries();
            using (var context = new SCC.DAL.Config.SCC_ConfigEntities())
            {
                _redpack = context.couries.Where(x => x.idcouries == (int)SCC.Comun.Contantes.Couries.RedPack).FirstOrDefault();
            }

            if (_redpack.estado > 0)
                throw new Exception("Couries no Activo");

            

        }

        public void Cotizaciones()
        {

        }

    }
}
