<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="Libreria_Universitaria.Libros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:HiddenField ID="hfLibroID" runat="server" Value="0" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Resistro de libros."></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblTitulo" runat="server" Text="Titulo: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfValidator1" runat="server"
    ControlToValidate="txtTitulo"
    ErrorMessage="El título es obligatorio."
    ForeColor="Red" Display="Dynamic" />
        <br />
        <br />
        <asp:Label ID="lblAutor" runat="server" Text="Autor:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfValidator2" runat="server"
    ControlToValidate="txtAutor"
    ErrorMessage="El autor es obligatorio."
    ForeColor="Red" Display="Dynamic" />
        <br />
        <br />
        <asp:Label ID="lblPrecio" runat="server" Text="Precio: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="Validator3RF" runat="server"
    ControlToValidate="txtPrecio"
    ErrorMessage="El precio es obligatorio."
    ForeColor="Red" Display="Dynamic" />
&nbsp;&nbsp;&nbsp;
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrecio" MinimumValue="0.01" MaximumValue="9999.99" Type="Double" ErrorMessage="El precio debe estar entre 0.01 y 9999.99." ForeColor="Red" Display="Dynamic" />
        <br />
        <br />
        <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfdValidator4" runat="server"
    ControlToValidate="txtStock"
    ErrorMessage="El stock es obligatorio."
    ForeColor="Red" Display="Dynamic" />
&nbsp;&nbsp;&nbsp;
        <asp:RangeValidator ID="RGValidator2" runat="server"
    ControlToValidate="txtStock"
    MinimumValue="0" MaximumValue="10000" Type="Integer"
    ErrorMessage="El stock debe estar entre 0 y 10000."
    ForeColor="Red" Display="Dynamic" />
        <br />
        <br />
        <asp:Label ID="lblStock0" runat="server" Text="Categorìa:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCategoria" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="rfdValidator5" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <br />
       <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje: "></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
    OnClick="btnBuscar_Click" CausesValidation="false" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todos" 
    OnClick="btnMostrarTodos_Click" CausesValidation="false" />
        <br />
        <br />
        <asp:GridView ID="gvLibros" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
