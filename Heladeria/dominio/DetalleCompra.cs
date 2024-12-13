using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleCompra
    {
        public DateTime FechaCompra { get; set; }

        public int IdCompra { get; set; }

        public int IdProveedor { get; set; }

        public int IdProducto { get; set; }


    }
}
