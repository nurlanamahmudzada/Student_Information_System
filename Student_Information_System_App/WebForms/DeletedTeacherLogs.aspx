<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="DeletedTeacherLogs.aspx.cs" Inherits="Student_Information_System_App.WebForms.DeletedTeacherLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="../Css/style7.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar-table-container">
        <div class="deletion-div">
        <asp:Repeater ID="rpt_deleted_teachers" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead class="thead-dark col">
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Teacher ID</th>
                            <th scope="col">Teacher Name</th>
                            <th scope="col">Deleted By</th>
                            <th scope="col">Deleted Date</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="itemtemplates">
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("teacher_id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("teacher_name") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("deleted_by") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("deleted_date") %>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>
            </div>
    </div>
    
</asp:Content>
