<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="DeletedStudentLogs.aspx.cs" Inherits="Student_Information_System_App.WebForms.DeletionLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <link rel="stylesheet" href="../Css/style3.css" />
    <script type="text/javascript" src="../JS/pagination.js"></script>--%>
         <link rel="stylesheet" href="../Css/style7.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="navbar-table-container">
        <div class="deletion-div">
        <asp:Repeater ID="rpt_deleted_students" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead class="thead-dark col">
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Student ID</th>
                            <th scope="col">Student Name</th>
                            <th scope="col">Deleted By</th>
                            <th scope="col">Deleted Date</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="itemtemplates" id="paginated-list">
                    <td id="tdId">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </td>
                    <td  class="mytd">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("student_id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("student_name") %>'></asp:Label>
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


    <%--<nav class="pagination-container">
        <button class="pagination-button" id="prev-button" title="Previous page" aria-label="Previous page">
        </button>

        <div id="pagination-numbers">
        </div>

        <button class="pagination-button" id="next-button" title="Next page" aria-label="Next page">
        </button>
    </nav>--%>
    
</asp:Content>
