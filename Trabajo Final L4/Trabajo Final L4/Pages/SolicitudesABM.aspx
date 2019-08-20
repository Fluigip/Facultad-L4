<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudesABM.aspx.cs" Inherits="Trabajo_Final_L4.Pages.SolicitudesABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin: 40px 0px 40px 0px">
            Solicitud
    </h1>

    <form method="post">
        <input type="hidden" id="accion" name="accion" value="guardar"/>

        <div class="form-group">
            <label for="fecha">Fecha</label>
            <input type="date" class="form-control" id="fecha" name="fecha" value="<%=fecha%>"/>
        </div>
        
        <div class="form-group">
            <label for="productor">Productor</label>

            <select id="selectProductor" name="selectProductor" class="form-control">
                <%foreach (var item in ListaProductor) {%>
                    <option value="<%=item.idProductor%>" <%if (productor == item.idProductor) {%> selected <%} %>><%=item.nombre%></option>
                <%}%>                
            </select>            
        </div>

         <div class="form-group">
            <label for="campoFinca">Campo Finca</label>
            <select id="selectCampoF" name="selectCampoF" class="form-control">
                <%foreach (var item in ListaCampoFinca) {%>
                   <option value="<%=item.idCampoFinca%>" <%if (campoFinca == item.idCampoFinca) {%> selected <%} %>><%=item.calle%></option>
                <%}%>                
            </select>           
        </div>

        <div class="form-group">
            <label for="agenteFito">Agente Fitosanitario</label>
            <select id="selectAgenteF" name="selectAgenteF" class="form-control">
                <%foreach (var item in ListaAgenteFito) {%>
                    <option value="<%=item.idAgenteFitosanitario%>" <%if (agenteFitosanitario == item.idAgenteFitosanitario) {%> selected <%} %>><%=item.nombre%>
                <%}%>                
            </select>  
        </div>

        <div class="form-group">
            <label for="estado">Estado</label>
            <input type="text" class="form-control" id="estado" name="estado" value="<%=estado%>"/>
        </div>

        <div class="text-center">
            <a class="btn btn-outline-danger" href="Solicitudes.aspx" role="button">Cancelar</a>
            <input type="submit" class="btn btn-success" value="Guardar"/>
        </div>
    </form>
   

</asp:Content>
