<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-8-7-Admin-Manage-users.aspx.cs" Inherits="Future._1_8_7_Admin_Manage_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bs-example {
            margin: 60px;
        }
    </style>

    <script type="text/javascript">

        function showError(textVal)
        {
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
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        <h3 class="text-info">Role Management</h3>
    </div>
    <div class="bs-example">
        <div class="panel-group" id="accordion">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Add Role</a>
                    </h4>
                </div>
                
                <div id="collapseOne" class="panel-collapse collapse in">
                   
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >
                            <ContentTemplate> <div class="panel-body">
                        
                                <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                                    <div class="form-group">
                                        <label>Role Name</label>

                                        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>



                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Role" ForeColor="Red" ValidationGroup="addrole" ControlToValidate="txtName"></asp:RequiredFieldValidator>

                                    </div>

                                </div>
                                <div class="col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-4 col-md-4 col-md-offset-5 col-lg-4 col-lg-offset-5">
                                    <asp:Button ID="btnAddRole" class="btn btn-md btn-primary" ValidationGroup="addrole" runat="server" Text="Add Role" OnClick="btnAddRole_Click" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddRole" EventName="Click" />
                            </Triggers>

                        </asp:UpdatePanel>
                    </div>

                </div>

            </div>

            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Delete Role</a>
                    </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class=" col-xs-12 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

                                    <div class="form-group">

                                        <label>Role Name</label>

                                        <asp:DropDownList ID="ddlDelete" runat="server" ValidationGroup="delete" CssClass="form-control">
                                        </asp:DropDownList>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-Select Role" runat="server" ErrorMessage="Choose Role" ForeColor="Red" ValidationGroup="delete" ControlToValidate="ddlDelete"></asp:RequiredFieldValidator>




                                    </div>

                                </div>
                                <div class="col-xs-11 col-xs-offset-1 col-sm-8 col-sm-offset-4 col-md-4 col-md-offset-5 col-lg-4 col-lg-offset-5">
                                    <asp:Button ID="btnDelete" class="btn btn-md btn-primary" ValidationGroup="delete" runat="server" Text="Delete Role" OnClick="btnDelete_Click" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />

                            </Triggers>
                        </asp:UpdatePanel>
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
