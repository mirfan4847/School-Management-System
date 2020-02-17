<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-8-8-Admin-Register-users.aspx.cs" Inherits="zeeshan._1_8_8_Admin_Register_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bs-example {
            margin: 60px;
        }
    </style>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#OpenModal").click(function () {
                $("#myModal").modal('show');
            });
        });



    </script>



    <style type="text/css">
        @media screen and (max-width:360px) {






            #myModal {
                top: 25%;
            }

            #RecordNotFound {
                top: 25%;
            }
        }



        @media screen and (min-width:768px) {




            #myModal {
                top: 5%;
            }

                #myModal .modal-dialog {
                    width: 400px;
                }


            #RecordNotFound {
                top: 5%;
            }


                #RecordNotFound .modal-dialog {
                    width: 400px;
                }
        }


        @media screen and (min-width:1280px) {



            #myModal {
                top: 5%;
            }

                #myModal .modal-dialog {
                    width: 443px;
                }


            #RecordNotFound {
                top: 5%;
            }

                #RecordNotFound .modal-dialog {
                    width: 443px;
                }
        }



        @media screen and (min-width:1920px) {
        }
        
        
        
        .modal.fade:not(.in).bottom .modal-dialog {
            -webkit-transform: translate3d(0, 25, 0);
            transform: translate3d(0, 25, 0);
        }
    </style>
    <script type="text/javascript">

        function showError(textVal) {
            $("#myModal").modal();

            $('#msg').text("");
            $('#msg').append('<h4><p class="text-info text-lg">' + textVal + '</p></h4>');

        }



        function showError1(textVal) {
            $("#RecordNotFound").modal();

            $('#msg1').text("");
            $('#msg1').append('<h4><p class="text-danger text-lg">' + textVal + '</p></h4>');

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <%--Modal--%>

    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background: #446E9B; border-top-left-radius: 4px; border-top-right-radius: 4px;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" style="color: #fff">INFORMATION</h4>
                </div>
                <div id="msg">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>

                </div>
            </div>
        </div>
    </div>


    <%--//Modal--%>
    <%--Record Not Found--%>
    <div id="RecordNotFound" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background: #AC0200; border-top-left-radius: 4px; border-top-right-radius: 4px;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">INFORMATION</h4>
                </div>
                <div id="msg1">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
    <%--End Record Not Found--%>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Add System Users</h3>
    </div>
    <div class="bs-example">
        <div class="panel-group" id="accordion">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Add Users</a>
                    </h4>
                </div>

                <div id="collapseOne" class="panel-collapse collapse in">

                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">

                        <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                            <div class="form-group">
                                <label>Email</label>

                                <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>



                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Email" ForeColor="Red" ValidationGroup="adduser" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email" ForeColor="Red" ValidationGroup="adduser" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <div class="clearfix"></div>

                        <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                            <div class="form-group">
                                <label>Password</label>
                                <%--$&+,:;=?@#|'<>.^*()%!-
                                --%>

                                <%--^[a-zA-Z0-9_@./#&+-]{6}$--%>
                                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="adduser" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Password atleast consists of 6 characters" ForeColor="Red" ValidationGroup="adduser" ControlToValidate="txtPassword" ValidationExpression="^[a-zA-Z0-9$&+,:;=?@#|'<>.^*()%!-]{6}$">

                                </asp:RegularExpressionValidator>

                            </div>

                        </div>
                        <div class="clearfix"></div>


                        <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                            <div class="form-group">
                                <label>Confirm Password</label>

                                <asp:TextBox ID="txtConfirm" class="form-control" runat="server" TextMode="Password"></asp:TextBox>



                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="adduser" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Password Mismatch." />

                            </div>

                        </div>
                        <div class="clearfix"></div>

                        <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                            <div class="form-group">
                                <label>Assign Role</label>

                                <asp:DropDownList ID="ddlRoles" CssClass="form-control" runat="server"></asp:DropDownList>


                            </div>

                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-4 col-md-4 col-md-offset-5 col-lg-4 col-lg-offset-5">
                            <asp:Button ID="btnRegister" class="btn btn-md btn-primary" ValidationGroup="adduser" runat="server" Text="Register" OnClick="btnRegister_Click" />

                        </div>
                        <%-- </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnRegister" EventName="Click" />
                        </Triggers>

                    </asp:UpdatePanel>--%>
                    </div>

                </div>

            </div>

            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Delete Users</a>
                    </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">
                    <div class="panel-body">
                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                        <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                            <div class="form-group">

                                <label>Users</label>

                                <asp:DropDownList ID="ddlDelete" runat="server" ValidationGroup="delete" CssClass="form-control">
                                </asp:DropDownList>


                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-Select Role" runat="server" ErrorMessage="Choose Role" ForeColor="Red" ValidationGroup="delete" ControlToValidate="ddlDelete"></asp:RequiredFieldValidator>




                            </div>

                        </div>
                        <div class="col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-4 col-md-4 col-md-offset-5 col-lg-4 col-lg-offset-5">
                            <asp:Button ID="btnDelete" class="btn btn-md btn-primary" ValidationGroup="delete" runat="server" Text="Delete Role" OnClick="btnDelete_Click" />

                        </div>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />

                        </Triggers>
                    </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>

        </div>
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
