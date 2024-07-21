<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Detalle de Reservación</h2>
        </div>

        <div>
            <asp:GridView ID="grdMisReserv" runat="server">
                
                
            </asp:GridView>
        </div>
        <asp:ListView ID="ListView1" runat="server"></asp:ListView>
    </div>

</asp:Content>
