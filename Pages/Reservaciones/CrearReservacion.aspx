<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.CrearReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlContenido"  runat="server">
        <div class="container">

            <div class="mt-4 mb-4">
                <h1>Crear Reservación</h1>
            </div>

            <div >
                <asp:ValidationSummary ID="vsFechas" runat="server" DisplayMode="BulletList" HeaderText="Error al guardar" class="alert alert-danger tras"/>
            </div>

        
            <div class=" my-4">
                <div class="my-2">
                    <asp:Label ID="lblHotel" runat="server" Text="Hotel"></asp:Label>
                </div>

                <div>
                    <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvHotel" runat="server" ErrorMessage="Seleccione un hotel" ControlToValidate="ddlHotel" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div>
                <div class="my-2">
                    <asp:Label ID="lblPersona" runat="server" Text="Cliente"></asp:Label>
                </div>

                <div>
                    <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPersona" runat="server" ErrorMessage="Seleccione un cliente" ControlToValidate="ddlPersona" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row my-4">

                <div class="col col-sm-12 col-md-4 col-lg-2">
                    <div class="my-2">
                        <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha de Entrada"></asp:Label>
                    </div>

                    <div>
                        <asp:TextBox ID="txtFechaEntrada" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="cvFechaEntrada" runat="server" ErrorMessage="La fecha de entrada debe ser mayor a la actual" ControlToValidate="txtFechaEntrada" OnServerValidate="cvFechaEntrada_ServerValidate" ValidateEmptyText="true"  CssClass="text-danger"></asp:CustomValidator>
                    </div>
                </div>

                <div class="col col-sm-12 col-md-4 col-lg-2">
                    <div class="my-2">
                        <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de Salida"></asp:Label>
                    </div>

                    <div>
                        <asp:TextBox ID="txtFechaSalida" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="cvFechaSalida" runat="server" ErrorMessage="La fecha de salida no debe ser menor a la de entrada"  ControlToValidate="txtFechaSalida" OnServerValidate="cvFechaSalida_ServerValidate" ValidateEmptyText="true"  CssClass="text-danger"></asp:CustomValidator>
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
                        <asp:RequiredFieldValidator ID="rfvNumAdultos" runat="server" ErrorMessage="Debe ingresar al menos un aldulto" ControlToValidate="txtNumAdultos" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvNumeroAdultos" runat="server" ErrorMessage="El número de adultos debe ser igual o mayor a 1" ControlToValidate="txtNumAdultos" MinimumValue="1" MaximumValue="99999999999" CssClass="text-danger"></asp:RangeValidator>
                    </div>
                </div>

                <div class="col col-sm-12 col-md-4 col-lg-2">
                    <div class="my-2">
                        <asp:Label ID="lblNumNinhos" runat="server" Text="Número de niños"></asp:Label>
                    </div>

                    <div>
                        <asp:TextBox ID="txtNumNinhos" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        <asp:RangeValidator ID="rvNumeroNinhos" runat="server" ErrorMessage="El número de niños debe ser igual o mayor a 0" ControlToValidate="txtNumNinhos" MinimumValue="0" MaximumValue="99999999999" CssClass="text-danger"></asp:RangeValidator>
                    </div>
                </div>

    
            </div>

            <div class="row">

                <div class="col col-sm-22 col-md-2 col-lg-1 my-1">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" CausesValidation="true"/>
                </div>

                <div class="col col-sm-2 col-md-2 col-lg-1 my-1">
                    <a href="GestionarReservaciones.aspx" class="btn btn-primary">Regresar</a>
                </div>

            </div>


        </div>

    </asp:Panel>

    
    <asp:PlaceHolder ID="phAlerta" runat="server" Visible="false">
        <div class="card text-center position-fixed" style="top: 50%; left: 50%; transform: translate(-50%, -50%); width: 18rem;">
            <div class="card-body">
                <h5 class="card-title text-danger">Alerta</h5>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnContinuar" runat="server" Text="Continuar" CssClass="card-link btn btn-danger mt-2" OnClick="btnContinuar_Click"/>
                
            </div>
        </div>
                
    </asp:PlaceHolder>


</asp:Content>
