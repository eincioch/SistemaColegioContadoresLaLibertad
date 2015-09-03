using Integration.BE.PerUsuGruAcc;
using Integration.DAService;
using System.Collections.Generic;

namespace Integration.BL
{
    public class BL_PerUsuGruAcc
    {
        public IList<BE_Res_PerUsuGruAcc> obtenerPermisos(BE_Req_PerUsuGruAcc Request)
        {
            DAPerUsuGruAcc ObjPermisos = new DAPerUsuGruAcc();
            return ObjPermisos.ObtenerPermisos(Request);
        }
    }
}