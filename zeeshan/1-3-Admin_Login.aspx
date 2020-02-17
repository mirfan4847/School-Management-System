<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-3-Admin_Login.aspx.cs" Inherits="Future._3_Admin_Login" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc1" TagName="OpenAuthProviders" %>

<uc1:OpenAuthProviders runat="server" ID="OpenAuthProviders" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login Area</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Bootstrap Core CSS -->
    <link href="Content_Admin%20Panel/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->

    <link href="Content_Admin%20Panel/css/sb-admin.css" rel="stylesheet" />

    <!-- Morris Charts CSS -->
    <link href="Content_Admin%20Panel/css/plugins/morris.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="Content_Admin%20Panel/font-awesome/css/font-awesome.min.css" rel="stylesheet" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <script type="text/javascript">

        function showError1(textVal) {
            $("#RecordNotFound").modal();
            alert("dhasjhdasjhdga");
            $('#msg1').text("");
            $('#msg1').append('<h4><p class="text-danger text-lg">' + textVal + '</p></h4>');

        }

    </script>

</head>
<body style="background: #FFF">
    <form id="form1" runat="server">

        <div id="RecordNotFound" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background: #AC0200; border-top-left-radius: 4px; border-top-right-radius: 4px;">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">INFORMATION</h4>
                    </div>
                    <%-- <div class="modal-body">
                    <h4>
                     Invalid login attempt   
                    </h4>
                </div>--%>
                    <div id="msg1">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                    </div>
                </div>
            </div>
        </div>




        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">
                    <div class="login-panel panel panel-primary">
                        <div class="panel-heading ">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">

                            <fieldset>
                                <div class="form-group">



                                    <asp:TextBox ID="txtEmail" Placeholder="Email" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="*Enter Email" />

                                </div>
                                <div class="form-group">



                                    <asp:TextBox ID="Password" Placeholder="Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="*Enter Password" />


                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-10">
                                        <div class="checkbox">
                                            <asp:CheckBox runat="server" ID="RememberMe" />
                                            <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->



                                <asp:Button ID="btnLogin" class="btn btn-lg btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />


                            </fieldset>

                        </div>
                    </div>
                </div>
            </div>
            <p>
                <%--<asp:HyperLink CssClass="pull-right" runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>--%>
            </p>
        </div>

        <div class="clearfix"></div>
        <div class="col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-4 col-md-5 col-md-offset-7 col-lg-7 col-lg-offset-5">

            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <h4>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />

                    </p>
                </h4>
            </asp:PlaceHolder>


        </div>












    </form>
</body>
</html>
