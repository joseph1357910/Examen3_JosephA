<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3_JosephA.Encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>

        <h2>Encuesta</h2>
       
            <div>
                <label for="txtNombre">Nombre del Participante:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required OnTextChanged="txtNombre_TextChanged"></asp:TextBox>
            </div>
            <div>
                <label for="txtEdad">Edad:</label>
                <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" required type="number" min="18" max="50" OnTextChanged="txtEdad_TextChanged"></asp:TextBox>
            </div>
            <div>
                <label for="txtCorreo">Correo Electrónico:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" required type="email" OnTextChanged="txtCorreo_TextChanged"></asp:TextBox>
            </div>
            <div>
                <label for="ddlPartido">Partido Político:</label>
                <asp:DropDownList ID="ddlPartido" runat="server" CssClass="form-control" required OnSelectedIndexChanged="ddlPartido_SelectedIndexChanged">
                    <asp:ListItem Text="PLN" Value="PLN"></asp:ListItem>
                    <asp:ListItem Text="PUSC" Value="PUSC"></asp:ListItem>
                    <asp:ListItem Text="PAC" Value="PAC"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="GuardarEncuesta_Click" />
            </div>
     
    </div>
</asp:Content>
