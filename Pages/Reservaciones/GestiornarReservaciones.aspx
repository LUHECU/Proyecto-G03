<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestiornarReservaciones.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.GestiornarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Gestionar Reservaciones</h2>
        </div>

        <div class="row">


            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha entrada"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtFechaEntrada"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha salida"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtFechaSalida"></asp:RequiredFieldValidator>
                </div>
            </div>

           <div class="col col-sm-6 col-md-4 col-lg-2">
               <div class="mb-3">
                    <asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="mt-4">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-info text text-light"/>
                </div>
            </div>

            <asp:CustomValidator ID="cvFechaSalida" runat="server" ErrorMessage="La fecha de salida debe ser mayor o igual a la de entrada" ControlToValidate="txtFechaSalida" OnServerValidate="cvFechaSalida_ServerValidate"></asp:CustomValidator>

        </div>
   
        <div class="m mt-4">
            <a href="CrearReservacion.aspx" class="btn btn-info text text-light">Nueva Resevación</a>
        </div>

        <div class="mt-3">
            <asp:GridView ID="grdGestReserv" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" CellPadding="10" >
                <Columns>
                    <asp:BoundField DataField=""/>
                </Columns>
            </asp:GridView>
        </div>

    </div>

</asp:Content>
