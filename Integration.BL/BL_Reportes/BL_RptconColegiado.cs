﻿using Integration.BE.Reportes;
using Integration.DAService.DA_Reportes;
using System;
using System.Data;

namespace Integration.BL.BL_Reportes
{
    public class BL_RptconColegiado
    {
        //--------------------------------------
        //select usp_Get_RptVarios_for_Colegiado
        //------------------------------------
        public DataTable Get_RptVarios_for_Colegiado(string cNameRpt, DateTime dFecIni, DateTime dFecFin, string cPerCodigo, long nCtaCteSerCodigo, string cEstado)
        {
            //Recuperando...
            BE_ReqRptColegiado Request = new BE_ReqRptColegiado();
            DA_RptconColegiado DA = new DA_RptconColegiado();

            Request.cNameRpt = cNameRpt;
            Request.dFecIni = dFecIni;
            Request.dFecFin = dFecFin;
            Request.cPerCodigo = cPerCodigo;
            Request.nCtaCteSerCodigo = nCtaCteSerCodigo;
            Request.cEstado = cEstado;

            return DA.usp_Get_RptVarios_for_Colegiado(Request);
        }
    }
}