using Integration.BE.UniOrgPerExt;
using Integration.DAService;
using System.Data;

namespace Integration.BL
{
    public class BL_UniOrgPerExt
    {
        public DataTable ObtenerUniOrgBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerUniOrgBycPerCodigo(Request);
        }

        public DataTable ObtenerInstitucionesBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerInstitucionesBycPerCodigo(Request);
        }

        public DataTable ObtenerAreaByPersonaInstitucion(BE_Req_UniOrgPerExt Request)
        {
            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerAreaByPersonaInstitucion(Request);
        }
    }
}