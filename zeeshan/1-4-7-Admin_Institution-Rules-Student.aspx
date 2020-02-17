<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-4-7-Admin_Institution-Rules-Student.aspx.cs" Inherits="Future.InsitutionRules" %>

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

            #RecordNotFound {
                top: 25%;
            }
        }



        @media screen and (min-width:768px) {

            .marginImage {
                margin-left: -35%;
            }


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
            .marginImage {
                margin-left: 35%;
            }


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
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Modal--%>

    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title text-info">Search Student</h4>
                </div>
                <div class="modal-body">
                    <label>Enter Admission ID</label>
                    <asp:TextBox ID="txtSearchAdmission" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" UseSubmitBehavior="false" data-dismiss="modal" />
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
                <div class="modal-body">
                    <h4>
                        <asp:Label ID="lblStudentIdNotFound" CssClass="text-danger" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">School Rules</h3>
    </div>


    <br />
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

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admission ID</label>

            <asp:TextBox ID="txtAdminId" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAdminId"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ForeColor="Red" runat="server" ControlToValidate="txtAdminId" ErrorMessage="Unavailable/InCorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>

    <%--Name--%>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Name</label>

            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>



    <%--Father--%>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">


        <div class="form-group">
            <label>Father Name</label>

            <asp:TextBox ID="txtFather" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFather"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" runat="server" ControlToValidate="txtFather" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class="clearfix"></div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Class</label>

            <asp:DropDownList ID="ddlClass" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose Your Class</asp:ListItem>



            </asp:DropDownList>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="Choose Your Class" runat="server" ErrorMessage="Choose Your Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Mobile No</label>

            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ForeColor="Red" runat="server" ControlToValidate="txtMobile" ErrorMessage="Wrong/Incorrect Format" ValidationGroup="z" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>

        </div>
    </div>



    <div class="clearfix"></div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>INSTITUTION TERMS:</label>

        <asp:TextBox ID="txtTerms" runat="server" CssClass="form-control" ValidationGroup="z" Rows="4" TextMode="MultiLine" Text="Term1 (April to May )
Term 2 ( September- November )
Term 3 ( December-  March )"></asp:TextBox>
    </div>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>DEPOSIT</label>

        <asp:TextBox ID="txtDeposit" runat="server" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine" Text="The deposit fee once paid is not refundable."></asp:TextBox>
    </div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>SCHOOL FEES</label>

        <asp:TextBox ID="txtFeesRule" runat="server" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine" Text="If the Institution dues are not paid by the date specified, then all related discounts applicable to the student
 would be cancelled. "></asp:TextBox>
    </div>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>CANCELLATION / WITHDRAWAL </label>

        <asp:TextBox ID="txtCancelWithDrawal" runat="server" Rows="5" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine" Text="* Application for withdrawals or cancellation during the Institution year should be made in the prescribed form at least
  15 days before the date leaving. 
* If a student withdraws or cancels during a term, full term fees for the term are to be paid. 
* Transfer certificate will be issued only after all dues have been paid and any Institution property taken on loan has"></asp:TextBox>
    </div>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>TRANSPORTS / BUS RULES:</label>

        <asp:TextBox ID="txtBus" runat="server" CssClass="form-control" ValidationGroup="z" Rows="6" TextMode="MultiLine" Text="*All students using bus facilities must be have in a disciplined manner in the bus, and any misuse by the student will result in cancellation of his/her facility without notice.                                                                                                                                                                                                                                                             
* The Institution will recover the cost of repairs of any damage caused to the bus by any student.
*One month's notice should be given or one month's fee will be charged in lieu of notice for discontinuing the transport facilities.
*The Institution management at its discretion can modify these rules."></asp:TextBox>
    </div>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>Read Carefully</label>

        <asp:TextBox ID="txtReadCarefully" runat="server" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine" Text="I, the parent/guardian signed below agree to pay the school fees as required by the school and I will abide by all the above rules and regulations of the Institution."></asp:TextBox>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <div class="form-group">
            <label>Date of Issue</label>
            <asp:TextBox ID="txtdateIssue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtdateIssue"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtdateIssue.ClientID %>').datetimepicker();
                });
            </script>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-sm-offset-4  col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

        <div class="form-group">
            <label>Signature:</label>

        </div>
    </div>
    <div class="clearfix"></div>

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
        <asp:Button ID="Print" runat="server" Text="Print" ValidationGroup="z" OnClick="Print_Click" CssClass="btn btn-primary btnlg" />
        <asp:Label ID="lblRecordNotFound" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>



</asp:Content>
