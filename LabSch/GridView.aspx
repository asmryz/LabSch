<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="LabSch.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            padding:20px;
        }
        .col{
            width:200px;
        }
        table, th, tr, td{
            border:1px solid black;
        }
        .item{
            font-size:12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- timing	Monday	Tuesday	Wednesday	Thursday	Friday	Saturday	Sunday -->
            <asp:GridView ID="gvLabs" runat="server" OnRowDataBound="gvLabs_RowDataBound" RowStyle-Height="70px" HeaderStyle-CssClass="col" Width="100%" HorizontalAlign="Center" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="timing" HeaderText="Slots" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px"  />
                    <asp:BoundField DataField="Monday" HeaderText="Monday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Tuesday" HeaderText="Tuesday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px"  ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Wednesday" HeaderText="Wednesday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Thursday" HeaderText="Thursday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Friday" HeaderText="Friday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px"  ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Saturday" HeaderText="Saturday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-CssClass="item" />
                    <asp:BoundField DataField="Sunday" HeaderText="Sunday" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px"  ItemStyle-CssClass="item" />
                </Columns>
            </asp:GridView>
<%--            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LabDb %>" SelectCommand="SELECT labschedule.schid, course.*, labschedule.dayid, labschedule.slotid FROM course RIGHT OUTER JOIN labschedule ON course.courseid = labschedule.courseid"></asp:SqlDataSource>--%>
        </div>
    </form>
</body>
</html>
