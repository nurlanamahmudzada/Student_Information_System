<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="Student_Information_System_App.WebForms.AddTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../Css/Base.css" />
    <link rel="stylesheet" href="../Css/style2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div >
       <form>           
           <div class="class2div">          
               
                  <div>
                       <div class="class2">
                    <label for="tb_name">Teacher Name</label> <br />
                    <asp:TextBox ID="tb_name" runat="server" placeholder="Name"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ForeColor="red" ControlToValidate="tb_name"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name format is not right" ValidationExpression="^[A-Za-z]+$" ControlToValidate="tb_name" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>

               <div class="class2">
             
                    <label for="tb_phone">Phone</label> <br />
                    <asp:TextBox ID="tb_phone" runat="server" placeholder="Phone Number"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Phone format is not right" ValidationExpression="^(?:\+\d{1,3}\s?)?(?:\(\d{1,4}\)\s?)?(?:[-.\s]?\d{1,5}){1,5}$" ControlToValidate="tb_phone" ForeColor="Red"></asp:RegularExpressionValidator>
           </div>
                   <div class="class2">
                          <label for="tb_lesson_name">Lesson Name</label> <br />
                    <asp:TextBox ID="tb_lesson_name" runat="server" placeholder="Lesson Name"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Lesson Name cannot be blank" ControlToValidate="tb_lesson_name" ForeColor="Red"></asp:RequiredFieldValidator>
                   </div>
                  </div>
              
               <div>
                    <div class="class2">
              <label for="tb_surname">Teacher Surname</label> <br />
                    <asp:TextBox ID="tb_surname" runat="server" placeholder="Surname"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Surname cannot be blank" ForeColor="red" ControlToValidate="tb_surname"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Surname is not right" ValidationExpression="^[A-Za-z]+$" ControlToValidate="tb_surname" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>

               <div class="class2">
              <label for="tb_email">Email</label> <br />
                    <asp:TextBox ID="tb_email" runat="server" placeholder="Email"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email cannot be blank" ControlToValidate="tb_email" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Email format is not right" ValidationExpression="[a-zA-Z0-9]+@beu\.edu\.az" ControlToValidate="tb_email" ForeColor="Red"></asp:RegularExpressionValidator>
           </div>
               </div>
                   
               <div class="class2 date-div">  
                   <label>Begin Date</label> <br />
                    <asp:Calendar ID="calendar_employment_date" runat="server" OnSelectionChanged="c_emp_date_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="tb_employment_date" runat="server"></asp:TextBox> <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Employment Date cannot be blank" ControlToValidate="tb_employment_date" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Employment Date format is not right" ValidationExpression="\d{1,2}\/\d{1,2}\/\d{4}" ControlToValidate="tb_employment_date" ForeColor="Red"></asp:RegularExpressionValidator>
               </div>
                   <div class="class2 date-div"> 
                       <label>End Date</label> <br />
                  <asp:Calendar ID="calendar_quiting_date" runat="server" OnSelectionChanged="c_quit_date_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="tb_quiting_date" runat="server"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Quiting date format is not right" ValidationExpression="\d{1,2}\/\d{1,2}\/\d{4}" ControlToValidate="tb_quiting_date" ForeColor="Red"></asp:RegularExpressionValidator>                   
               </div>

               </div>
            
       </form>
       <div>
           <asp:Button ID="button_add" runat="server" Text="Add" OnClick="btn_add" CssClass="updatebutton"/>
       </div>
        <asp:Label ID="lbl_error_message" runat="server" Text="" CssClass="messagelbl"></asp:Label>
   </div> 









    <%--<form>
        <div class="add-student-div">
            <div class="form-row">
                <div class="col-md-6 input-style">
                   
                </div>
                <div class="col-md-6 input-style">
                    
                </div>
            </div>
            <div class="form-row">
                
                </div>
                <div class="col-md-6 input-style">
                    
                </div>
            </div>
           <div class="form-row">
                <div class="col-md-6 input-style">
                    
                </div>
                <div class="col-md-6 input-style">
                    
                </div>
            </div>
             <div class="form-row">
                <div class="col-md-6 input-style">
                   
                </div>
            </div>
        </div>
        <br />
        
    </form>--%>
</asp:Content>
