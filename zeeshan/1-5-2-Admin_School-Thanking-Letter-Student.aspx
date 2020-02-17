<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-5-2-Admin_School-Thanking-Letter-Student.aspx.cs" Inherits="Future.ThankingLetter" %>
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

        <h3 class="text-info">Thanking Letter</h3>
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
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

     <div class="form-group">
    <label>To</label>

       <asp:TextBox ID="txtParents" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtParents"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ForeColor="Red" runat="server" ControlToValidate="txtParents" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

     <div class="form-group">
    <label>F/M of</label>

       <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtStudentName"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ForeColor="Red" runat="server" ControlToValidate="txtStudentName" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>

     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admission ID</label>

            <asp:TextBox ID="txtStudentId" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtStudentId"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ForeColor="Red" runat="server" ControlToValidate="txtStudentId" ErrorMessage="Unavailable/InCorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>

     <div class=" col-xs-12 col-sm-4 col-sm-offset-1 col-md-4 col-md-offset-1 col-lg-4 col-lg-offset-1">

         <label>Dear Sir/Madam,</label>

     </div>
    <div class="clearfix"></div>

     <div class=" col-xs-12 col-sm-11 col-sm-offset-1 col-md-6 col-md-offset-2 col-lg-6 col-lg-offset-2">
         <asp:TextBox ID="txtSubject" CssClass="form-control text" ValidationGroup="z" Text="Subject:-Thank You for choosing our Insititute for your Child!" runat="server"></asp:TextBox>
     </div>
    <div class="clearfix"></div>
    <br />
     <div class="col-xs-12 col-sm-11 col-sm-offset-1 col-md-6 col-md-offset-2 col-lg-6 col-lg-offset-2">
         
        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" Rows="14" Text="It is our pleasure to welcome you to one of the leading school network allover the world. We are delighted to have you on board as Bright Future Model School
Counties to establish it self as the leading provider of the best knowledge products and services all over the world.

The Bright Future Model School is begun to herald in a new era of successful, innovative and customer friendly educational programs. Using education system and our services we are the forefront of the Pakistan.                                
           
Regards." ValidationGroup="z" TextMode="MultiLine"></asp:TextBox>
    </div>

     <div class="clearfix"></div>
    <br />
    
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
          <br />
    <br />
</div>
   

</asp:Content>
