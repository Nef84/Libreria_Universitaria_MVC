using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libreria_Universitaria
{
    public partial class Registro : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.Items.Clear();
                ddlCategoria.Items.Add(new ListItem("-- Seleccione --", ""));
                ddlCategoria.Items.Add(new ListItem("Libro de texto", "LIB"));
                ddlCategoria.Items.Add(new ListItem("Cuaderno", "CUA"));
                ddlCategoria.Items.Add(new ListItem("Accesorio", "ACC"));
                ddlCategoria.Items.Add(new ListItem("Otro", "OTR"));

                if (Session["UltimoProducto"] != null)
                {
                    lblResultado.Text = "Último producto registrado: " +
                                        Session["UltimoProducto"].ToString();
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string categoria = ddlCategoria.SelectedItem.Text;
                string precio = txtPrecio.Text.Trim();
                string cantidad = txtCantidad.Text.Trim();
                string activo = chkActivo.Checked ? "Sí" : "No";

                Session["UltimoProducto"] = nombre;
                ViewState["UltimoPrecio"] = precio;

                lblResultado.Text = "Registro exitoso\n" +
                                    "Código: " + codigo + "\n" +
                                    "Nombre: " + nombre + "\n" +
                                    "Categoría: " + categoria + "\n" +
                                    "Precio: $" + precio + "\n" +
                                    "Cantidad: " + cantidad + "\n" +
                                    "Activo: " + activo;
            }
        }
    }
}
