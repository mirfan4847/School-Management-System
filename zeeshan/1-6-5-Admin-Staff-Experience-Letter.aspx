<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-6-5-Admin-Staff-Experience-Letter.aspx.cs" Inherits="Future.StaffThankingLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $("#OpenModal").click(function () {
                $("#myModal").modal('show');
            });
        });



    </script>


    <style type="text/css">
        @media screen and (max-width:360px) {

            .btnlg {
                margin-top: 25%;
            }




            #myModal {
                top: 25%;
            }

            .text {
                color: black;
            }
        }



        @media screen and (min-width:768px) {




            #myModal {
                top: 5%;
            }

                #myModal .modal-dialog {
                    width: 400px;
                }

            .text {
                color: black;
            }
        }


        @media screen and (min-width:1280px) {
            .btnlg {
                width: 100px;
                height: 40px;
                margin-left: 15px;
            }


            #myModal {
                top: 5%;
            }

                #myModal .modal-dialog {
                    width: 443px;
                }

            .text {
                color: black;
                font-size: medium;
            }
        }



        @media screen and (min-width:1920px) {
            .btnlg {
                width: 150px;
                height: 40px;
                margin-left: 40px;
            }

            .text {
                color: black;
                font-size: medium;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title text-info">Search Teacher</h4>
                </div>
                <div class="modal-body">
                    <label>Teacher Name</label>
                    <asp:TextBox ID="txtSearchTeacher" runat="server" CssClass="form-control"></asp:TextBox>
                 
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" UseSubmitBehavior="false" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>

     <div id="UpdatedSuccessfuly" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style=" border-top-left-radius: 4px; border-top-right-radius: 4px;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">INFORMATION</h4>
                </div>
                <div class="modal-body">
                    <h4>
                        <asp:Label ID="UpdatedInfo" CssClass="text-info" runat="server" Text="Please Select Class"></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>

    <%--//Modal--%>



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Staff Experience Letter</h3>
    </div>

    <br />
    <br />
    <br />
    <br />
    <br />

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">

        <button type="button" id="OpenModal" class="btn btn-primary btnlg">Search</button>

    </div>

    <div class="clearfix"></div>

    <br />
    <br />

    <div class="col-xs-6 col-sm-4 col-sm-offset-1 col-md-4 col-md-offset-1 col-lg-2 col-lg-offset-3">
        <label>Ref#</label>

        <asp:TextBox ID="txtRef" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="col-xs-6 col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-2 col-lg-2 col-lg-offset-2">
        <label>Date of Issue</label>
        <asp:TextBox ID="txtdateIssue" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtdateIssue"></asp:RequiredFieldValidator>

        <script type="text/javascript">
            $(function () {
                $('#<%= txtdateIssue.ClientID %>').datetimepicker();
                });
        </script>
    </div>

    <div class="clearfix"></div>

    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>It is Certify that Mr./Miss/Mrs</label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>

      <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>S/O,D/O,W/O</label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>

     <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>Holding Education</label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>

    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>Holding NIC#</label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>

    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>Resident of</label>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>


    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-md-4 col-md-offset-0 col-lg-4 col-lg-offset-4">
        <label>Has Been Working as</label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="clearfix"></div>


    <div class="col-xs-6 col-sm-4 col-sm-offset-1 col-md-4 col-md-offset-1 col-lg-2 col-lg-offset-3">
        <label>From</label>

        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="col-xs-6 col-sm-4 col-sm-offset-2 col-md-4 col-md-offset-2 col-lg-2 col-lg-offset-2">
        <label>To</label>
        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtdateIssue"></asp:RequiredFieldValidator>

        <script type="text/javascript">
            $(function () {
                $('#<%= TextBox8.ClientID %>').datetimepicker();
            });
        </script>
    </div>

    <div class="clearfix"></div>

     <div class="col-xs-12 col-sm-11 col-sm-offset-1 col-md-6 col-md-offset-2 col-lg-6 col-lg-offset-3">
         <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" Rows="14" TextMode="MultiLine" Text="He/She attended the classes regularly and taught the students with devotion. His/Her method of teaching is quite up to date.
During his/her stay in this institution, his/her conduct and behavior towards the students and teachers remained good.


I pray for his/her success in every field in future life." ></asp:TextBox>
         </div>

    <div class="clearfix"></div>

         <br />
    <br />
     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="Print" runat="server" Text="Print" ValidationGroup="z" OnClick="Print_Click" CssClass="btn btn-primary btnlg" />
          <br />
    <br />
</div>
</asp:Content>
