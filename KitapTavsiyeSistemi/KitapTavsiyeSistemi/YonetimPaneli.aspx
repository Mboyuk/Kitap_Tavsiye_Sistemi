<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YonetimPaneli.aspx.cs" Inherits="YonetimPaneli" %>

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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="İsmi" HeaderText="İsmi" SortExpression="İsmi" />
                <asp:BoundField DataField="Yazar" HeaderText="Yazar" SortExpression="Yazar" />
                <asp:BoundField DataField="YayınEvi" HeaderText="YayınEvi" SortExpression="YayınEvi" />
                <asp:BoundField DataField="TanıtımBilgisi" HeaderText="TanıtımBilgisi" SortExpression="TanıtımBilgisi" />
                <asp:BoundField DataField="İnceleme" HeaderText="İnceleme" SortExpression="İnceleme" />
                <asp:BoundField DataField="Alıntı" HeaderText="Alıntı" SortExpression="Alıntı" />
                <asp:BoundField DataField="OrtalamaPuanı" HeaderText="OrtalamaPuanı" SortExpression="OrtalamaPuanı" />
                <asp:BoundField DataField="OkunmaSayısı" HeaderText="OkunmaSayısı" SortExpression="OkunmaSayısı" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KitapTavsiyeConnectionString %>" DeleteCommand="DELETE FROM [KitapTanım1] WHERE [ID] = @ID" InsertCommand="INSERT INTO [KitapTanım1] ([İsmi], [Yazar], [YayınEvi], [Resmi], [TanıtımBilgisi], [İnceleme], [Alıntı], [OrtalamaPuanı], [OkunmaSayısı]) VALUES (@İsmi, @Yazar, @YayınEvi, @Resmi, @TanıtımBilgisi, @İnceleme, @Alıntı, @OrtalamaPuanı, @OkunmaSayısı)" SelectCommand="SELECT * FROM [KitapTanım1]" UpdateCommand="UPDATE [KitapTanım1] SET [İsmi] = @İsmi, [Yazar] = @Yazar, [YayınEvi] = @YayınEvi, [Resmi] = @Resmi, [TanıtımBilgisi] = @TanıtımBilgisi, [İnceleme] = @İnceleme, [Alıntı] = @Alıntı, [OrtalamaPuanı] = @OrtalamaPuanı, [OkunmaSayısı] = @OkunmaSayısı WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="İsmi" Type="String" />
                <asp:Parameter Name="Yazar" Type="String" />
                <asp:Parameter Name="YayınEvi" Type="String" />
                <asp:Parameter Name="Resmi" Type="Object" />
                <asp:Parameter Name="TanıtımBilgisi" Type="String" />
                <asp:Parameter Name="İnceleme" Type="String" />
                <asp:Parameter Name="Alıntı" Type="String" />
                <asp:Parameter Name="OrtalamaPuanı" Type="Double" />
                <asp:Parameter Name="OkunmaSayısı" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="İsmi" Type="String" />
                <asp:Parameter Name="Yazar" Type="String" />
                <asp:Parameter Name="YayınEvi" Type="String" />
                <asp:Parameter Name="Resmi" Type="Object" />
                <asp:Parameter Name="TanıtımBilgisi" Type="String" />
                <asp:Parameter Name="İnceleme" Type="String" />
                <asp:Parameter Name="Alıntı" Type="String" />
                <asp:Parameter Name="OrtalamaPuanı" Type="Double" />
                <asp:Parameter Name="OkunmaSayısı" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Kitap İsmi"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Yazar Ad"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 2px"></asp:TextBox>
        <br />
        <br />
        &nbsp;<asp:Label ID="Label9" runat="server" Text="Yazar Soyad"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
&nbsp;<br />
&nbsp;<br />
        <asp:Label ID="Label8" runat="server" Text="Resim"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="YayınEvi"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Tanıtım Bilgisi"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ekle" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Yazar Dogum Tarihi"></asp:Label>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <asp:Label ID="Label10" runat="server" Text="Yazar dogum tarihi eklemek için gün seçiniz"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text=" "></asp:Label>
        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
