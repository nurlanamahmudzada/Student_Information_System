<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AllTeachers.aspx.cs" Inherits="Student_Information_System_App.WebForms.AllTeachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function myFunction() {

            var input, filter, listitem, i;
            input = document.getElementById("ContentPlaceHolder1_tb_search");
            filter = input.value.toUpperCase();
            listitem = document.querySelectorAll(".teacherName");

            for (i = 0; i < listitem.length; i++) {
                var txtValue = listitem[i].textContent || listitem[i].innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    listitem[i].parentElement.style.display = "";
                } else {
                    listitem[i].parentElement.style.display = "none";
                }
            }
        }
    </script>

    <div class="input-group">
        <div class="form-outline" id="search-div">
            <asp:TextBox ID="tb_search" runat="server" onkeyup="myFunction()" placeholder="Search Student Name" CssClass="tb-search"></asp:TextBox>
        </div>
    </div>

    <div class="navbar-table-container">
        <asp:Repeater ID="rpt_all_teachers" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead class="table-primary">
                        <tr>
                            <th scope="col">№</th>
                            <th scope="col">ID</th>
                            <th scope="col">Name</th>
                            <th scope="col">Surname</th>
                            <th scope="col">Phone</th>
                            <th scope="col">Email</th>
                            <th scope="col">Employment Date</th>
                            <th scope="col">Quiting Date</th>
                            <th scope="col">Delete</th>
                        </tr>
                    </thead>
                    <tbody id="table-body">
            </HeaderTemplate>
            <ItemTemplate>
                
                    <tr class="itemtemplates table-light">
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("row_num") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </td>
                        <td class="teacherName">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Teacher Name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Teacher Surname") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Teacher PhoneNumber") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Teacher Email") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Employment Date") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Quiting Date") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="X" CssClass="btn btn-danger btn-sm" OnClick="btn_delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure you want to delete this teacher?');"/>
                        </td>
                    </tr>
                
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
    <div class="nxprbtn">
                <asp:Button ID="prevBtn" runat="server" Text="Previous" OnClick="PrevBtn_Click" Enabled="false" CssClass="pagination-btn"/>
                <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="NextBtn_Click" CssClass="pagination-btn"/>
            </div>
</asp:Content>
