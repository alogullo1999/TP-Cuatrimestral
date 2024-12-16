using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class GestionVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCliente();
                CargarProductos();
                CargarEmpleado();

            }

        }



        private void CargarCliente()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ddlCliente.DataSource = clienteNegocio.listarCliente();
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();
        }

        private void CargarEmpleado()
        {
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
            ddlEmpleado.DataSource = empleadoNegocio.Listar();
            ddlEmpleado.DataTextField = "Nombre";
            ddlEmpleado.DataValueField = "IdEmpleado";
            ddlEmpleado.DataBind();
        }

        private void CargarProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            ddlProducto.DataSource = productoNegocio.listarProducto();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";

            ddlProductoPrecio.DataTextField = "Precio";
            ddlProducto.DataValueField = "Precio";

            ddlProducto.DataBind();


         
        }

        private int GenerarIdVenta()
        {
            if (Session["IdDetalleVenta"] == null)
            {

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT ISNULL(MAX(IdDetalleVenta), 0) + 1 AS NuevoIdVenta FROM DetalleVentas");
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    int nuevoIdVenta = (int)datos.Lector["NuevoIdVenta"];
                    Session["IdDetalleVenta"] = nuevoIdVenta; 
                    return nuevoIdVenta;
                }
            }

            return (int)Session["IdDetalleVenta"]; 
        }


        private void MostrarResumenVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta(@"
            SELECT dv.IdProducto, p.Nombre AS Producto, dv.Cantidad, dv.PrecioUnitario, (dv.Cantidad * dv.PrecioUnitario) AS Total
            FROM DetalleVentas dv
            INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
            WHERE dv.IdDetalleVenta = @IdDetalleVenta");
                datos.setearParametro("@IdDetalleVenta", idVenta);

                datos.EjecutarLectura();
                dt.Load(datos.Lector);

                gvResumenVenta.DataSource = dt;
                gvResumenVenta.DataBind();
            }
            catch 
            {
                lblError.Text = "Ocurrió un error al cargar el resumen de la venta.";
                lblError.CssClass = "text-danger"; 
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
       
                int idDetalleVenta = GenerarIdVenta();
                int idEmpleado = int.Parse(ddlEmpleado.SelectedValue);
                int idCliente = int.Parse(ddlCliente.SelectedValue);
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                int sabores = int.Parse(txtSabores.Text);
                decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text);

                datos.setearConsulta(@"
            INSERT INTO DetalleVentas (IdDetalleVenta, FechaVenta, IdCliente, IdEmpleado, IdProducto, Sabores, Cantidad, PrecioUnitario)
            VALUES (@IdDetalleVenta, GETDATE(), @IdCliente, @IdEmpleado, @IdProducto, @Sabores, @Cantidad, @PrecioUnitario)");

                datos.setearParametro("@IdDetalleVenta", idDetalleVenta);
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@PrecioUnitario", precioUnitario);
                datos.setearParametro("@Sabores", sabores);

                datos.ejecutarAccion();

                MostrarResumenVenta(idDetalleVenta);
            }
            catch 
            {
                lblError.Text = "Error al agregar venta, revisar stock ";
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (Session["IdDetalleVenta"] != null)
                {
                    int idDetalleVenta = (int)Session["IdDetalleVenta"];

                    Session["IdDetalleVenta"] = null;
                    gvResumenVenta.DataSource = null;
                    gvResumenVenta.DataBind();

 
                    ddlCliente.SelectedIndex = 0;
                    ddlEmpleado.SelectedIndex = 0;
                    ddlProducto.SelectedIndex = 0;
                    txtCantidad.Text = string.Empty;
                    txtSabores.Text = string.Empty;
                    txtPrecioUnitario.Text = string.Empty;
                }
                else
                {
                    lblError.Text = "No se econtro venta activa";
                    lblError.Visible = true;
                }
            }
            catch 
            {
                lblError.Text = "Error al finalizar la venta";
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}