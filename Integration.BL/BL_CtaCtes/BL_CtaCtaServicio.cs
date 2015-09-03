using Integration.BE;
using Integration.BE.CtasCtes;
using Integration.DAService.DA_CtaCte;
using System.Data;

namespace Integration.BL.BL_CtaCtes
{
    public class BL_CtaCtaServicio
    {
        //------------------------
        //Insert CtaCteServicio
        //------------------------
        public bool Ins_CtaCteServicio(BE_ReqCtaCteServicio Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            DA_CtaCteServicio Obj = new DA_CtaCteServicio();
            return Obj.Ins_CtaCteServicio(Request);
        }

        //------------------------
        //Update CtaCteServicio
        //------------------------
        public bool Upd_CtaCteServicio(BE_ReqCtaCteServicio Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            DA_CtaCteServicio Obj = new DA_CtaCteServicio();
            return Obj.Upd_CtaCteServicio(Request);
        }

        //------------------------
        //select CtaCteServicio
        //------------------------
        public DataTable Get_CtaCteServicio(BE_ReqCtaCteServBusca Request)
        {
            DA_CtaCteServicio Obj = new DA_CtaCteServicio();
            return Obj.Get_CtaCteServicio(Request);
        }

        //-----------------------------------
        //Obtener Servicio por Tipo de Cuenta
        //-----------------------------------
        public DataTable Get_ServicioporTipoCta(BE_ReqServicioporTipoCta Request)
        {
            DA_CtaCteServicio Obj = new DA_CtaCteServicio();
            return Obj.Get_ServicioporTipoCta(Request);
        }

        //Get_CtaCteServicio_nCtaCteSerImpDef.- Obtener precio for Servicio
        public double Get_CtaCteServicio_nCtaCteSerImpDef(string cPerJurCodigo, long nCtaCteSerCodigo)
        {
            BE_ReqCtaCteSerImpDefault Request = new BE_ReqCtaCteSerImpDefault();
            DA_CtaCteServicio da = new DA_CtaCteServicio();

            Request.cPerJurCodigo = cPerJurCodigo;
            Request.nCtaCteSerCodigo = nCtaCteSerCodigo;

            return da.Get_CtaCteServicio_nCtaCteSerImpDef(Request);
        }
    }
}