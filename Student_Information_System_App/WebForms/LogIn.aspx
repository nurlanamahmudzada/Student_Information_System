<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Student_Information_System_App.WebForms.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/style.css" />
    <link rel="stylesheet" href="../Css/loginstyle.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://mir-s3-cdn-cf.behance.net/project_modules/disp/c9f9af17920798.5603d4397e33a.jpg" 
          class="img-fluid" alt="Sample image" />
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
            <div class="form-outline mb-5">
               <h1 class="text">LOGIN</h1>
           </div>
          <!-- Email input -->
          <div class="form-outline mb-4">
            <label class="form-label" for="form3Example3">Email address</label>
              <asp:TextBox ID="tb_email" runat="server" CssClass="form-control form-control-lg" placeholder="Enter a valid email address"></asp:TextBox>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
            <label class="form-label" for="form3Example4">Password</label>
              <asp:TextBox ID="tb_password" TextMode="Password" runat="server" CssClass="form-control form-control-lg" placeholder="Enter password" ></asp:TextBox>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btn_login" CssClass="btn btn-primary btn-lg"/>
          </div>

            <div class="label-message-div">
                <asp:Label ID="lbl_message" runat="server" Text="" CssClass="label-message"></asp:Label>
            </div>
        </form>
      </div>
    </div>
  </div>
  <div
    class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">
    <!-- Copyright -->
    <div class="text-white mb-3 mb-md-0">
      <p>&copy; <%: DateTime.Now.Year %> - Student Information System </p>
    </div>
    <!-- Copyright -->

    <!-- Right -->
    <div>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-facebook-f"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-twitter"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-google"></i>
      </a>
      <a href="#!" class="text-white">
        <i class="fab fa-linkedin-in"></i>
      </a>
    </div>
    <!-- Right -->
  </div>
</section>
        </div>
    </form>
</body>
</html>
