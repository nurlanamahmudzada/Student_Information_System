<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Student_Information_System_App.WebForms.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../CSS/dashboard.css"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Dashboard</h3>
    </div>
    <div class="dashboard-div">
        <div class="card1">
            <div>
                <span class="count-span">Student Count</span> <br />
            <asp:Label ID="lbl_s_count" runat="server" Text="72" CssClass="labels"></asp:Label>
            </div>
            <img src="https://www.pngkey.com/png/full/126-1268354_community-student-icon-graduate-icon.png" class="image"/> 
        </div>
        <div class="card1">
            <div>
            <span class="count-span">Lesson Count</span> <br />
                <asp:Label ID="lbl_l_count" runat="server" Text="34" CssClass="labels"></asp:Label>
            </div>
            <img src="https://cdn-icons-png.flaticon.com/512/1575/1575305.png" class="image"/>

        </div>
        <div class="card1">
            <div>
            <span class="count-span">Teacher Count</span> <br />
                <asp:Label ID="lbl_t_count" runat="server" Text="55" CssClass="labels"></asp:Label>
            </div>
            <img src="https://cdn-icons-png.flaticon.com/512/1089/1089129.png" class="image"/>
        </div>
        <div class="card1">
            <div>
            <span class="count-span">Department Count</span> <br />
                <asp:Label ID="lbl_d_count" runat="server" Text="11" CssClass="labels"></asp:Label>
            </div>
            <img src="https://cdn-icons-png.flaticon.com/512/3652/3652193.png" class="image"/>
        </div>

    </div>

    <div class="about-admin-div">
        <div>
        <asp:Image ID="admin_image" runat="server" ImageUrl="" CssClass="admin-image"/>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="btn_logout" CssClass="logout-btn"/>
    </div>

        <div class="admin-form-div">
            <div class="margin-div">
                <h1>
                    <asp:Label ID="lbl_admin" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <div>
            
                <div class="margin-div">
                <label class="form-labels-name">Name: </label>
                <asp:Label ID="lbl_name" runat="server" Text="Name" CssClass="form-labels-value"></asp:Label>
            </div>
            <div class="margin-div">
                <label class="form-labels-name">Surname: </label>
                <asp:Label ID="lbl_surname" runat="server" Text="SurName" CssClass="form-labels-value"></asp:Label>
            </div>
            
            <div class="margin-div">
                <label class="form-labels-name">Email: </label>
                <asp:Label ID="lbl_email" runat="server" Text="Email" CssClass="form-labels-value"></asp:Label>
            </div>
            <div>
                <label class="form-labels-name">Phone: </label>
                <asp:Label ID="lbl_phone" runat="server" Text="Phone" CssClass="form-labels-value"></asp:Label>                
            </div>
        
        </div> 
        </div>    
    </div>
</asp:Content>





