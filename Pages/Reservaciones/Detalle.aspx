<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Detalle de Reservación</h2>
        </div>


        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>


        <div class="row">

            <div class="col col-sm-6 col-md-4 col-lg-2">
                 <div class="mt-4">
                     <asp:Button ID="btnEditarReserv" runat="server" Text="Editar reservación" CssClass="btn btn-info text text-light"/>
                 </div>
             </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                 <div class="mt-4">
                     <asp:Button ID="btnCancelarReserv" runat="server" Text="Cancelar reservacion" CssClass="btn btn-info text text-light"/>
                 </div>
             </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                 <div class="mt-4">
                     <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-info text text-light"/>
                 </div>
             </div>

        </div>


        <div>
            <asp:GridView ID="grdMisReserv" runat="server">
                <Columns>
                    <asp:BoundField DataField=""/>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>

</asp:Content>
