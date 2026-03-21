using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using Libreria_Universitaria.AccesoDatos;


namespace Libreria_Universitaria
{
    public partial class Categorias : System.Web.UI.Page
    {
        CategoriaDB db = new CategoriaDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        private void CargarGrid()
        {
            gvCategorias.DataSource = db.ObtenerTodas();
            gvCategorias.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int id = int.Parse(hfCategoriaID.Value);

            if (id == 0)
            {
                db.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "✔ Categoría guardada correctamente.";
            }
            else
            {
                db.Actualizar(id, txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "✔ Categoría actualizada correctamente.";
            }

            LimpiarFormulario();
            CargarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            lblMensaje.Text = "";
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = (int)gvCategorias.DataKeys[e.NewEditIndex].Value;
            DataTable dt = db.ObtenerTodas();
            DataRow fila = dt.Select("CategoriaID = " + id)[0];

            hfCategoriaID.Value = id.ToString();
            txtNombre.Text = fila["Nombre"].ToString();
            txtDescripcion.Text = fila["Descripcion"].ToString();

            lblMensaje.ForeColor = Color.Blue;
            lblMensaje.Text = "Editando categoría — modifica los datos y presiona Guardar.";

            CargarGrid();
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvCategorias.DataKeys[e.RowIndex].Value;
            try
            {
                db.Eliminar(id);
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "✔ Categoría eliminada correctamente.";
            }
            catch
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "✖ No se puede eliminar: hay libros asociados a esta categoría.";
            }
            CargarGrid();
        }

        protected void gvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategorias.EditIndex = -1;
            CargarGrid();
        }

        private void LimpiarFormulario()
        {
            hfCategoriaID.Value = "0";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}