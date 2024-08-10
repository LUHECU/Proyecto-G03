<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Mensajes.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <div>
            <h2>Ha surgido un error</h2>
        </div>

        <div class="alert alert-danger">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>

        <div class="mt-3">
            <a class="btn btn-light btn-outline-secondary" href="../Reservaciones/GestionarReservaciones.aspx">Regresar</a>
        </div>

    </div>

</asp:Content>
