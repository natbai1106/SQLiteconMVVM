using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMSQLite.Models
{
    public class Puestos
    {
        public string value { get; set; }
        public List<Puestos> Puesto { get; set; }

        public static List<Puestos> ObtenerCargos()
        {
            var cargo = new List<Puestos>()
            {
                new Puestos(){ value ="Gerente IT" },
                new Puestos(){ value ="Analista" },
                new Puestos(){ value ="Desarrollador" },
                new Puestos(){ value ="DBA" },
                new Puestos(){ value ="Soporte Tecnico" }
            };
            return cargo;
        }
    }
}
