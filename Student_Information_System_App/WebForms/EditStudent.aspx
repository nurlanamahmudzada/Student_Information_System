<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Student_Information_System_App.WebForms.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="../Css/Base.css" />
      <link rel="stylesheet" href="../Css/style2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div >
       <div class="searchdiv">
           <asp:DropDownList ID="ddl_select_student" runat="server"></asp:DropDownList>
           <asp:Button ID="selectBtn" runat="server" Text="Search" Onclick ="btn_select" CssClass="searchbutton"/>
       </div>
       <form>
           <div>
           <div class="divclass">
           
               <div >
                   <div class="class1">
               <label>Name</label> <br />
                       <asp:TextBox ID="tb_name" runat="server" placeholder="Name"></asp:TextBox>

               </div>

               <div class="class1">
               <label>Phone</label> <br />
                   <asp:TextBox ID="tb_phone" runat="server" placeholder="Phone Number"></asp:TextBox>
           </div>
                   <div class="class1">
                        <label>Entrance Point</label> <br />
                       <asp:TextBox ID="tb_point" runat="server" placeholder="Entrance Point"></asp:TextBox>
                   </div>
               </div>
               <div>
                   <div class="class1">
               <label>Surname</label> <br />
                       <asp:TextBox ID="tb_surname" runat="server" placeholder="Surname"></asp:TextBox>
               </div>

               <div class="class1">
               <label>Email</label> <br />
                   <asp:TextBox ID="tb_email" runat="server" placeholder="Email" Enabled="false"></asp:TextBox>
           </div>
                   <div class="class1">
               <label>Department Id</label> <br />
                       <asp:TextBox ID="tb_dept_id" runat="server" placeholder="Department Id"></asp:TextBox>
           </div>
               </div>

               <div class="divclasses">
                   <div class="class1">
                   <label>Entry Date</label>
                   <asp:Calendar ID="c_entry_date" runat="server" OnSelectionChanged="c_entry_date_SelectionChanged"></asp:Calendar>
                       <asp:TextBox ID="tb_entry_date" runat="server"></asp:TextBox>
               </div>
               <div class="class1">
                   <label>Entry Date</label>
                   <asp:Calendar ID="c_graduate_date" runat="server" OnSelectionChanged="c_graduate_date_SelectionChanged"></asp:Calendar>
                   <asp:TextBox ID="tb_graduate_date" runat="server"></asp:TextBox>
               </div>
               </div>
               </div>
               </div>
       </form>
       <div>
       <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="updatebutton" OnClick="btn_update" />
       </div>

         <div>
           <asp:Label ID="lbl_message" runat="server" Text="" CssClass="messagelbl"></asp:Label>
         </div>

   </div>

</asp:Content>
