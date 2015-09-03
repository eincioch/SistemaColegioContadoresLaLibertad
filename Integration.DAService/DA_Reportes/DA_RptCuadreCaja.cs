using Integration.BE.Reportes;
using Integration.Conection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Integration.DAService.DA_Reportes
{
    public class DA_RptCuadreCaja
    {
        //----------------------------
        // SELECT Get_ReportCuadraCaja
        //----------------------------
        public DataTable Get_ReportCuadraCaja(BE_ReqRptCuadreCaja Request)
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
                        cm.CommandText = "[usp_Get_ReportCuadreCaja]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cFlag", Request.cFlag);
                        cm.Parameters.AddWithValue("dCtaCteComFecIni", Request.dCtaCteComFecIni);
                        cm.Parameters.AddWithValue("dCtaCteComFecFin", Request.dCtaCteComFecFin);
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