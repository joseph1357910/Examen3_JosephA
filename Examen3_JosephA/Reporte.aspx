<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Examen3_JosephA.Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvEncuestas_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ID_Encuesta" HeaderText="ID Encuesta" />
        <asp:BoundField DataField="Nombre_Participante" HeaderText="Nombre Participante" />
        <asp:BoundField DataField="Edad" HeaderText="Edad" />
        <asp:BoundField DataField="Correo_Electronico" HeaderText="Correo Electrónico" />
        <asp:BoundField DataField="Nombre_Partido" HeaderText="Partido Político" />
    </Columns>
</asp:GridView>
</asp:Content>
