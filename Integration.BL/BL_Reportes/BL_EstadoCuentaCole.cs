﻿using Integration.BE.Reportes;
using Integration.DAService.DA_Reportes;
using System.Data;

namespace Integration.BL.BL_Reportes
{
    public class BL_EstadoCuentaCole
    {
        public DataTable Get_EstadoCuentaCole(string cPerCodigo, string cperideNumero, long nintCodigo)
        {
            //Recuperando registros
            BE_ReqEstadoCuentaCole Request = new BE_ReqEstadoCuentaCole();

            Request.cPerCodigo = cPerCodigo;
            Request.cperideNumero = cperideNumero;
            Request.nintCodigo = nintCodigo;

            DA_EstadoCuentaCole Obj = new DA_EstadoCuentaCole();

            return Obj.Get_EstadoCuentaCole(Request);
        }
    }
}