<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="VentaAgroquimico.aspx.cs" Inherits="Trabajo_Final_L4.Pages.VentaAgroquimico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <h1 style="margin: 40px 0px 40px 0px">
            Venta Agroquimicos
            <a href="VentaAgroquimicaABM.aspx" class="btn btn-primary float-right" role="button">Agregar</a>       
        </h1>
        <table id="tablaVenta" style="width: 100%">
            <thead>
                <tr>
                    <th style="width: 25%">Nombre</th>
                    <th style="width: 25%">Apellido</th>
                    <th style="width: 25%">Codigo de factura</th>
                    <th>Detalle</th>
                </tr>
            </thead>
            <tbody>

            </tbody>
        </table>
    </div>
</asp:Content>
