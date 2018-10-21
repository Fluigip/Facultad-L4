<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Agroquimicos.aspx.cs" Inherits="Trabajo_Final_L4.Pages.Agroquimicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
       $(document).ready(function () {
           $('#example').DataTable();
       });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="lblAgro" runat="server" Text="Agroquimicos" Font-Bold="true" Font-Size="X-Large"/>
    </div>
    
    <div id="tablaFiltro">
        <asp:Table ID="tbAgroquimicos" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Marca Comercial</asp:TableHeaderCell>
                <asp:TableHeaderCell>Codigo</asp:TableHeaderCell>
                <asp:TableHeaderCell>Principio Activo</asp:TableHeaderCell>
                <asp:TableHeaderCell>Tipo Envase</asp:TableHeaderCell>
                <asp:TableHeaderCell>Capacidad Envase</asp:TableHeaderCell>
                <asp:TableHeaderCell>Unidad de Medida</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    
</asp:Content>
