<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AddLessonPoint.aspx.cs" Inherits="Student_Information_System_App.WebForms.AddLessonPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../Css/style6.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar-table-container">

        <div class="select-add-div">
        <label class="labels">Select Student</label> <br />
        <asp:DropDownList ID="ddl_select_student" runat="server" CssClass="dropdown"></asp:DropDownList>
        <asp:Button ID="btnSearchId" runat="server" Text="Select" OnClick="btn_search" CssClass="btn"/>
    
            <div class="add-teacher-div">
        <label class="labels">What lessons does the selected student have?</label>
        <asp:DropDownList ID="ddl_lesson_names" runat="server" CssClass="dropdown"></asp:DropDownList> <br />
        <label class="labels">Enter the score for the selected lesson</label> <br />
        <asp:TextBox ID="tb_point" runat="server" placeholder="Score"></asp:TextBox>
        <asp:Button ID="btn_add_pointId" runat="server" Text="Add" OnClick="btn_add_point" CssClass="btn"/> <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Score format is not right" ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red" ControlToValidate="tb_point"></asp:RegularExpressionValidator>
            </div>

    </div>

        <div class="repeater-div">
            <asp:Repeater ID="rpt_lesson_points" runat="server">

            <HeaderTemplate>
                <table class="table">
                    <thead class="thead col">
                        <tr>
                            <th scope="col">Student Id</th>
                            <th scope="col">Lesson Name</th>
                            <th scope="col">Point</th>                         
                        </tr>
                    </thead>
                    <tbody id="table-body">
            </HeaderTemplate>
            <ItemTemplate>
                
                    <tr class="itemtemplates table-light">
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Student Id") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Lesson Name") %>'></asp:Label>
                        </td>
                        <td class="teacherName">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Point") %>'></asp:Label>
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
    <div>
        <asp:Label ID="lbl_message" runat="server" Text="" CssClass="messagelbl"></asp:Label>
    </div>
</asp:Content>
