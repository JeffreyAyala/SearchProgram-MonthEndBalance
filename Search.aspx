<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MonthEndBalanceSearch.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Month-End Balance Search</title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            font-weight: bold;
        }
        body {
            font-family: Arial, sans-serif;
            margin: 40px;
        }
        p {
            line-height: 1.6;
        }
        input[type="text"] {
            width: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">Search Month End Balance </p>

        <p>
            Last Name
            <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdSearch" runat="server" OnClick="Submit_Click" Text="Search" />
        </p>

        <p>Previous Balance
            <asp:TextBox ID="txtpreviousbalance" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>Payments
            <asp:TextBox ID="txtpayments" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>Charges
            <asp:TextBox ID="txtcharges" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>New Balance
            <asp:TextBox ID="txtnewbalance" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>Finance Charge
            <asp:TextBox ID="txtfinancecharge" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>Month End Balance
            <asp:TextBox ID="txtmonthendbalance" runat="server" ReadOnly="true"></asp:TextBox>
        </p>

        <p>Picture</p>

        <p>
            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" />
        </p>

        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:MonthEndBalanceSQLConnectionString2 %>"
                SelectCommand="SELECT [LastName], [PreviousBalance], [Payments], [Charges], [NewBalance], [FinanceCharge], [MonthendBalance], [Picture] FROM [MonthendTable]">
            </asp:SqlDataSource>
        </p>
    </form>
</body>
</html>
