using Integration.BE.Reportes;
using Integration.DAService.DA_Reportes;
using System;
using System.Data;

namespace Integration.BL.BL_Reportes
{
    public class BL_RptCuadreCaja
    {
        //------------------------
        //select CtaCteComprobante
        //------------------------
        public DataTable Get_ReportCuadraCaja(string cFlag, DateTime dCtaCteComFecIni, DateTime dCtaCteComFecFin)
        {
            //Recuperando...
            BE_ReqRptCuadreCaja Request = new BE_ReqRptCuadreCaja();
            DA_RptCuadreCaja Obj = new DA_RptCuadreCaja();

            Request.cFlag = cFlag;
            Request.dCtaCteComFecIni = dCtaCteComFecIni;
            Request.dCtaCteComFecFin = dCtaCteComFecFin;

            return Obj.Get_ReportCuadraCaja(Request);
        }
    }
}