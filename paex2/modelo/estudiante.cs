using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace paex2.modelo
{
    public class estudiante
    {
        // id de estudiante
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // Nombre de estudiante
        [MaxLength(50)]
        public string Nombre { get; set; }
        // Usuario de estudiante
        [MaxLength(50)]
        public string Usuario { get; set; }
        // contrasenia
        [MaxLength(50)]
        public string Contrasena { get; set;}



    }
}
