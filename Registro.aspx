<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Libreria_Universitaria.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar Producto - Librería Universitaria</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>Registrar producto</h2>

            <asp:ValidationSummary ID="vsErrores" runat="server" />

            Código:
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCodigo" runat="server"
                ControlToValidate="txtCodigo"
                ErrorMessage="El código es obligatorio."></asp:RequiredFieldValidator>
            <br /><br />

            Nombre / Libro:
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                ControlToValidate="txtNombre"
                ErrorMessage="El nombre del producto es obligatorio."></asp:RequiredFieldValidator>
            <br /><br />

            Categoría:
            <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCategoria" runat="server"
                ControlToValidate="ddlCategoria"
                InitialValue=""
                ErrorMessage="Debe seleccionar una categoría."></asp:RequiredFieldValidator>
            <a href="Categorias.aspx">Categorias.aspx</a><br /><br />

            Precio ($):
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server"
                ControlToValidate="txtPrecio"
                ErrorMessage="El precio es obligatorio."></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvPrecio" runat="server"
                ControlToValidate="txtPrecio"
                MinimumValue="0.01"
                MaximumValue="1000"
                Type="Double"
                ErrorMessage="El precio debe estar entre 0.01 y 1000."></asp:RangeValidator>
            <br /><br />

            Cantidad en stock:
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCantidad" runat="server"
                ControlToValidate="txtCantidad"
                ErrorMessage="La cantidad es obligatoria."></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvCantidad" runat="server"
                ControlToValidate="txtCantidad"
                MinimumValue="0"
                MaximumValue="1000"
                Type="Integer"
                ErrorMessage="La cantidad debe ser un número entre 0 y 1000."></asp:RangeValidator>
            <br /><br />

            Activo en inventario:
            <asp:CheckBox ID="chkActivo" runat="server" Checked="true" />
            <br /><br />

            <asp:Button ID="btnRegistrar" runat="server"
                Text="Registrar"
                OnClick="btnRegistrar_Click" />
            <br /><br />

            <asp:Label ID="lblResultado" runat="server"></asp:Label>
            <br /><br />

            <asp:HyperLink ID="hlVolver" runat="server"
                NavigateUrl="~/Default.aspx"
                Text="Volver al inicio"></asp:HyperLink>

        </div>
    </form>
</body>
</html>
