<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AddLessonToStudent.aspx.cs" Inherits="Student_Information_System_App.WebForms.AddLessonToStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/style4.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="navbar-table-container">

       <div class="repeater-div">
            <asp:Repeater ID="rpt_student_teacher_lesson" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead class="thead col">
                        <tr>
                            <th scope="col">№</th>
                            <th scope="col">Id</th>
                            <th scope="col">Student Id</th>
                             <th scope="col">Student Name</th>
                             <th scope="col">Teacher Name</th>
                             <th scope="col">Lesson Name</th>
                            <th scope="col">Delete</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                
                    <tr class="itemtemplates">
                        <td>
                            <asp:Label ID="lbl_r" runat="server" Text='<%# Eval("row_num") %>'></asp:Label>
                        </td>
                        <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </td>
                            <td>
                            <asp:Label ID="lbl_st_id" runat="server" Text='<%# Eval("Student Id") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_st_name" runat="server" Text='<%# Eval("Student Name") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbl_t_name" runat="server" Text='<%# Eval("Teacher Name") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl_l_name" runat="server" Text='<%# Eval("Lesson Name") %>'></asp:Label>
                            </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger btn-sm" Text="X" OnClick="btn_delete" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete this Contact Record?');"/>
                            </td>
                    </tr>
                
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>

        </asp:Repeater>
       </div>

         <div class="select-add-div">
             <label for="ddl_select_student" class="labels">Select Student</label> <br />
             <asp:DropDownList ID="ddl_select_student" runat="server" CssClass="dropdown"></asp:DropDownList>
             <asp:Button ID="btn_searchId" runat="server" Text="Select" OnClick="btn_search" CssClass="btn"/>
             <div class="add-teacher-div">
             <label for="ddl_teacher_lesson_name" class="labels">Teachers who do not teach the selected student</label> <br />
             <asp:DropDownList ID="ddl_teacher_lesson_name" runat="server" CssClass="dropdown"></asp:DropDownList>
             <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_event" CssClass="btn"/>
         </div>
         </div>        
    </div>

     <div class="nxprbtn2">
                <asp:Button ID="prevBtn" runat="server" Text="Previous" OnClick="PrevBtn_Click" Enabled="false"/>
                <asp:Button ID="nextBtn" runat="server" Text="Next" OnClick="NextBtn_Click"/>
            </div>
    <div>
        <asp:Label ID="lbl_message" runat="server" Text="" CssClass="messagelbl"></asp:Label>
    </div>



</asp:Content>
