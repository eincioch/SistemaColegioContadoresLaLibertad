using Integration.BE.CtasCtes;
using Integration.DAService.DA_CtaCte;
using System;
using System.Data;

namespace Integration.BL.BL_CtaCtes
{
    public class BL_AnularComprobante
    {
        //------------------------------------------------------'
        //select Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas
        //------------------------------------------------------'
        public DataTable Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas(string cFlag, DateTime dFecIni, DateTime dFecFin, string cCtaCteRecibo)
        {
            BE_ReqBuscaComprobante Request = new BE_ReqBuscaComprobante();
            DA_AnularComprobante da = new DA_AnularComprobante();

            Request.cFlag = cFlag;
            Request.dFecIni = dFecIni;
            Request.dFecFin = dFecFin;
            Request.cCtaCteRecibo = cCtaCteRecibo;

            return da.Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas(Request);
        }

        //---------------------
        //Set_AnularComprobante
        //---------------------
        public bool Set_AnularComprobante(string cflag, string cPerJurCodigo, string cPerCodigo, string cCtaCteRecibo, string cCtaCteRecAbono, string cPerUserCodigo = "")
        {
            bool exito = false;

            BE_AnularComprobante Request = new BE_AnularComprobante();
            DA_AnularComprobante da = new DA_AnularComprobante();

            try
            {
                Request.cflag = cflag;
                Request.cPerJurCodigo = cPerJurCodigo;
                Request.cPerCodigo = cPerCodigo;
                Request.cCtaCteRecibo = cCtaCteRecibo;
                Request.cCtaCteRecAbono = cCtaCteRecAbono;
                Request.cPerUserCodigo = cPerUserCodigo;

                if (!da.Set_AnularComprobante(Request))
                {
                    throw new ApplicationException("Se encontraron errores en la transaccion: CtaCteComprobante.!");
                }
                else exito = true;
            }
            catch (Exception)
            {
                throw;
            }
            return exito;
        }
    }
}