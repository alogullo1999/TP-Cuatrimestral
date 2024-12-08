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
                CargarStock();
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
            ddlProducto.DataBind();
        }



        protected void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                int idEmpleado = int.Parse(ddlEmpleado.SelectedValue);
                int idCliente = int.Parse(ddlCliente.SelectedValue);
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                int sabores = int.Parse(txtSabores.Text);
                decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text);


                datos.setearConsulta(@"INSERT INTO DetalleVentas (FechaVenta, IdCliente, IdEmpleado, IdProducto, Sabores, Cantidad, PrecioUnitario)

                               VALUES (GETDATE(), @IdCliente, @IdEmpleado, @IdProducto, @Sabores, @Cantidad, @PrecioUnitario)");

                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@IdEmpleado", idEmpleado);
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@PrecioUnitario", precioUnitario);
                datos.setearParametro("@Sabores", sabores);

                datos.ejecutarAccion();
                CargarStock();



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al registrar venta: {ex.Message}');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




        private void CargarStock()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta("select  s.IdProducto,  p.Codigo,  p.Descripcion,  s.Cantidad,  s.FechaActualizacion  from Stock s inner  join Productos p  on s.IdProducto = p.IdProducto");
                datos.EjecutarLectura();
                dt.Load(datos.Lector);

                gvStock.DataSource = dt;
                gvStock.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al cargar compras: {ex.Message}');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}