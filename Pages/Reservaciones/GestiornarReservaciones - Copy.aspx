﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestiornarReservaciones.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.GestiornarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Gestionar Reservaciones</h2>
        </div>

        <div>

        </div>
   
        <div class="m my-3">
            <a href="CrearReservacion.aspx" class="btn btn-info text text-light">Nueva Resevación</a>
        </div>

        <div>
            <asp:GridView ID="grdGestionarReserv" runat="server">
                <Columns>
                    <asp:BoundField DataField=""/>
                </Columns>
            </asp:GridView>
        </div>

    </div>

</asp:Content>
