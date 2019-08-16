<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="RecetasAgroquimicasABM.aspx.cs" Inherits="Trabajo_Final_L4.Pages.RecetasAgroquimicasABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin: 40px 0px 40px 0px">
            Recetas Agroquimicas 
    </h1>

    <form method="post">
        <div class="form-group">
            <label for="fecha">Fecha</label>
            <input type="date" class="form-control" id="fecha" name="fecha" value="<%=fecha%>"/>
        </div>

        <div class="form-group">
            <label for="agenteFito">Agente Fitosanitario</label>
            <select id="selectAF" name="selectAF" class="form-control">
                <%foreach (var item in ListaAgenteFito) {%>
                    <option value="<%=item.Id%>" <%if (agenteFito == item.Id) {%> selected <%} %>><%=item.Nombre%></option>
                <%}%>                
            </select>  
        </div>

        <div class="form-group">
            <label for="productor">Productor</label>

            <select id="selectProduc" name="selectProduc" class="form-control">
                <%foreach (var item in ListaProductor) {%>
                    <option value="<%=item.Id%>" <%if (productor == item.Id) {%> selected <%} %>><%=item.Nombre%></option>
                <%}%>                
            </select>            
        </div>

        <div class="form-group">
            <label for="campoFinca">Campo Finca</label>
            <select id="selectCF" name="selectCF" class="form-control">
                <%foreach (var item in ListaCampoFinca) {%>
                   <option value="<%=item.Id%>" <%if (campoFinca == item.Id) {%> selected <%} %>><%=item.Calle%></option>
                <%}%>                
            </select>           
        </div>

        <div class="form-group">
            <label for="diagnostico">Diagnostico</label>
            <input type="text" class="form-control" id="diagnostico" name="diagnostico" value="<%=diagnostico%>"/>
        </div>

        <div class="form-group">
            <label for="estado">Estado</label>
            <input type="text" class="form-control" id="estado" name="estado" value="<%=estado%>"/>
        </div>
        
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
            Agregar Agroquimico
        </button>

        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Detalle</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                       <div>
                           <select id="selectD" name="selectD" class="form-control">   
                               <%foreach (var item in ListaDetalleReceta){%>
                                   <option value="<%=item.Id%>"<%if(marcaC == item.IdAgroquimico.ToString()){%> selected <%}%>></option>
                               <%}%>                              
                           </select>
                           <br />
                           <select id="selectCant" name="selectCant" class="form-control">
                               <option value="1">1</option>
                               <option value="2">2</option>
                               <option value="3">3</option>
                               <option value="4">4</option>
                               <option value="5">5</option>
                               <option value="6">6</option>
                               <option value="7">7</option>
                               <option value="8">8</option>
                               <option value="9">9</option>
                               <option value="10">10</option>                               
                           </select>
                       </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-primary">Guardar</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="text-center">
            <a class="btn btn-outline-danger" href="RecetasAgroquimicas.aspx" role="button">Cancelar</a>
            <input type="submit" class="btn btn-success" value="Guardar"/>
        </div>


    </form>

</asp:Content>
