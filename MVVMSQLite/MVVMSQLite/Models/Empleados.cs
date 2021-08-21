using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMSQLite.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int IdEmpleado { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(100)]
        public int Edad { get; set; }

        [MaxLength(300)]
        public string Direccion { get; set; }

        [MaxLength(100)]
        public string Puesto { get; set; }
    }
}
