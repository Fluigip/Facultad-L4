<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Agroquimicos.aspx.cs" Inherits="Trabajo_Final_L4.Pages.Agroquimicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="../Scripts/AgroquimicosLista.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1 style="margin: 40px 0px 40px 0px">
            Agroquimicos
            <a href="AgroquimicosABM.aspx" class="btn btn-primary float-right" role="button">Agregar</a>       
        </h1>
        <table id="table" style="width: 100%">
            <thead>
                <tr>
                    <th>Marca Comercial</th>
                    <th style="width: 10%">Codigo</th>
                    <th style="width: 15%">Principio Activo</th>
                    <th style="width: 15%">Tipo Envase</th>
                    <th style="width: 16%">Capacidad Envase</th>
                    <th style="width: 16%">Unidad de Medida</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in ListaAgroquimicos) {%>
                    <tr>
                        <th><%=item.marcaComercial%></th>
                        <th><%=item.codigo%></th>
                        <th><%=item.principioActivo%></th>
                        <th><%=item.tipoEnvase%></th>
                        <th><%=item.capacidadEnvase%></th>
                        <th><%=item.unidadMedida%></th>
                        <td>
                            <div class="btn-group" role="group" aria-label="Acciones">
                              <a href="AgroquimicosABM.aspx?id=<%=item.idAgroquimico %>" class="btn btn-outline-success" role="button">Editar</a>       
                              <button type="button" class="btn btn-outline-danger btnDelete" data-id="<%=item.idAgroquimico %>">Eliminar</button>
                            </div>
                        </td>
                    </tr>
                <%}%>
            </tbody>
        </table>    
    </div>
    
</asp:Content>
