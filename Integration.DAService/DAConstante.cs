﻿using Integration.BE;
using Integration.BE.Constante;
using Integration.Conection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Integration.DAService
{
    public class DAConstante
    {
        public DataTable ListarConstantes(BE_Req_Constante Request)
        {
            DataTable Item = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_ListarConstante";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("nConValor", Request.nConValor);
                        cm.Parameters.AddWithValue("ConLeft", Request.ConLeft);
                        cm.Parameters.AddWithValue("ConValLeft", Request.ConValLeft);
                        cm.Parameters.AddWithValue("ConRight", Request.ConRight);
                        cm.Parameters.AddWithValue("ConValRight", Request.ConValRight);
                        cm.Parameters.AddWithValue("NotIn", Request.NotIn);
                        cm.Parameters.AddWithValue("In", Request.cConValor);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            Item.Load(dr);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }

        public IList<BE_Res_Constante> Get_ConstantesBynConValor(BE_Req_Constante Request)
        {
            BE_Res_Constante Item = new BE_Res_Constante();
            var lista = new List<BE_Res_Constante>();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_Get_Constantes_BynConCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("cConValor", Request.cConValor);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_Constante();
                                Item.nConValor = dr.GetInt32(dr.GetOrdinal("nConValor"));
                                Item.cConDescripcion = dr.GetString(dr.GetOrdinal("cConDescripcion")).Trim();
                                Item.nConCodigo = dr.GetInt32(dr.GetOrdinal("nConCodigo"));
                                lista.Add(Item);
                            }
                            dr.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public DataTable GetConstante(BE_Req_Constante Request)
        {
            DataTable Item = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_Get_Constantes_BynConCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("cConValor", Request.cConValor);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            Item.Load(dr);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }

        public BE_ResGenerico ExecInsUpdConstante(BE_ReqInsUpdConstante Request)
        {
            BE_ResGenerico Item = new BE_ResGenerico();
            long Resultado = 0;
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "usp_InsUpd_Contante";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("flag", Request.flag);
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("cConDescripcion", Request.cConDescripcion);
                        cm.Parameters.AddWithValue("nConValor", Request.nConValor);
                        cm.Connection = cn;
                        Resultado = cm.ExecuteNonQuery();
                        Item.Resultado = Resultado;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }
    }
}