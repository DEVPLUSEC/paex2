using paex2.modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using paex2.interfaces;
using System.IO;
using System.Globalization;

namespace paex2.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class elemento : ContentPage
    {
        SQLiteAsyncConnection con;
        public int idSeleccionado;
        IEnumerable<estudiante> reEliminar;
        IEnumerable<estudiante> reActualizar;
        public elemento(estudiante datos)
        {
            InitializeComponent();

            con = DependencyService.Get<DataBase>().GetConnection();

            txtID.Text = datos.Id.ToString();
            txtNombre.Text = datos.Nombre.ToString();
            txtUsuario.Text = datos.Usuario.ToString();
            txtContrasena.Text = datos.Contrasena.ToString();

            idSeleccionado = datos.Id;

        }

        public static IEnumerable<estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<estudiante>("Delete from estudiante where Id=?", id);
        }

        public static IEnumerable<estudiante> Actualizar(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<estudiante>("Update estudiante SET Nombre=?, Usuario=?, Contrasena=? WHERE Id=?", nombre,usuario,contrasena,id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);

            
                reActualizar = Actualizar(db, idSeleccionado, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);

                
                    DisplayAlert("Usuario actualizado", "", "Cerrar");
                    Navigation.PushAsync(new paginas.consultaRegistro());

                
            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);


                reEliminar = Eliminar(db, idSeleccionado);

                
                    DisplayAlert("Usuario eliminado", "", "Cerrar");
                    Navigation.PushAsync(new paginas.consultaRegistro());

                
            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }

        }
    }
}