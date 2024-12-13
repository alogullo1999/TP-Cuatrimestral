using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleVenta
    {
        public int IdVenta { get; set; }

        public DateTime FechaVenta { get; set; }

        public string Estado { get; set; }

        public int IdEmpleado { get; set; }

        public int IdCliente { get; set; }

        public int IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal TotalVenta { get; set; }

       
    }
}
