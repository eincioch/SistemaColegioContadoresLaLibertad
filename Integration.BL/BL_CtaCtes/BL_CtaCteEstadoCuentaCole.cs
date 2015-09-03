using Integration.BE.CtasCtes;
using Integration.DAService.DA_CtaCte;
using System.Data;

namespace Integration.BL.BL_CtaCtes
{
    public class BL_CtaCteEstadoCuentaCole
    {
        public DataTable Get_CtaCteEstadoCole(string cPerJurCodigo, string cPerCodigo, string cPerIdeNumero)
        {
            //Recuperando registros
            BE_ReqCtaCteEstadoCole Request = new BE_ReqCtaCteEstadoCole();
            DA_ReqCtaCteEstadoCuentaCole Da = new DA_ReqCtaCteEstadoCuentaCole();

            Request.cPerJurCodigo = cPerJurCodigo;
            Request.cPerCodigo = cPerCodigo;
            Request.cPerIdeNumero = cPerIdeNumero;

            return Da.Get_CtaCteEstadoCole(Request);
        }

        public DataTable Get_CtaCteEstadoCuentaCole(string cPerJurCodigo, string cPerCodigo, long nCtaCteSerCodigo)
        {
            //Recuperando registros
            BE_ReqCtaCteEstadoCuentaCole Request = new BE_ReqCtaCteEstadoCuentaCole();
            DA_ReqCtaCteEstadoCuentaCole Da = new DA_ReqCtaCteEstadoCuentaCole();

            Request.cPerJurCodigo = cPerJurCodigo;
            Request.cPerCodigo = cPerCodigo;
            Request.nCtaCteSerCodigo = nCtaCteSerCodigo;

            return Da.Get_CtaCteEstadoCuentaCole(Request);
        }
    }
}