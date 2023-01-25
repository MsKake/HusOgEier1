<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTableSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 171px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            text-decoration: underline;
            text-align: center;
        }
        .auto-style4 {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Antall boliger i databasen:
            <asp:Label ID="LabelNumBoliger" runat="server" Text="LabelNumBoliger"></asp:Label>
            <br />
            <br />
            Søk med telefonnummer
            <asp:TextBox ID="TextBoxSearchByPhone" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchByPhone" runat="server" Text="Søk" OnClick="ButtonSearchByPhone_Click"  />
            <br />
            <br />
            Søk på epost
            <asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchMail" runat="server" Text="Søk" OnClick="ButtonSearchMail_Click" />
            <br />
            <br />
            Viser alle boliger
            <asp:Button ID="ButtonShowAllBoliger" runat="server" Text="Vis alle Boliger" OnClick="ButtonShowAllBoliger_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewBoligEiere" runat="server"></asp:GridView>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"><strong>Insert Into Database</strong></td>
            </tr>
            <tr>
                <td>eid&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">navn&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">epost
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>adr&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Insert" />
        <p>
            <asp:Label ID="Label1" runat="server" ForeColor="Lime" Text="Message"></asp:Label>
        </p>
    </form>
</body>
</html>
