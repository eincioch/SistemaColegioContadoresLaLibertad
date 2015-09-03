using Integration.BE.CtasCtes;
using Integration.DAService.DA_CtaCte;
using System.Data;

namespace Integration.BL.BL_CtaCtes
{
    public class BL_LastFecPago_for_Servicio
    {
        //------------------------
        //select Get_LastPago_for_Servicio
        //------------------------
        public DataTable Get_LastPago_for_Servicio(string cPerCodigo)
        {
            BE_ReqLastFecPago_for_Servicio Request = new BE_ReqLastFecPago_for_Servicio();
            DA_LastFecPago_for_Servicio Obj = new DA_LastFecPago_for_Servicio();

            //Request.cCtaCteRecibo = cCtaCteRecibo;
            Request.cPerCodigo = cPerCodigo;

            return Obj.Get_LastPago_for_Servicio(Request);
        }
    }
}