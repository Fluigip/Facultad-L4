<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="RecetasAgroquimicas.aspx.cs" Inherits="Trabajo_Final_L4.Pages.RecetasAgroquimicas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                
            </tbody>            
        </table>    
    </div>



</asp:Content>
