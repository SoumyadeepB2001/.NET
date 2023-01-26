<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PhoneBook.Login.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
<title>Star International Hotel - Registration Page</title>
<link rel="stylesheet" href="/Login/bootstrap.min.css"/>
<link rel="stylesheet" href="/Login/font-awesome.min.css"/>
<script src="/Login/jquery-3.5.1.min.js"></script>
<script src="/Login/popper.min.js"></script>
<script src="/Login/bootstrap.min.js"></script>
<style>
    body{
        background-image: url("/Images/bg.jpg");
    }
.login-form {
    width: 370px;
    margin: 50px auto;
  	font-size: 15px;
}
.login-form form {
    margin-bottom: 15px;
    background: #f7f7f7;
    box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    padding: 30px;
}
.login-form h2 {
    margin: 0 0 15px;
}
.form-control, .btn {
    min-height: 38px;
    border-radius: 2px;
}
.btn {        
    font-size: 15px;
    font-weight: bold;
}
</style>
</head>
<body>
<div class="login-form">
    <form id="form2" runat="server">
        <h2 class="text-center">Create new account</h2>      
        <div class="form-group">
            <asp:TextBox ID="txtNameReg" runat="server" class="form-control" placeholder="Full Name" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPhoneReg" runat="server" class="form-control" placeholder="Phone Number" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtEmailReg" runat="server" class="form-control" placeholder="Email" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPasswordReg" runat="server" class="form-control" placeholder="Password" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnRegister" runat="server" Text="Register"  OnClick="btnRegister_Click" class="btn btn-primary btn-block"/>
        </div> 
     
        
        <p class="text-center">Already an user? <a href="/Login/login.aspx">Log-in</a></p>

    </form>
</div>
</body>
</html>
