<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-8-Web-Contact-us.aspx.cs" Inherits="Future._2_8_Web_Contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        @media screen and (max-width:360px) {


            .btnlg {
                margin-top: 34%;
            }

            #RecordNotFound {
                top: 25%;
            }
        }



        @media screen and (min-width:768px) {
            .btnlg {
                margin-top: 24%;
            }

            #RecordNotFound {
                top: 5%;
            }

                #RecordNotFound .modal-dialog {
                    width: 400px;
                }
        }


        @media screen and (min-width:980px) {
            .btnlg {
                margin-top: 17%;
            }
        }

        @media screen and (min-width:1280px) {
            .btnlg {
                width: 100px;
                height: 40px;
                margin-left: 15px;
                margin-top: 7%;
            }

            #RecordNotFound {
                top: 5%;
            }

                #RecordNotFound .modal-dialog {
                    width: 443px;
                }
        }



        @media screen and (min-width:1920px) {
            .btnlg {
                width: 150px;
                height: 40px;
                margin-left: 40px;
                margin-top: 5%;
            }
        }

        .TextBox {
            width: 100%;
        }

        .Editbtn {
            width: 50px;
        }
        
    </style>

    <style type="text/css">
        @media screen and (max-width:360px) {
            .leftmargn {
                margin-left: -10%;
            }

            .tp-mrgn {
                width: 170px !important;
                margin-left: 20px;
            }

            .btnSend {
                margin-left: 20px;
            }
        }

        .alt {
            margin-left: 20px;
        }

        @media screen and (max-width:800px) {
            .alt {
                margin-left: 2px !important;
            }
        }

        @media screen and (min-width:1280px) {
            .alt {
                margin-left: 40px !important;
            }
        }

        .tp-mrgn {
            margin-top: 30px;
            border: 2px solid;
            height: 35px;
            width: 220px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
        }

            .tp-mrgn:focus {
                box-shadow: 3px 3px 4px #617cfa;
                border: 2px solid #617cfa;
            }

        .imgstyle {
            height: 100px;
            width: 100px;
        }


        #map {
            height: 250px;
            width: 100%;
            padding: 0px;
        }

        .mapstyle {
            border: 5px solid #d9d4d4;
            border-radius: 7px;
        }

        .btnSend {
            height: 30px;
            width: 80px;
            border-radius: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%--Record Not Found--%>
    <div id="RecordNotFound" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background: #AC0200; border-top-left-radius: 4px; border-top-right-radius: 4px;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">INFORMATION</h4>
                </div>
                <div class="modal-body">
                    <h4>
                        <asp:Label ID="lblStudentIdNotFound" CssClass="text-danger" runat="server" Text="Please Select Class"></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>


    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
        <div>
            <h3><b>Contact Us:</b></h3>
        </div>
        <div class="col-lg-offset-1 col-md-offset-1 col-sm-offset-1">
            We’re happy to answer any questions you have or provide you with an estimate.<br />
            Just send us a message in the form below.
        </div>
    </div>
    <div style="width: 100%; padding: 0px;" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12 ">

            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 leftmargn">
                <br />
                <p class="alt" style="line-height: 50px;"><b>Name:</b></p>
                <br />

                <p class="alt" style="line-height: 20px;"><b>Email:</b></p>
                <br />
                <br />
                <p class="alt" style="line-height: 20px;"><b>Message:</b></p>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-8 " id="contact">

                <asp:TextBox ID="txtName" runat="server" CssClass="tp-mrgn"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Type Your Name" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtEmail" runat="server" CssClass="tp-mrgn"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter Your Email" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ForeColor="Red" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enetr a Valid Email" ValidationGroup="z" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>

                
                <textarea id="txtComments" runat="server" cols="20" rows="5" class="tp-mrgn" style="height: 150px !important;"></textarea><br />
                
                
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Type Your Msg" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtComments"></asp:RequiredFieldValidator>
                
                
                <br />
                <asp:Button ID="btnSend" runat="server" Text="Send" ValidationGroup="z" CssClass="btnSend btn-info" OnClick="btnSend_Click" />

            </div>


        </div>

        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12 mapstyle " style="padding: 0px;">
            <iframe id="map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6753.030576347334!2d74.15298879146575!3d32.19034310197517!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0000000000000000%3A0x5f782204afdc2622!2sUniversity+Of+The+Punjab+-+Gujranwala+Campus!5e0!3m2!1sen!2s!4v1417035894679" frameborder="0"></iframe>
        </div>
    </div>

    <div style="width: 100%;">
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 text-center" style="margin-top: 50px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="profile_pic/58.jpg" CssClass="img-circle imgstyle" />
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 text-center" style="margin-top: 50px;">
            <asp:Image ID="Image2" runat="server" ImageUrl="profile_pic/85.jpg" CssClass="img-circle imgstyle" />
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 text-center" style="margin-top: 50px;">
            <asp:Image ID="Image3" runat="server" ImageUrl="profile_pic/10.jpg" CssClass="img-circle imgstyle" />
        </div>
        
        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 text-center" style="margin-top: 50px;">
            <asp:Image ID="Image4" runat="server" ImageUrl="profile_pic/60.jpg" CssClass="img-circle imgstyle" />
            <br />
            <br />
        </div>

    </div>




</asp:Content>
