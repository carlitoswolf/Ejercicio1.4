using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ejercicio1._4.Models
{
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(150)]
        public string nombres { get; set; }
        [MaxLength(250)]
        public string descripcion { get; set; }
        public byte[] foto { get; set; }

        public static implicit operator ImageSource(Data v)
        {
            throw new NotImplementedException();
        }
    }
}
