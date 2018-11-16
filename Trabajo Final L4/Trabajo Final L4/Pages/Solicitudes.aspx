<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="Trabajo_Final_L4.Pages.Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/SolicitudesLista.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1 style="margin: 40px 0px 40px 0px">
            Solicitudes
            <a href="SolicitudesABM.aspx" class="btn btn-primary float-right" role="button">Agregar</a>       
        </h1>    
        <table id="tableSolicitud" style="width: 100%">
            <thead>
                <tr>                   
                    <th style="width: 20%">Fecha</th>
                    <th style="width: 20%">Productor</th>
                    <th style="width: 20%">Campo Finca</th>
                    <th style="width: 20%">Agente Fitosanitario</th>
                    <th style="width: 20%">Estado</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in  ListaSolicitudes) {%>
                    <tr>
                        <th><%=item.fecha%></th>
                        <th><%=item.Productor%></th>
                        <th><%=item.CampoFinca.Calle%></th>
                        <th><%=item.AgenteFitosanitario.Nombre%></th>
                        <th><%=item.estado%></th>                       
                        <td>
                            <div class="btn-group" role="group" aria-label="Acciones">
                              <a href="SolicitudesABM.aspx" class="btn btn-outline-success" role="button">Editar</a>       
                              <button type="button" class="btn btn-outline-danger btnDelete" data-id="<%=item.id %>">Eliminar</button>
                            </div>
                        </td>
                    </tr>
                <%}%>
            </tbody>            
        </table>    
    </div>
</asp:Content>
