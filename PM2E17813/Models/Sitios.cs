using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E17813.Models
{
    class Sitios
    {
        [PrimaryKey,AutoIncrement]
        public int Id {  get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set;}

        public Byte[] Foto { get; set; }

    }
}
