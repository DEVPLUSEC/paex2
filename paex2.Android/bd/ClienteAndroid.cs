using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// librerias
using SQLite;
using paex2.interfaces;
using System.IO;
using paex2.Droid.bd;

// Ejecutar y leer proyecto
[assembly:Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace paex2.Droid.bd
{
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {   
            // Ruta de guardado de base de datos
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            // Crear base de datos
            var baseDatos = Path.Combine(ruta,"uisrael.db3");

            // retorno de la conexion
            return new SQLiteAsyncConnection(baseDatos);

            
        }
    }
}