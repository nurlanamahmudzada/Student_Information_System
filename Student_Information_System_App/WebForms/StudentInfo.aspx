<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="Student_Information_System_App.WebForms.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">
        function myFunction() {
            var input, filter, listitem, i;
            input = document.getElementById("ContentPlaceHolder1_tb_search");
            filter = input.value.toUpperCase();
            listitem = document.querySelectorAll(".studentName");
            for (i = 0; i < listitem.length; i++) {
                var txtValue = listitem[i].textContent || listitem[i].innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    listitem[i].parentElement.style.display="";
                } else {
                    listitem[i].parentElement.style.display = "none";
                }
            }
        }
     </script>

    <div class="input-group">
    <div class="form-outline" id="search-div">
        <asp:TextBox ID="tb_search" runat="server" onKeyUp="myFunction()" placeholder="Search Student Name" CssClass="tb-search"></asp:TextBox>
    </div>
</div>
    <div class="navbar-table-container">
         <asp:Repeater ID="rpt_students_info" runat="server">

            <HeaderTemplate>
                <table class="table">
                    <thead class="table-primary">
                        <tr>
                            <th scope="col">Student ID</th>
                            <th scope="col">Student Name</th>
                            <th scope="col">Deptartment Name</th>
                            <th scope="col">Lesson Count</th>
                            <th scope="col">GPA</th>                         
                        </tr>
                    </thead>
                    <tbody id="table-body">
            </HeaderTemplate>
            <ItemTemplate>
                
                    <tr class="itemtemplates table-light">
                         <td>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("Student Id") %>'></asp:Label>
                        </td>
                        <td class="studentName">
                            <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("Student Name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_deptName" runat="server" Text='<%# Eval("Department Name") %>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="lbl_lessonCount" runat="server" Text='<%# Eval("Lesson Count") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_gpa" runat="server" Text='<%# Eval("GPA") %>'></asp:Label>
                        </td>
                    </tr>
                
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
