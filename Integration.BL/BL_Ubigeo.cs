using Integration.BE.Ubigeo;
using Integration.DAService;
using System.Data;

namespace Integration.BL
{
    public class BL_Ubigeo
    {
        public DataTable getUbigeoBycUbiGeoCodigo(BE_Req_Ubigeo Request)
        {
            DAUbigeo ObjPersona = new DAUbigeo();
            return ObjPersona.getUbigeoBycUbiGeoCodigo(Request);
        }
    }
}