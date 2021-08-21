using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSQLite.Models
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;
        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la bd 
            db.CreateTableAsync<Empleados>().Wait();
        }

        //Metodos del CRUD para Empleados 

        #region Empleados 
        //Select 
        public Task<List<Empleados>> ObtenerEmpleado()
        {
            return db.Table<Empleados>().ToListAsync();
        }

        //Insert 
        public Task<int> InsertEmpleado(Empleados empleado)
        {
            if (empleado.IdEmpleado != 0)
            {
                return db.UpdateAsync(empleado);
            }
            else
            {
                return db.InsertAsync(empleado);
            }
        }
        //Traer un solo sitio (Ubicacion) 
        //public Task<Sitios> ObtenerSitios(int pid)
        //{
        //    return db.Table<Sitios>()
        //        .Where(i => i.id == pid)
        //        .FirstOrDefaultAsync();
        //}

        //Delete 
        //public Task<int> EliminarFoto(Empleados foto)
        //{
        //    return db.DeleteAsync(foto);
        //}
        #endregion Empleados 
    }
}
