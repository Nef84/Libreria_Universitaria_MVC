<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Libreria_Universitaria.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de productos - Librería Universitaria</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f3f3f3;
        }

        .contenedor {
            width: 700px;
            margin: 30px auto;
            background-color: #ffffff;
            border: 1px solid #cccccc;
            padding: 20px 25px;
        }

        h2 {
            margin-top: 0;
        }

        .subtitulo {
            font-size: 12px;
            margin-bottom: 10px;
        }

        .linkVolver {
            margin-top: 10px;
            display: inline-block;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">

            <h2>Consulta de productos (datos de ejemplo)</h2>

            <asp:Label ID="lblSesion" runat="server" CssClass="subtitulo"></asp:Label>
            <br />
            <asp:Label ID="lblSubtitulo" runat="server" CssClass="subtitulo"></asp:Label>
            <br />

            <asp:GridView ID="gvProductos" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="No hay productos para mostrar.">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio ($)" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                </Columns>
            </asp:GridView>

            <asp:HyperLink ID="hlVolver" runat="server"
                CssClass="linkVolver"
                NavigateUrl="~/Default.aspx"
                Text="Volver al inicio"></asp:HyperLink>

        </div>
    </form>
</body>
</html>
