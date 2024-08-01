<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.CrearReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Crear Reservación</h2>
        </div>

        
        <div class=" my-4">
            <div class="my-2">
                <asp:Label ID="lblHotel" runat="server" Text="Hotel"></asp:Label>
            </div>

            <div>
                <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div>
            <div class="my-2">
                <asp:Label ID="lblPersona" runat="server" Text="Cliente"></asp:Label>
            </div>

            <div>
                <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row my-4">

            <div class="col col-sm-12 col-md-4 col-lg-2">
                <div class="my-2">
                    <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha de Entrada"></asp:Label>
                </div>

                <div>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col col-sm-12 col-md-4 col-lg-2">
                <div class="my-2">
                    <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de Salida"></asp:Label>
                </div>

                <div>
                    <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            
        </div>

        <div class="row my-4">

            <div class="col col-sm-12 col-md-4 col-lg-2">
                <div class="my-2">
                    <asp:Label ID="lblNumAdultos" runat="server" Text="Número de adultos"></asp:Label>
                </div>

                <div>
                    <asp:TextBox ID="txtNumAdultos" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col col-sm-12 col-md-4 col-lg-2">
                <div class="my-2">
                    <asp:Label ID="lblNumNinhos" runat="server" Text="Número de niños"></asp:Label>
                </div>

                <div>
                    <asp:TextBox ID="txtNumNinhos" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

    
        </div>

        <div class="row">

            <div class="col col-sm-22 col-md-2 col-lg-1 my-1">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success"/>
            </div>

            <div class="col col-sm-2 col-md-2 col-lg-1 my-1">
                <a href="MisReservaciones.aspx" class="btn btn-primary">Regresar</a>
            </div>

        </div>


    </div>


</asp:Content>
