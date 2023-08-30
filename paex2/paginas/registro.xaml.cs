using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using paex2.interfaces;
using paex2.modelo;
using System.IO;

namespace paex2.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            var datos = new estudiante
            {
                Nombre = txtNombre.Text,
                Usuario = txtUsuario.Text,
                Contrasena = txtPassword.Text
            };

            con.InsertAsync(datos);
            DisplayAlert("Usuario registrado","","Cerrar");
            Navigation.PushAsync(new paginas.login());



        }
    }
}