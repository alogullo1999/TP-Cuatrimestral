using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ImagenProducto
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
