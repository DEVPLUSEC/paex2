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
using System.Collections.ObjectModel;

namespace paex2.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class consultaRegistro : ContentPage
    {
        SQLiteAsyncConnection con;
        ObservableCollection<estudiante> tEstudiante;
        public consultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            mostrar();
        }

        public async void mostrar()
        {
            var resultado = await con.Table<estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<estudiante>(resultado);
            listaEstudiantes.ItemsSource = tEstudiante;


        }
        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (estudiante)e.SelectedItem;
            Navigation.PushAsync(new paginas.elemento(obj));

        }
    }
}