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
            <a class="btn btn-success" href="ListaPersonas.aspx">Regresar</a>
        </div>

    </div>

</asp:Content>
