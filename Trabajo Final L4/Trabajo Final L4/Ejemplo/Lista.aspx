<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Trabajo_Final_L4.Ejemplo.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lista.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 style="margin: 40px 0px 40px 0px">
            Ejemplos
            <a href="ABM.aspx" class="btn btn-primary float-right" role="button">Agregar</a>       
        </h1>    
        <table id="table">
            <thead>
                <tr>
                    <th style="width: 20%">Nombre</th>
                    <th style="width: 70%">Descripción</th>
                    <th style="width: 10%"></th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in Ejemplos) {%>
                    <tr>
                        <td><%=item.Nombre %></td>
                        <td><%=item.Descripcion %></td>
                        <td>
                            <div class="btn-group" role="group" aria-label="Acciones">
                              <a href="ABM.aspx?id=<%=item.Id %>" class="btn btn-outline-success" role="button">Editar</a>       
                              <button type="button" class="btn btn-outline-danger">Eliminar</button>
                            </div>
                        </td>
                    </tr>
                <%}%>
            </tbody>
        </table>
    </div>  
</asp:Content>