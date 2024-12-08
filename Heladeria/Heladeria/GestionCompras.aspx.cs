using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Heladeria
{
    public partial class GestionCompras : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                CargarProductos();
                CargarStock();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            ddlProveedor.DataSource = proveedorNegocio.listarProveedor();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();
        }

        private void CargarProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            ddlProducto.DataSource = productoNegocio.listarProducto();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();
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

        protected void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                int idProveedor = int.Parse(ddlProveedor.SelectedValue);
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text);



                datos.setearConsulta(@"INSERT INTO DetalleCompras(FechaCompra, IdProveedor, IdProducto, Cantidad, PrecioUnitario)
                                     VALUES(GETDATE(), @IdProveedor, @IdProducto, @Cantidad, @PrecioUnitario)");
                datos.setearParametro("@IdProveedor", idProveedor);
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@PrecioUnitario", precioUnitario);

                datos.ejecutarAccion();
                CargarStock();



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al registrar compra: {ex.Message}');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
