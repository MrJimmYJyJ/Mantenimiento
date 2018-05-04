using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Negocio
{
    public class CLI_CLIENTE : Entidad.CLI_CLIENTE
    {
        public List<Entidad.CLI_CLIENTE> BuscarPorNombre(String nombre)
        {
            List<Entidad.CLI_CLIENTE> CLI_CLIENTEs = new List<Entidad.CLI_CLIENTE>();
            SqlDataReader dr = null;
            try
            {
                dr = Datos.Sql.TraerLector("CLI_CLIENTE_BuscarPorNombre", nombre);
                while (dr.Read())
                {
                    CLI_CLIENTEs.Add(CargarElemento(dr));
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
            return CLI_CLIENTEs;
        }

        public List<Entidad.CLI_CLIENTE> Listar()
        {
            List<Entidad.CLI_CLIENTE> CLI_CLIENTEs = new List<Entidad.CLI_CLIENTE>();
            SqlDataReader dr = null;
            try
            {
                dr = Datos.Sql.TraerLector("CLI_CLIENTE_Listar");
                while (dr.Read())
                {
                    CLI_CLIENTEs.Add(CargarElemento(dr));
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
            return CLI_CLIENTEs;
        }
        private Entidad.CLI_CLIENTE CargarElemento(SqlDataReader dr)
        {
            return new Entidad.CLI_CLIENTE()
            {
                Codigo = Convert.ToInt64(dr["cli_codigo"]),
                NumHistoria = dr["cli_numhistoria"].ToString(),
                Dni = dr["cli_dni"].ToString(),
                Paterno = dr["cli_paterno"].ToString(),
                Materno = dr["cli_materno"].ToString(),
                Nombre = dr["cli_nombres"].ToString(),
                Direccion = dr["cli_direccion"].ToString(),
                Telefono = dr["cli_telefono"].ToString(),
                Celular = dr["cli_celular"].ToString(),
                FechaNaci = Convert.ToDateTime(dr["cli_fechanacimiento"].ToString()),
                Fechareg = Convert.ToDateTime(dr["cli_fechreg"].ToString()),
                Sexo = dr["cli_sexo"].ToString(),
                Correo = dr["cli_correo"].ToString(),
                Estado = Convert.ToBoolean(dr["cli_estado"]),

                Codtip = new Entidad.CLI_TIPO()
                {
                    Codigo = Convert.ToInt32(dr["tip_codigo"]),
                    Nombre = dr["tip_nombre"].ToString()
                },
                
            };
        }
        public bool Agregar()
        {
            try
            {
                int filas = Datos.Sql.Ejecutar("CLI_CLIENTE_Agregar", NumHistoria, Dni, Paterno, Materno, Nombre, Direccion, Telefono, Celular, FechaNaci, Sexo, Correo, Estado, Codtip.Codigo);
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
                int filas = Datos.Sql.Ejecutar("CLI_CLIENTE_Modificar", Codigo, NumHistoria, Dni, Paterno, Materno, Nombre, Direccion, Telefono, Celular, FechaNaci, Sexo, Correo, Estado, Codtip.Codigo);
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
                int filas = Datos.Sql.Ejecutar("CLI_CLIENTE_Eliminar", Codigo);
                return filas > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}