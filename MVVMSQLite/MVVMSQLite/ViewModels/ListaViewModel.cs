using MVVMSQLite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMSQLite.ViewModels
{
    public class ListaViewModel : BaseViewModel
    {
        Page Page;
        ObservableCollection<Empleados> empleado;
        public ICommand DeleteServiceCommand { protected set; get; }

        Empleados empleadoSelected;
        private string nombre;
        private string apellido;
        private int edad;
        private string direccion;
        private string puesto;

        public Empleados EmpleadoSelected
        {
            get => empleadoSelected; set { SetProperty(ref empleadoSelected, value); }
        }
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }
        public string Apellido
        {
            get => apellido;
            set => SetProperty(ref apellido, value);
        }
        public int Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }
        public string Direccion
        {
            get => direccion;
            set => SetProperty(ref direccion, value);
        }
        public string Puesto
        {
            get => puesto;
            set => SetProperty(ref puesto, value);
        }
        public ObservableCollection<Empleados> ListaEmpleados
        {
            get => empleado; set => SetProperty(ref empleado, value);
        }

        public ListaViewModel(Page pag)
        {
            Page = pag;
            cargar();

            DeleteServiceCommand = new Command<Empleados>((servicio) => {
                if (ListaEmpleados != null)
                {
                    ListaEmpleados.Remove(servicio);
                }
            });
        }
        public async void cargar()
        {
            var list = await App.InstanciaBD.ObtenerEmpleado();
            if (list != null)
                ListaEmpleados = new ObservableCollection<Empleados>(list);
        }
    }
}
