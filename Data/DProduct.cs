using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProduct
    {
        public List<Product> Listar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Product> products = null;

            try
            {
                comandText = "USP_GetProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@id", System.Data.SqlDbType.Int);
                parameters[0].Value = product.id;
                products = new List<Product>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            id = reader["id"] != null ? Convert.ToInt32(reader["id"]) : 0,
                            nombre = reader["nombre"] != null ? Convert.ToString(reader["nombre"]) : string.Empty,
                            precio = reader["precio"] != null ? Convert.ToDouble(reader["precio"]) : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public void Insertar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsProduct";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
                parameters[0].Value = product.nombre;
                parameters[1] = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
                parameters[1].Value = product.precio;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProduct";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@id", System.Data.SqlDbType.Int);
                parameters[0].Value = product.id;
                parameters[1] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
                parameters[1].Value = product.nombre;
                parameters[2] = new SqlParameter("@precio", System.Data.SqlDbType.Decimal);
                parameters[2].Value = product.precio;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", System.Data.SqlDbType.Int);
                parameters[0].Value = id;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
