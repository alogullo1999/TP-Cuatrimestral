using dominio;
using negocio;
using System;
using System.Data;
using System.Web.UI;

namespace Heladeria
{
    public partial class Factura : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdVenta.Text, out int idDetalleVenta))
            {
                CargarFactura(idDetalleVenta);
            }
            else
            {
                lblError.Text = "Ingerse un ID Valido";
                lblError.Visible = true;
            }
        }

        private void CargarFactura(int idDetalleVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    SELECT 
                        dv.FechaVenta,
                        c.Nombre AS Cliente, 
                        c.Ciudad,
                        c.Email,
                        p.Nombre AS Producto, 
                        dv.Cantidad, 
                        dv.PrecioUnitario,
                        (dv.Cantidad * dv.PrecioUnitario) AS Subtotal
                    FROM DetalleVentas dv 
                    INNER JOIN Clientes c ON dv.IdCliente = c.IdCliente 
                    INNER JOIN Productos p ON dv.IdProducto = p.IdProducto 
                    WHERE dv.idDetalleVenta = @idDetalleVenta");

                datos.setearParametro("@idDetalleVenta", idDetalleVenta);
                datos.EjecutarLectura();

       
                if (!datos.Lector.HasRows)
                {
                    lblError.Text = "No se encontraron datos para el ID Seleccionado";
                    lblError.Visible = true;
                    return;
                }


                DataTable dt = new DataTable();
                dt.Load(datos.Lector);

  
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0]; 
                    lblNumeroFactura.Text = $"FAC-{idDetalleVenta}";
                    lblFechaVenta.Text = Convert.ToDateTime(row["FechaVenta"]).ToString("dd/MM/yyyy");
                    lblNombreCliente.Text = row["Cliente"].ToString();
                    lblCiudadCliente.Text = row["Ciudad"].ToString();
                    lblEmailCliente.Text = row["Email"].ToString();
                }

                rptDetalleProductos.DataSource = dt;
                rptDetalleProductos.DataBind();

                decimal subtotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    subtotal += Convert.ToDecimal(row["Subtotal"]);
                }

                lblSubtotal.Text = subtotal.ToString("C");
                lblIVA.Text = (subtotal * 0.21m).ToString("C");
                lblTotal.Text = (subtotal * 1.21m).ToString("C");
            }
            catch 
            {
                lblError.Text = "Error al cargar";
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
