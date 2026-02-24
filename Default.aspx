<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Libreria_Universitaria._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Inventario – Librería Universitaria</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblTitulo" runat="server"
                Text="Sistema de Inventario - Librería Universitaria"></asp:Label>
            <br /><br />

            <asp:Label ID="lblIndicacion" runat="server"
                Text="Seleccione una opción:"></asp:Label>
            <br /><br />

            <asp:HyperLink ID="hlRegistro" runat="server"
                NavigateUrl="~/Registro.aspx"
                Text="Registrar producto"></asp:HyperLink>
            <br /><br />

            <asp:HyperLink ID="hlConsulta" runat="server"
                NavigateUrl="~/Home.aspx"
                Text="Consulta / Listado de productos"></asp:HyperLink>
            <br /><br />

            <asp:Label ID="lblGrupo" runat="server"
                Text="Grupo 4 - Programación 2"></asp:Label>

        </div>
    </form>
</body>
</html>
