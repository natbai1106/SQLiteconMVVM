using MVVMSQLite.Models;
using MVVMSQLite.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMSQLite.ViewModels
{
    public class EmpleadoViewModel : BaseViewModel
    {
        public Command SendVerifyCommand { get; }
        public Command listViewEmpleados { get; }

        Page Page;

        List<Puestos> cargo;
        string nombre;
        string apellido;
        int edad;
        string direccion;
        string puesto;

        public string Puesto
        {
            get => puesto;
            set => SetProperty(ref puesto, value);
        }

        public List<Puestos> Cargo
        {
            get => cargo;
            set { SetProperty(ref cargo, value); }
        }

        public string Nombre
        {
            get => nombre;
            set { SetProperty(ref nombre, value); }
        }

        public string Apellido
        {
            get => apellido;
            set { SetProperty(ref apellido, value); }
        }
        public int Edad
        {
            get => edad;
            set { SetProperty(ref edad, value); }
        }

        public string Direccion
        {
            get => direccion;
            set { SetProperty(ref direccion, value); }
        }

        public EmpleadoViewModel(Page pag)
        {
            Page = pag;

            //PuestoSelected = new Puestos();
            Cargar();
            SendVerifyCommand = new Command(SalvarEmpleado);
            listViewEmpleados = new Command(Lista);
        }

        private async Task Cargar()
        {
            Cargo = Puestos.ObtenerCargos().OrderBy(c => c.value).ToList();
        }    

        public async void SalvarEmpleado(object obj)
        {

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || edad == 0 || string.IsNullOrEmpty(Direccion))
            {
                await Page.DisplayAlert("Mensaje", "No deben haber campos vacíos", "Ok");
            }
            else
            {
                var empleado = new Empleados
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Edad = Convert.ToInt32(Edad),
                    Direccion = Direccion,
                    Puesto = Puesto
                };

                {
                    int resultado = await App.InstanciaBD.InsertEmpleado(empleado);

                    if (resultado > 0)
                    {
                        await Page.DisplayAlert("Aviso", "Guardado exitosamente", "Ok");
                    }
                    else
                        await Page.DisplayAlert("Aviso", "Error", "Ok");
                }
            }
        }
        private async void Lista()
        {
            await Page.Navigation.PushAsync(new ListaEmpleados());
        }
    }
}
