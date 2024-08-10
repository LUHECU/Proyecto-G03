<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Mensajes.Confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div>

        <div>
            <h2>Se ha completado el proceso</h2>
        </div>

        <div class="alert alert-success">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        <div class="mt-3">
             <asp:Button ID="btnGestionarReserv" runat="server" Text="Regresar" CssClass="btn btn-light btn-outline-secondary" OnClick="btnGestionarReserv_Click" Visible="false"/>
         </div>

         <div class="mt-3">
             <asp:Button ID="btnListaHab" runat="server" Text="Regresar" CssClass="btn btn-light btn-outline-secondary" OnClick="btnListaHab_Click" Visible="false"/>
         </div>

    </div>

</asp:Content>
