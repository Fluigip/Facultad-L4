<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="RecetasAgroquimicas.aspx.cs" Inherits="Trabajo_Final_L4.Pages.RecetasAgroquimicas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/RecetaAgroLista.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 style="margin: 40px 0px 40px 0px">
            Recetas Agroquimicas
            <a href="RecetasAgroquimicasABM.aspx" class="btn btn-primary float-right" role="button">Agregar</a>       
        </h1>    
        <table id="tableRecetasAgro" style="width: 100%">
            <thead>
                <tr>                   
                    <th>Fecha</th>
                    <th style="width: 10%">Agente Fitosanitario</th>
                    <th style="width: 10%">Productor</th>
                    <th style="width: 15%">Campo Finca</th>
                    <th style="width: 15%">Diagnostico</th>
                    <th style="width: 15%">Estado</th>
                    <th style="width: 15%">Vendedor</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in ListaRecetasAgro) {%>
                    <tr>
                        <td><%=item.fechaReceta.ToString("dd/MM/yyyy")%></td>
                        <td><%=item.AgenteFitosanitario.nombre%></td>
                        <td><%=item.Productor.nombre%></td>
                        <td><%=item.CampoFinca.calle%></td>
                        <td><%=item.diagnostico%></td>
                        <td><%=item.estado%></td>
                        <td><%=item.Vendedor.razonSocial%></td>
                        <td>
                            <div class="btn-group" role="group" aria-label="Acciones">
                              <a href="RecetasAgroquimicasABM.aspx?id=<%=item.idRecetaAgroquimica %>" class="btn btn-outline-success" role="button">Editar</a>       
                              <button type="button" class="btn btn-outline-danger btnDelete" data-id="<%=item.idRecetaAgroquimica %>">Eliminar</button>
                            </div>
                        </td>
                    </tr>
                <%}%>
            </tbody>
        </table>
    </div>
</asp:Content>
