<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-5-1-Admin_School-Complain-Letter-Student.aspx.cs" Inherits="Future.ComplainLetter" %>

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

        <h3 class="text-info">Student Complain letter</h3>
    </div>



    <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4">
        <h5>Letter No:<asp:Label ID="lblTotalStudents" runat="server" Text="15"></asp:Label>
        </h5>
    </div>
    <div class="clearfix"></div>
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
            <label>Date of Birth</label>
            <asp:TextBox ID="txtBirth" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtBirth"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtBirth.ClientID %>').datetimepicker();
                });
            </script>
        </div>

    </div>

    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>Select Complains</label>
        <br />

    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox1" Text="The Student is Dirty,Needs to be focused on his/her cleanliness." runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox2" Text="The Student always late to School,Make him/her punctual." runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox3" Text="The Student does not come to School in Complete Uniform" runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox4" Text="The Student Does not Complete the Home Work" runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox5" Text="The School fee must be Paid before the 10th of every month otherwise afine shall be charge with fee" runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox6" Text="The Student has not deposited his/her fee,Please Deposit Fee" runat="server" ValidationGroup="z" />
    </div>
    <div class=" col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <asp:CheckBox ID="CheckBox7" Text="Please Provide Books,NoteBooks to the Student" runat="server" ValidationGroup="z" />
    </div>


     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>Other Complains</label>

        <asp:TextBox ID="txtComplains" runat="server" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine"></asp:TextBox>
    </div>

    <div class="clearfix"></div>
    <br />
    <br />
    <br />
     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="Print" runat="server" Text="Print" ValidationGroup="z" OnClick="Print_Click" CssClass="btn btn-primary btnlg" />
          <br />
    <br />
</div>
</asp:Content>
