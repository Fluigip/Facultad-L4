<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AgroquimicosABM.aspx.cs" Inherits="Trabajo_Final_L4.Pages.AgroquimicosABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <h1 style="margin: 40px 0px 40px 0px">
            Agroquimico
        </h1>

    <form method="post">
        <input type="hidden" id="accion" name="accion" value="guardar"/>
        <div class="form-group">
            <label for="marcaComercial">Marca Comercial</label>
            <input type="text" class="form-control" id="mComercial" name="mComercial" value="<%=marcaComercial %>"/>
        </div>
        <div class="form-group">
            <label for="codigo">Codigo</label>
            <input type="text" class="form-control" id="codigo" name="codigo" value="<%=codigo %>"/>
        </div>
        <div class="form-group">
            <label for="principioActivo">Principio Activo</label>
            <input type="text" class="form-control" id="principioA" name="principioA" value="<%=principioActivo %>"/>
        </div>
        <div class="form-group">
            <label for="tipoEnvase">Tipo Envase</label>
            <input type="text" class="form-control" id="tEnvase" name="tEnvase" value="<%=tipoEnvase %>"/>
        </div>
        <div class="form-group">
            <label for="capacidadEnvase">Capacidad Envase</label>
            <input type="text" class="form-control" id="capacidadE" name="capacidadE" value="<%=capacidadEnvase %>"/>
        </div>
        <div class="form-group">
            <label for="uMedida">Unidad de Medida</label>
            <input type="text" class="form-control" id="uMedida" name="uMedida" value="<%=unidadMedida %>"/>
        </div>

        <div class="text-center">
            <a class="btn btn-outline-danger" href="Agroquimicos.aspx" role="button">Cancelar</a>
            <input type="submit" class="btn btn-success" value="Guardar"/>
        </div>
    </form>

</asp:Content>
