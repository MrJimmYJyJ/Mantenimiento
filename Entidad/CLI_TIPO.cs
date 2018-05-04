using System;

namespace Entidad
{
    public class CLI_TIPO
    {
        public Int32 Codigo { get; set; }
        public String Nombre { get; set; }


        public CLI_TIPO() { }
        public CLI_TIPO(Int32 codigo, String nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }
    }
}