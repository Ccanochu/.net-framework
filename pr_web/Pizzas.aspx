<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pizzas.aspx.cs" Inherits="pr_web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="txtName" CssClass="control-label">Name</asp:Label>
    <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="PizzaSize" CssClass="control-label"></asp:Label>
    <asp:DropDownList runat="server" ID="PizzaSize" CssClass="form-control">
        <asp:ListItem Value="">-- Select Size --</asp:ListItem>
        <asp:ListItem Value="Small">Small</asp:ListItem>
        <asp:ListItem Value="Medium">Medium</asp:ListItem>
        <asp:ListItem Value="Large">Large</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="IsGlutenFree" CssClass="control-label">Sin Gluten</asp:Label>
    <asp:RadioButtonList runat="server" ID="IsGlutenFree" CssClass="form-check-input">
        <asp:ListItem Text="Sí" Value="true"></asp:ListItem>
        <asp:ListItem Text="No" Value="false"></asp:ListItem>
    </asp:RadioButtonList>
</div>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="control-label">Price</asp:Label>
    <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" TextMode="Number" Step="0.01"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Button runat="server" Text="Create" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" />
        <asp:Button runat="server" Text="Update" CssClass="btn btn-success" ID="btnActualizar" OnClick="btnActualizar_Click"/>
        <asp:Label runat="server" ID="lbl_mensaje" CssClass="form-control"></asp:Label>


</div>
<asp:GridView ID="grid_pizzas" runat="server" AutoGenerateColumns="False" CssClass="table-condensed"
    DataKeyNames="id">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnVer" runat="server" Text="Ver" CommandName="Ver" OnClick="btnVer_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" OnClick="btnEliminar_Click" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="id" HeaderText="ID" />
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="tamanio" HeaderText="Tamaño" />
        <asp:TemplateField HeaderText="Sin Gluten">
            <ItemTemplate>
                <%# Convert.ToBoolean(Eval("gluten_checked")) ? "Sí" : "No" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="precio" HeaderText="Precio" />
    </Columns>
</asp:GridView>



    

</asp:Content>