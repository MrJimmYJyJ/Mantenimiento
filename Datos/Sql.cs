using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class Sql
    {
       
        protected static String cadena = @" Data Source = (localdb)\v11.0; Initial Catalog = Mantenimiento; Integrated Security = True";
       //public static object MessageBox { get; private set; }
        

        public static SqlCommand Comando(String procedimiento)
        {
            SqlConnection cn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlCommandBuilder.DeriveParameters(cmd);
                cn.Close();
                cn.Dispose();
                cmd.Connection = new SqlConnection(cadena);
            }
            catch (Exception e)
            {
                
            }

            return cmd;

        }

        public static SqlDataAdapter Adaptador(String procedimiento,
                                        params Object[] args)
        {
            SqlDataAdapter da = new SqlDataAdapter(Comando(procedimiento));
            if (args.Length != 0)
                CargarDatos(da.SelectCommand, args);
            return da;
        }

        private static void CargarDatos(SqlCommand cmd, object[] args)
        {
            for (int i = 1; i < cmd.Parameters.Count; i++)
            {
                cmd.Parameters[i].Value = args[i - 1];
            }
        }

        public static DataSet TraerDataSet(String procedimiento,
                                   params Object[] args)
        {
            SqlDataAdapter da = Adaptador(procedimiento, args);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static DataTable TraerTabla(String procedimiento,
                                    params Object[] args)
        {
            return TraerDataSet(procedimiento, args).Tables[0];
        }

        public static SqlDataReader TraerLector(String procedimiento,
                                        params Object[] args)
        {
            SqlCommand cmd = Comando(procedimiento);
            if (args.Length != 0)
                CargarDatos(cmd, args);

            cmd.Connection.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static Object TraerEscalar(String procedimiento,
                                         params Object[] args)
        {
            SqlCommand cmd = Comando(procedimiento);
            if (args.Length != 0)
                CargarDatos(cmd, args);

            cmd.Connection.Open();
            Object retorno = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return retorno;
        }

        public static Int32 Ejecutar(String procedimiento,
                               params Object[] args)
        {
            SqlCommand cmd = Comando(procedimiento);
            if (args.Length != 0)
                CargarDatos(cmd, args);

            cmd.Connection.Open();
            Int32 filas = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return filas;
        }


        public static Object EjecutarConSalida(String procedimiento,
                                              params Object[] args)
        {
            SqlCommand cmd = Comando(procedimiento);
            if (args.Length != 0)
                CargarDatos(cmd, args);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            Object retorno = null;

            foreach (SqlParameter parametro in cmd.Parameters)
            {
                if (parametro.Direction == ParameterDirection.InputOutput ||
                   parametro.Direction == ParameterDirection.Output)
                    retorno = parametro.Value;
            }

            cmd.Connection.Close();
            return retorno;
        }
    }
}
