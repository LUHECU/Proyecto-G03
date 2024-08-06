<%@ Page Title="Gestionar Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservaciones.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.GestionarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Gestionar Reservaciones</h2>
        </div>

        <div class="row">

            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblPersona" runat="server" Text="Cliente"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha entrada"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col col-sm-6 col-md-4 col-lg-2">
                <div class="mb-2">
                    <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha salida"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

           <div class="mt-2 col col-sm-6 col-md-4 col-lg-2">
                <div class="mt-4">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click"/>
                </div>
            </div>

            <asp:CustomValidator ID="cvFechaSalida" runat="server" ErrorMessage="La fecha de salida debe ser mayor o igual a la de entrada" ControlToValidate="txtFechaSalida" OnServerValidate="cvFechaSalida_ServerValidate" CssClass="text-danger"></asp:CustomValidator>

        </div>


   
        <div class="m mt-4">
            <a href="CrearReservacion.aspx" class="btn btn-primary">Nueva Resevación</a>
        </div>

        <div class="mt-3">
            <asp:GridView ID="grdGestReserv" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" CellPadding="10" >
                <Columns>
                    <asp:BoundField DataField="idReservacion" HeaderText="# reservación" ItemStyle-CssClass="text-center w-auto" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" ItemStyle-CssClass="w-auto" />
                    <asp:BoundField DataField="nombreHotel" HeaderText="Hotel" ItemStyle-CssClass="w-auto"/>
                    <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha entrada" ItemStyle-CssClass="text-center w-auto" HeaderStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="fechaSalida" HeaderText="Fecha salida" ItemStyle-CssClass="text-center w-auto" HeaderStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:TemplateField ItemStyle-CssClass="text-end w-auto" HeaderStyle-CssClass="text-end" HeaderText="Costo">
                        <ItemTemplate>
                            $<%# Decimal.Parse(Eval("costoTotal").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="text-center w-auto" HeaderStyle-CssClass="text-center" HeaderText="Estado">
                        <ItemTemplate>
                            <%# estadoReservacion(DateTime.Parse(Eval("FechaEntrada").ToString()), DateTime.Parse(Eval("fechaSalida").ToString()), Eval("estado").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="w-auto m-auto h-auto text-center" >
                        <ItemTemplate>
                            <a href="Detalle.aspx?id=<%#Eval("idReservacion")%>" class="btn btn-light btn-outline-secondary ">Consultar</a>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>

    </div>

</asp:Content>
