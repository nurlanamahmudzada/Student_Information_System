<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AllStudents.aspx.cs" Inherits="Student_Information_System_App.WebForms.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/style8.css" />
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

    <%--<script type="text/javascript">
        function deleteRow(button) {
            if (window.confirm("Are you sure to delete?")) {
                var row = button.parentNode.parentNode;
                row.parentNode.removeChild(row);
            }
            var id = button.getAttribute("data-id"); 
            __doPostBack("btn_deleteId_Click", id);
                return false;
        }    
    </script>--%>

<div class="input-group">
    <div class="form-outline" id="search-div">
        <asp:TextBox ID="tb_search" runat="server" onKeyUp="myFunction()" placeholder="Search Student Name" CssClass="tb-search"></asp:TextBox>
    </div>
</div>
    <div class="navbar-table-container">

        <asp:Repeater ID="rpt_students" runat="server">

            <HeaderTemplate>
                <table class="table">
                    <thead class="table-primary">
                        <tr>
                            <th scope="col">№</th>
                            <th scope="col">Student ID</th>
                            <th scope="col">Name</th>
                            <th scope="col">Surname</th>
                            <th scope="col">Phone</th>
                            <th scope="col">Email</th>
                            <th scope="col">Point</th>
                            <th scope="col">Dept ID</th>
                            <th scope="col">Entry Date</th>
                            <th scope="col">Graduate Date</th>
                            <th scope="col">Delete</th>                         
                        </tr>
                    </thead>
                    <tbody id="table-body">
            </HeaderTemplate>
            <ItemTemplate>
                
                    <tr class="itemtemplates table-light">
                         <td>
                            <asp:Label ID="lbl_r" runat="server" Text='<%# Eval("row_num") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </td>
                        <td class="studentName">
                            <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="lbl_surname" runat="server" Text='<%# Eval("Surname") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_phoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_point" runat="server" Text='<%# Eval("Entrance Point") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_deptName" runat="server" Text='<%# Eval("Department Name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_entryDate" runat="server" Text='<%# Eval("Entry Date") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_graduateDate" runat="server" Text='<%# Eval("Graduate Date") %>'></asp:Label>
                        </td>
                       <td>
                           <asp:Button ID="btn_deleteId" CssClass="btn btn-danger btn-sm" runat="server" Text="X" OnClick="btn_delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure you want to delete this student?');"/>
                           <%-- <asp:Button ID="btn_deleteId_Click" CssClass="btn btn-danger btn-sm" runat="server" Text="X" data-id='<%# Eval("ID") %>' OnClientClick="deleteRow(this); return false;" />--%>
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
                <asp:Button ID="prevBtn" runat="server" Text="Previous" OnClick="PrevBtn_Click" Enabled="false"/>
                <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="NextBtn_Click"/>
            </div> 
    <div>
        <asp:Button ID="ExportButton" runat="server" Text="📁 Export" OnClick="Btn_export" CssClass="btn-export"/>
    </div>
</asp:Content>
