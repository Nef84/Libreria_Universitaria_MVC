using System;
using System.Data;
using System.Web.UI;

namespace Libreria_Universitaria
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSubtitulo.Text = "Mostrando productos de ejemplo cargados en memoria.";

                if (Session["UltimoProducto"] != null)
                    lblSesion.Text = "Último producto registrado en esta sesión: " +
                                     Session["UltimoProducto"].ToString();

                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Categoria");
            tabla.Columns.Add("Precio", typeof(decimal));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Activo");

            tabla.Rows.Add("LIB-001", "Cálculo Diferencial e Integral", "Libro de texto", 45.99m, 20, "Sí");
            tabla.Rows.Add("LIB-002", "Introducción a la Programación", "Libro de texto", 38.50m, 15, "Sí");
            tabla.Rows.Add("CUA-001", "Cuaderno universitario 100 hojas", "Cuaderno", 5.25m, 80, "Sí");
            tabla.Rows.Add("ACC-001", "Calculadora científica Casio", "Accesorio", 32.00m, 12, "Sí");
            tabla.Rows.Add("OTR-001", "Resaltadores (pack x 5)", "Otro", 6.50m, 50, "No");

            gvProductos.DataSource = tabla;
            gvProductos.DataBind();
        }
    }
}
