<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KitapDetay.aspx.cs" Inherits="KitapDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField Text="Seç" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:Image ID="Image1" runat="server" Height="225px" Width="168px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kitap Kaydı" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="okuma" Text="Okudum" Visible="False" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="okuma" Text="Okumadım" Visible="False" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="İnceleme Yaz" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Alıntı Yap" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Sayfa No" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Visible="False" Width="52px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Puan" Visible="False"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Kaydet" Visible="False" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
