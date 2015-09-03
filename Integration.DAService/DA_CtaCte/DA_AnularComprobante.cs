using Integration.BE.CtasCtes;
using Integration.Conection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Integration.DAService.DA_CtaCte
{
    public class DA_AnularComprobante
    {
        //----------------------------------------------------------------
        // SELECT usp_Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas
        //----------------------------------------------------------------
        public DataTable Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas(BE_ReqBuscaComprobante Request)
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
                        cm.CommandText = "[usp_Get_CtaCteItem_for_cCtaCteRecibo_by_range_fechas]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cFlag", Request.cFlag);
                        cm.Parameters.AddWithValue("dFecIni", Request.dFecIni);
                        cm.Parameters.AddWithValue("dFecFin", Request.dFecFin);
                        cm.Parameters.AddWithValue("cCtaCteRecibo", Request.cCtaCteRecibo);
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
        // UPDATE usp_Set_AnularComprobante
        //---------------------------------
        public bool Set_AnularComprobante(BE_AnularComprobante Request)
        {
            bool exito = false;
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "[usp_Set_AnularComprobante]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cflag", Request.cflag);
                        cm.Parameters.AddWithValue("cPerJurCodigo", Request.cPerJurCodigo);
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("cCtaCteRecibo", Request.cCtaCteRecibo);
                        cm.Parameters.AddWithValue("cCtaCteRecAbono", Request.cCtaCteRecAbono);
                        cm.Parameters.AddWithValue("cPerUserCodigo", Request.cPerUserCodigo);

                        cm.Connection = cn;

                        if (cm.ExecuteNonQuery() > 0)
                        {
                            exito = true;
                        }
                        else throw new ApplicationException("se ha producido un error procedimiento almacenado: [usp_Set_AnularComprobante]; Consulte al administrador del sistema");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return exito;
        }
    }
}