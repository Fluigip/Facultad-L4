<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="VentaAgroquimicaABM.aspx.cs" Inherits="Trabajo_Final_L4.Pages.VentaAgroquimicaABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Scripts/VentaAgroLista.js">
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <h1 style="margin: 40px 0px 40px 0px">
        Compra de Agroquimicas
   </h1>

   <form method="post">

       <input type="hidden" id="accion" name="accion" value="guardar"/>
            
            <h3>Datos del Cliente: </h3>
            <hr />

            <div class="form-group">
                <label for="nombreCliente">Nombre</label>
                <input type="text" class="form-control" id="nombreCliente" name="nombreCliente" value=""/>
            </div>

           <div class="form-group">
                <label for="apellidoCliente">Apellido</label>
                <input type="text" class="form-control" id="apellidoCliente" name="apellidoCliente" value=""/>
           </div>

           <div class="form-group">
                <label for="direccionCliente">Direccion Cliente</label>
                <input type="text" class="form-control" id="direccionCliente" name="direccionCliente" value=""/>
           </div>

           <div class="form-group">
                <label for="telefonoCliente">Telefono Cliente</label>
                <input type="text" class="form-control" id="telefonoCliente" name="telefonoCliente" value=""/>
           </div>

           <h3>Datos de la empresa: </h3>
           <hr />

           <div class="form-group">
                <label for="empresaCliente">Nombre de la Empresa:</label>
                <input type="text" class="form-control" id="empresaCliente" name="empresaCliente" value=""/>
           </div>

           <div class="form-group">
                <label for="direccionEmpresa">Direccion de la Empresa:</label>
                <input type="text" class="form-control" id="direccionEmpresa" name="direccionEmpresa" value=""/>
           </div>
            
           <div class="form-group">
                <label for="codigoPostalEmpresa">Codigo Postal:</label>
                <input type="text" class="form-control" id="codigoPostalEmpresa" name="codigoPostalEmpresa" value=""/>
           </div>

           <div class="form-group">
                <label for="telefonoEmpresa">Telefono de la Empresa:</label>
                <input type="text" class="form-control" id="telefonoEmpresa" name="telefonoEmpresa" value=""/>
           </div>

           <h3>Productos: </h3>
           <hr />
         
           <%-- Lista de Agroquimico --%>
           <div class="row agroquimico-detalle">
               <div class="col-5">
                    <label for="listaAgroquimico">Agroquimicos</label>
                    <select id="agroquimico" name="agroquimico" class="form-control">
                        <option disabled selected>Seleccione un agroquimico</option>
                        <%foreach (var item in ListaAgro){%>
                              <option value="<%=item.idAgroquimico%>" <%if(marcaComercial == item.idAgroquimico.ToString()){%> selected <%}%>><%=item.marcaComercial%></option>
                        <%}%>                              
                    </select>
               </div>
               <div class="col-3">
                 <label for="cantidadProducto">Cantidad</label>
                 <input type="text" class="form-control" id="cantidadProducto" name="cantidadProducto" value=""/>
               </div>
               <div class="col-3">
                 <label for="precioProducto">Precio:</label>
                 <input type="text" class="form-control" id="precioProducto" name="precioProducto" value=""/>
               </div>
               <div class="col-1">
                   <button type="button" class="btn btn-primary crear-Producto" style="margin-top: 30px;">
                       Agregar
                   </button>
               </div>
          </div>
          <br />
             
               <%-- Tabla productos --%>
               <table id="table-agroquimicos" class="table table-bordered table-condensed table-striped mt-2">
                      <thead>
                             <tr>
                                  <th class="valign-middle text-align-center" style="width: 100px; text-align: center;">Codigo</th>
                                  <th class="valign-middle text-align-center" style="width: 200px; text-align: center;">Marca Comercial</th>
                                  <th class="valign-middle text-align-center" style="width: 100px; text-align: center;">Capacidad</th>
                                  <th class="valign-middle text-align-center" style="width: 160px; text-align: center;">Unidad de Medida</th>
                                  <th class="valign-middle text-align-center" style="width: 160px; text-align: center;">Precio</th>
                                  <th class="valign-middle text-align-center" style="width: 70px; text-align: center;">
                                      <button type="button" class="btn btn-primary agregar-Producto" style="margin-top: -8px; margin-bottom: -6px;">
                                            Nuevo
                                      </button>
                                      <%--BOTONES ACCIONES--%>
                                  </th>
                             </tr>
                      </thead>
                      <tbody>
                      </tbody>
               </table>
          
          <div class="text-center">
            <a class="btn btn-outline-danger" href="VentaAgroquimico.aspx" role="button">Cancelar</a>
            <input type="submit" class="btn btn-success" value="Guardar"/>
          </div>
          <br />
   </form>





</asp:Content>
