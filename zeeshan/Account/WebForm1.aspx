<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="zeeshan.Account.WebForm1" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc1" TagName="OpenAuthProviders" %>

<uc1:OpenAuthProviders runat="server" ID="OpenAuthProviders" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Admin Login Area</title>

     <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

      <!-- Bootstrap Core CSS -->
    
    <link href="../Content_Admin%20Panel/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->

    <link href="../Content_Admin%20Panel/css/Admin-Custom.css" rel="stylesheet" />
    <!-- Morris Charts CSS -->
    <!-- Custom Fonts -->
    <link href="../Content_Admin%20Panel/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-sm-offset-0">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Login Area</h3>
                </div>
                <div class="panel-body">

                    <section id="loginForm">
                        <div class="form-horizontal">
                            <h4>Use a local account to log in.</h4>
                            <hr />
                            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="FailureText" />
                                </p>
                            </asp:PlaceHolder>
                            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                    CssClass="text-danger" ErrorMessage="The Email is required." />
                            </div>
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <div class="checkbox">
                                        <asp:CheckBox runat="server" ID="RememberMe" />
                                        <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Log in" CssClass="btn btn-info" />
                                </div>
                            </div>
                        </div>
                <p>
                    <asp:HyperLink CssClass="pull-right" runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
                </section>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
