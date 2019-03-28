<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PozdravnaPoruka.aspx.cs" Inherits="WebFormsPrimjer.PozdravnaPoruka" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ovo je pozdravna poruka <br />
            <asp:Label ID="Text" runat="server" Text="Label"></asp:Label /> 
            <asp:TextBox ID="txtIme" runat="server" ForeColor="#006699"></asp:TextBox /> 
            <asp:Button ID="btnObradi" runat="server" Text="Button" OnClick="btnObradi_Click" /> 
            <br />
            <asp:Label ID="lblRezultat" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
