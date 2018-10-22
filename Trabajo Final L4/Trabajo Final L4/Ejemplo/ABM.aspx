<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ABM.aspx.cs" Inherits="Trabajo_Final_L4.Ejemplo.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ABM.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin: 40px 0px 40px 0px">
        <%if(Ejemplo == null) {%>
            Agregar
        <%} else {%>
            Editar
        <%}%>
        ejemplo
    </h1>
    <form method="post">
        <input type="hidden" id="accion" name="accion" value="guardar"/>
        <div class="form-group">
            <label for="nombre">Nombre</label>
            <input type="text" class="form-control" id="nombre" name="nombre" value="<%=Nombre %>"/>
        </div>
        <div class="form-group">
            <label for="descripcion">Descripción</label>
            <input type="text" class="form-control" id="descripcion" name="descripcion" value="<%=Descripcion %>"/>
        </div>
        <div class="text-center">
            <a class="btn btn-outline-danger" href="Lista.aspx" role="button">Cancelar</a>
            <input type="submit" class="btn btn-success" value="Guardar"/>
        </div>
    </form>
</asp:Content>
