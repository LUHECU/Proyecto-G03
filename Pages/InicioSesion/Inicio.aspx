<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoFinal_G03.Pages.InicioSesion.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mx-auto align-content-center text-center">

            <div class="mx-auto my-5 pb-4 w-50 bg-light ">
                <h2 class="text-bg-primary p-1">Inicio de Sesión</h2>
            

                <div class="mt-5 mb-2 h5">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico" ></asp:Label>
                </div>

                <div >
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control mx-auto"></asp:TextBox>
                </div>

                <div class="mt-4 mb-2 h5">
                    <asp:Label ID="lblClave" runat="server" Text="Contraseña" ></asp:Label>
                </div>

                <div >
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control mx-auto"></asp:TextBox>
                </div>

                <div class="text-danger">
                    <asp:Label ID="lblError" runat="server" Text="Correo o contraseña incorrectos" Visible="false"></asp:Label>
                </div>

                <div class="my-4 ">
                    <asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar Sesión" OnClick="btnInicioSesion_Click" CssClass="btn btn-primary"/>
                </div>

            </div>

        </div>

    </div>

</asp:Content>
