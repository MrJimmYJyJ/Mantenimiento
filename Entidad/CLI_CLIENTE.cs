using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CLI_CLIENTE
    {
        public Int64 Codigo { get; set; }
        public String NumHistoria { get; set; }
        public String Dni { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public DateTime FechaNaci { get; set; }
        public String Correo { get; set; }
        public String Direccion { get; set; }
        public DateTime Fechareg { get; set; }
        public String Sexo { get; set; }
        public Boolean Estado { get; set; }
        
        public CLI_TIPO Codtip { get; set; }

        public String NombreCompleto
        {
            get
            {
                return Paterno + " " + Materno + " " + Nombre;
            }
        }
        
        public CLI_CLIENTE()
        {

        }
        public CLI_CLIENTE(Int64 codigo, String numhistoria, String dni, String paterno, String materno, String nombre
            , String direccion, String telefono, String celular, DateTime fechanacimiento, DateTime fecharegistro,
            String sexo, String correo, Boolean Estado, CLI_TIPO codtip)
        {
            this.Codigo = codigo;
            this.NumHistoria = numhistoria;
            this.Dni = dni;
            this.Paterno = paterno;
            this.Materno = materno;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Celular = celular;
            this.FechaNaci = fechanacimiento;
            this.Fechareg = fecharegistro;
            this.Sexo = sexo;
            this.Correo = correo;
            this.Estado = Estado;
            this.Codtip = codtip;





        }
    }
}

