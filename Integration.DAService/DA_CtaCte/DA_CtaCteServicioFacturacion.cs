﻿using Integration.BE.CtasCtes;
using Integration.BE.Persona;
using Integration.Conection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Integration.DAService.DA_CtaCte
{
    public class DA_CtaCteServicioFacturacion
    {
        //-----------------------------------------
        // SELECT usp_Get_CtaCteServicioFacturacion
        //-----------------------------------------
        public DataTable Get_CtaCteServicioFacturacion(BE_CtaCteServicioFacturacion Request)
        {
            DataTable dt = new DataTable();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "[usp_Get_CtaCteServicioFacturacion]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;

                        using (SqlDataReader dr = cm.ExecuteReader())
                            dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        //---------------------------------
        // SELECT usp_Get_TipoDocporNroCaja
        //---------------------------------
        public DataTable Get_TipoDocporNroCaja(BE_TipoDocporNroCaja Request)
        {
            DataTable dt = new DataTable();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "usp_Get_TipoDocporNroCaja";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerJurCodigo", Request.cPerJurCodigo);
                        cm.Parameters.AddWithValue("nCajCodigo", Request.nCajCodigo);
                        cm.Connection = cn;

                        using (SqlDataReader dr = cm.ExecuteReader())
                            dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        //[usp_Get_PerCuenta] Obtener Entidad financieras segun Forma de pago
        public DataTable Get_EntidadFinaciera_Tarjetas(BE_ReqBuscarEntidadFinanciera Request)
        {
            DataTable dt = new DataTable();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "[usp_Get_PerCuenta]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cFlag", Request.cFlag);
                        cm.Parameters.AddWithValue("cPerJurCodigo", Request.cPerJurCodigo);
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nPerIntCodigo", Request.nPerIntCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                            dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}