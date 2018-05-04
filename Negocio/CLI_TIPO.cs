using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CLI_TIPO : Entidad.CLI_TIPO
    {
        public List<Entidad.CLI_TIPO> Listar()
        {
            List<Entidad.CLI_TIPO> CLI_TIPO = new List<Entidad.CLI_TIPO>();
            SqlDataReader dr = null;

            try
            {
                dr = Datos.Sql.TraerLector("CLI_TIPO_Listar");
                while (dr.Read())
                {
                    CLI_TIPO.Add(CargarElemento(dr));
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dr.Close();
                dr.Dispose();
            }
            return CLI_TIPO;
        }
        private Entidad.CLI_TIPO CargarElemento(SqlDataReader dr)
        {


            return new Entidad.CLI_TIPO()
            {
                Codigo = Convert.ToInt32(dr["tip_codigo"]),
                Nombre = dr["tip_nombre"].ToString(),

            };
        }
        public bool Agregar()
        {
            try
            {
                int filas = Datos.Sql.Ejecutar("CLI_TIPO_Agregar", Nombre);
                return filas > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Modificar()
        {
            try
            {
                int filas = Datos.Sql.Ejecutar("CLI_TIPO_Modificar", Codigo, Nombre);
                return filas > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminar()
        {
            try
            {
                int filas = Datos.Sql.Ejecutar("CLI_TIPO_Eliminar", Codigo);
                return filas > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
