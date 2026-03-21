using Libreria_Universitaria.AccesoDatos;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Libreria_Universitaria
{
    public partial class Libros : System.Web.UI.Page
    {
        LibroDB dbLibro = new LibroDB();
        CategoriaDB dbCat = new CategoriaDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarGrid();
            }
        }

        private void CargarCategorias()
        {
            ddlCategoria.DataSource = dbCat.ObtenerTodas();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "CategoriaID";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("-- Selecciona --", "0"));
        }

        private void CargarGrid()
        {
            gvLibros.DataSource = dbLibro.ObtenerTodos();
            gvLibros.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int id = int.Parse(hfLibroID.Value);
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            decimal precio = decimal.Parse(txtPrecio.Text.Trim());
            int stock = int.Parse(txtStock.Text.Trim());
            int categoriaID = int.Parse(ddlCategoria.SelectedValue);

            if (id == 0)
            {
                dbLibro.Insertar(titulo, autor, precio, stock, categoriaID);
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "✔ Libro guardado correctamente.";
            }
            else
            {
                dbLibro.Actualizar(id, titulo, autor, precio, stock, categoriaID);
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "✔ Libro actualizado correctamente.";
            }

            LimpiarFormulario();
            CargarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            lblMensaje.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvLibros.DataSource = dbLibro.Buscar(txtBuscar.Text.Trim());
            gvLibros.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            CargarGrid();
        }

        protected void gvLibros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = (int)gvLibros.DataKeys[e.NewEditIndex].Value;
            DataRow fila = dbLibro.ObtenerPorID(id);

            if (fila != null)
            {
                hfLibroID.Value = id.ToString();
                txtTitulo.Text = fila["Titulo"].ToString();
                txtAutor.Text = fila["Autor"].ToString();
                txtPrecio.Text = fila["Precio"].ToString();
                txtStock.Text = fila["Stock"].ToString();

                CargarCategorias();
                ddlCategoria.SelectedValue = fila["CategoriaID"].ToString();

                lblMensaje.ForeColor = Color.Blue;
                lblMensaje.Text = "Editando libro — modifica los datos y presiona Guardar.";
            }
            CargarGrid();
        }

        protected void gvLibros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvLibros.DataKeys[e.RowIndex].Value;
            dbLibro.Eliminar(id);
            lblMensaje.ForeColor = Color.Green;
            lblMensaje.Text = "✔ Libro eliminado correctamente.";
            CargarGrid();
        }

        protected void gvLibros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLibros.EditIndex = -1;
            CargarGrid();
        }

        private void LimpiarFormulario()
        {
            hfLibroID.Value = "0";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            CargarCategorias();
            lblMensaje.ForeColor = Color.Green;
        }
    }
}