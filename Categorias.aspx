<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Libreria_Universitaria.Categorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body id="rfvNombre">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:HiddenField ID="hfCategoriaID" runat="server" Value="0" />
        <br />
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblNombre0" runat="server" Text="Descripciòn:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
&nbsp;
        <br />
        <br />
        <br />
       <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
<br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje: "></asp:Label>
        <br />
        <br />
      <asp:GridView ID="gvCategorias" runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="CategoriaID"
    OnRowEditing="gvCategorias_RowEditing"
    OnRowDeleting="gvCategorias_RowDeleting"
    OnRowCancelingEdit="gvCategorias_RowCancelingEdit">
    <Columns>
        <asp:BoundField DataField="CategoriaID" HeaderText="ID"          ReadOnly="true" />
        <asp:BoundField DataField="Nombre"      HeaderText="Nombre" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
    </Columns>
</asp:GridView>
        <br />
    </form>
</body>
</html>
