<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LabSch.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, tr, td{
            border-collapse:collapse;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table >
                <tr>
                    <td>Slots</td>
                    <asp:Repeater ID="rptHDays" runat="server">
                        <ItemTemplate>
                            <td>
                                <%# Eval("dayname") %>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <asp:Repeater ID="rptSlots" runat="server" OnItemDataBound="rptSlots_ItemDataBound">
                    <ItemTemplate>
                    <tr id="tblRow" runat="server">
                        <td>
                        <%# Eval("timing") %>
                        </td>
                    </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
