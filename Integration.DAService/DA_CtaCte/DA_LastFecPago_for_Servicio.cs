using Integration.BE.CtasCtes;
using Integration.Conection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Integration.DAService.DA_CtaCte
{
    public class DA_LastFecPago_for_Servicio
    {
        //--------------------------
        // SELECT Get_LastPago_for_Servicio
        //--------------------------
        public DataTable Get_LastPago_for_Servicio(BE_ReqLastFecPago_for_Servicio Request)
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
                        cm.CommandText = "[usp_Get_LastPago_for_Servicio]";
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
    }
}