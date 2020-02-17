<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-9-Web-login.aspx.cs" MasterPageFile="~/My Master Page.Master" Inherits="zeeshan._2_9_Web_login" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc1" TagName="OpenAuthProviders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server" >

    <br />
    <br />
    <br />
    <br />
    <br />
   
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

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    </asp:Content>