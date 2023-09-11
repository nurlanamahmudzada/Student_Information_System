<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Student_Information_System_App.WebForms.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Css/Base.css" />
    <link rel="stylesheet" href="../Css/style2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
       <form>           
           <div class="class2div">          
               <div>
                   <div class="class2">
                    <label for="tb_name">Student Name</label>
                       <br />
                    <asp:TextBox ID="tb_name" runat="server" placeholder="Name"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="tb_name" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Name format is not right" ValidationExpression="^[A-Za-z]+$" ControlToValidate="tb_name"></asp:RegularExpressionValidator>
               </div>

               <div class="class2">
               <label for="tb_phone">Phone</label>
                   <br />
                    <asp:TextBox ID="tb_phone" runat="server" placeholder="Phone"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Phone format is not right" ValidationExpression="^(?:\+\d{1,3}\s?)?(?:\(\d{1,4}\)\s?)?(?:[-.\s]?\d{1,5}){1,5}$" ControlToValidate="tb_phone"></asp:RegularExpressionValidator>
           </div>
                   <div class="class2">
                         <label for="tb_entrance_point">Entrance Point</label>
                       <br />
                    <asp:TextBox ID="tb_entrance_point" runat="server" placeholder="Entrance Point"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Entrance point cannot be blank" ControlToValidate="tb_entrance_point" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Entrance Point format is not right" ValidationExpression="^\d+(\.\d+)?$" ControlToValidate="tb_entrance_point"></asp:RegularExpressionValidator>
                   </div>
               </div>
               <div>
                    <div class="class2">
              <label for="tb_surname">Student Surname</label> <br />
                    <asp:TextBox ID="tb_surname" runat="server" placeholder="Surname"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_2" runat="server" ErrorMessage="Surname cannot be blank" ForeColor="red" ControlToValidate="tb_surname"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Surname is not right" ValidationExpression="^[A-Za-z]+$" ControlToValidate="tb_surname" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>

               <div class="class2">
               <label for="tb_email">Email</label><br />
                    <asp:TextBox ID="tb_email"  runat="server" placeholder="Email"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email format is not right" ControlToValidate="tb_email" ValidationExpression="[a-zA-Z0-9]+@std\.beu\.edu\.az" ForeColor="Red"></asp:RegularExpressionValidator>
           </div>
                   <div class="class2">
               <label>Department Name</label><br />
                    <asp:DropDownList ID="ddl_departments" runat="server">
                    </asp:DropDownList>
           </div>
               </div>
               
                    <div class="class2 date-div">
                     <label>Entry Date</label> <br />
                    <asp:Calendar ID="calendar_entry_date" runat="server" OnSelectionChanged="c_entry_date_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="tb_entry_date" runat="server"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Entry date cannot be blank" ControlToValidate="tb_entry_date" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Entry date format is not right" ValidationExpression="\d{1,2}\/\d{1,2}\/\d{4}" ControlToValidate="tb_entry_date" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>
                   <div class="class2 date-div">
                   <label>Graduate Date</label> <br />
                    <asp:Calendar ID="calendar_graduate_date" runat="server" OnSelectionChanged="c_graduate_date_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="tb_graduate_date" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Graduate date format is not right" ValidationExpression="\d{1,2}\/\d{1,2}\/\d{4}" ControlToValidate="tb_graduate_date" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>
              
               </div>
       </form>
        </div>
        <div>
       <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btn_submit" CssClass="updatebutton"/>
       </div>
    <div>
       <asp:Label ID="lbl_message" runat="server" Text="" CssClass="messagelbl"></asp:Label>
   </div> 
</asp:Content>
