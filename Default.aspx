<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<script runat="server">
    'Sub changeFolders(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim str As String = ListBox1.SelectedItem.ToString()
    '    TextBox2.Text = str
    'End Sub
 </script>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Load Data" />
    &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="20pt" 
            Font-Underline="True" Text="Drive Details"></asp:Label>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" Height="154px" Width="907px">
            <asp:TableRow runat="server" BackColor="Red" Font-Bold="True">
                <asp:TableCell runat="server">Drive</asp:TableCell>
                <asp:TableCell runat="server">Total Space</asp:TableCell>
                <asp:TableCell runat="server">Available Space</asp:TableCell>
                <asp:TableCell runat="server">Free Space</asp:TableCell>
                <asp:TableCell runat="server">Volume Name</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="20pt" 
            Font-Underline="True" Text="Open File"></asp:Label>
        <br />
        <br />
    
    </div>
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="254px" 
        Width="38px">
    </asp:ListBox>
&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" Height="251px" Width="122px">
    </asp:ListBox>
&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBox3" runat="server" AutoPostBack="True" Height="251px" Width="122px">
    </asp:ListBox>
&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="ListBox4" runat="server" AutoPostBack="True" Height="251px" 
        Width="165px">
    </asp:ListBox>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="250px" TextMode="MultiLine" 
        Width="379px"></asp:TextBox>
    <p>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="20pt" 
            Font-Underline="True" Text="Tree View"></asp:Label>
        </p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="110px" TextMode="MultiLine" 
            Width="856px"></asp:TextBox>
        <asp:TreeView ID="TreeView1" runat="server" Height="214px" Width="201px">
        </asp:TreeView>
    &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
