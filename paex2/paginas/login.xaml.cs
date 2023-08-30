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
    public partial class login : ContentPage
    {   
        // VARIABLES GLOBALES
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        // funcion sql
        public static IEnumerable<estudiante>select_where(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<estudiante>("SELECT * FROM estudiante where Usuario=? and Contrasena=?", usuario, contrasenia);

        }


        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);

                db.CreateTable<estudiante>();

                IEnumerable<estudiante> resultado = select_where(db, txtUsuario.Text, txtPassword.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new paginas.consultaRegistro());

                }
                else
                {
                    DisplayAlert("Usuario o contraseña incorrectas", "", "Cerrar");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new paginas.registro());
        }
    }
}