<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineGym.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="../Assets/lib/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        * {
            font-family: Arial;
        }

        body {
            background: url("../Assets/Images/gymBack.jpg");
            background-size: cover;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <div class="row mb-5 mt-2 pt-4 text-align-center" style="height: 100px; text-align: center">
            
        </div>
        <div class="row mt-5">
            <div class="col-md-3"></div>
            <div class="col-md-6 bg-white pt-4 pb-4 rounded-3">
                <div class="row">
                    <h4 class="text-center text-primary mb-2">Online Gym Management System</h4>
                    <div class="col">
                        <img src="../Assets/Images/gymlogin.jpg" style="object-fit: cover; height: 250px; width: 300px; border-radius: 5px" />
                    </div>
                    <div class="col bg-white">
                        <form runat="server">
                            <div class="mb-2">
                                <label for="loginEmail" class="form-label">Email address</label>
                                <input type="email" class="form-control" id="loginEmail" aria-describedby="emailHelp" runat="server"/>
                            </div>
                            <div class="mb-2">
                                <label for="loginPass" class="form-label">Password</label>
                                <input type="password" class="form-control" id="loginPass" runat="server"/>
                            </div>
                            <div class="mb-2 form-check">
                                <asp:RadioButton ID="AdminRadio" runat="server" GroupName="Role" CssClass="form-radio-input px-2" Text="Admin" />
                                <asp:RadioButton ID="RecRadio" runat="server" GroupName="Role" CssClass="form-radio-input" Text="Receptionist" Checked="True" />
                            </div>
                                <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger mb-2"></asp:Label>
                            <div class="d-grid">
                                <asp:Button ID="LoginBtn" CssClass="btn btn-primary btn-block" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </div>
</body>
</html>
