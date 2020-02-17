<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-4-5-Admin_Edit-Medical-Report-Student.aspx.cs" Inherits="Future._1_4_5_Admin_Edit_Medical_Report_Student" %>
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
            .xs-marginTextBox {
                margin-left: -23%;
            }

            .err {
                margin-top: 30% !important;
                margin-left: 80% !important;
            }

            .btnlg {
                margin-top: 25%;
            }




            #myModal {
                top: 25%;
            }

            #RecordNotFound{
                 top: 25%
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
    
    
                <%--Search Modal--%>
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


    <%--//Search Modal--%>

                <%--Record Not Found--%>
               <div id="RecordNotFound" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background:#AC0200; border-top-left-radius:4px; border-top-right-radius:4px;" >
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">INFORMATION</h4>
                </div>
                <div class="modal-body">
                   <h4> <asp:Label ID="lblStudentIdNotFound" CssClass="text-danger" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>



    <%--//End Record Not Found--%>



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Edit Student Medical Report</h3>
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

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
       
        <div class="form-group">
            <label>Admission ID</label>

            <asp:TextBox ID="txtAdminId" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAdminId"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ForeColor="Red" runat="server" ControlToValidate="txtAdminId" ErrorMessage="Unavailable/InCorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>

    <%--Name--%>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Name</label>

            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>



    <%--Father--%>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">


        <div class="form-group">
            <label>Father Name</label>

            <asp:TextBox ID="txtFather" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFather"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" runat="server" ControlToValidate="txtFather" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Emergency Contacts</h3>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Name</label>

            <asp:TextBox ID="txtEmergencyName1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtEmergencyName1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ForeColor="Red" runat="server" ControlToValidate="txtEmergencyName1" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Home Tel#</label>

            <asp:TextBox ID="txtHomeTel1" runat="server" CssClass="form-control"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtHomeTel1"></asp:RequiredFieldValidator>--%>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ForeColor="Red" runat="server" ControlToValidate="txtHomeTel1" ErrorMessage="Enter LandLine#" ValidationGroup="z" ValidationExpression="^(\+)?([9]{1}[2]{1})?-? ?(\()?([0]{1})?[1-9]{2,4}(\))?-? ??(\()?[1-9]{4,7}(\))?$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">


        <div class="form-group">
            <label>Mobile No</label>

            <asp:TextBox ID="txtMobile1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtMobile1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ForeColor="Red" runat="server" ControlToValidate="txtMobile1" ErrorMessage="Wrong/Incorrect Format" ValidationGroup="z" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>

        </div>

    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Name</label>

            <asp:TextBox ID="txtEmergencyName2" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ForeColor="Red" runat="server" ControlToValidate="txtEmergencyName2" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Home Tel#</label>

            <asp:TextBox ID="txtHomeTel2" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ForeColor="Red" runat="server" ControlToValidate="txtHomeTel2" ErrorMessage="Enter LandLine#" ValidationGroup="z" ValidationExpression="^(\+)?([9]{1}[2]{1})?-? ?(\()?([0]{1})?[1-9]{2,4}(\))?-? ??(\()?[1-9]{4,7}(\))?$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">


        <div class="form-group">
            <label>Mobile No</label>

            <asp:TextBox ID="txtMobile2" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ForeColor="Red" runat="server" ControlToValidate="txtMobile2" ErrorMessage="Wrong/Incorrect Format" ValidationGroup="z" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>

        </div>

    </div>




    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Student Medical History</h3>
    </div>

    <br />
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
        <label>Please Tick if Student has suffered from any of the following</label>
    </div>

    <br />

    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkChickenPox" Text="  Chicken Pox" runat="server" ValidationGroup="z" OnCheckedChanged="chkChickenPox_CheckedChanged" AutoPostBack="true" />
    </div>

    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkDiabetes" Text="  Diabetes" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkDiabetes_CheckedChanged" />

    </div>

    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkEczema" Text="Eczema  " runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkEczema_CheckedChanged" />

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkMumps" Text=" Mumps " runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkMumps_CheckedChanged" />

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkAsthma" Text=" Asthma " runat="server" ValidationGroup="z"  AutoPostBack="true" OnCheckedChanged="chkAsthma_CheckedChanged"/>

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkRheumatic" Text=" Rheumatic " runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkRheumatic_CheckedChanged" />

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkEpilepsy" Text="Epilepsy" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkEpilepsy_CheckedChanged" />

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkBlood" Text="Blood" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkBlood_CheckedChanged"/>

    </div>
    <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkSpeech" Text="Speech" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkSpeech_CheckedChanged"/>

    </div>
    <div class="clearfix"></div>


    <div class=" col-xs-6 col-xs-offset-3 col-sm-4 col-sm-offset-4 col-md-4 col-lg-4">
        <asp:CheckBox ID="chkNoProb" Text="No Problem" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkNoProb_CheckedChanged" />

    </div>
    <div class="clearfix"></div>


    <br />

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <label>Has the student got any Chronic Medical problem?</label>
        <asp:CheckBox ID="chkYes" Text="Yes" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkYes_CheckedChanged" />
        <asp:CheckBox ID="chkNo" Text="No" runat="server" ValidationGroup="z" AutoPostBack="true" OnCheckedChanged="chkNo_CheckedChanged" />


    </div>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <label>If Yes,Please give details below</label>

        <asp:TextBox ID="txtChronicDetails" runat="server" CssClass="form-control" ValidationGroup="z" Visible="false" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="clearfix"></div>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Family Medical History</h3>
    </div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
        <label>Please give details if there is any family history of the following illeness</label>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>T.B.</label>

            <asp:TextBox ID="txtTB" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" runat="server" ControlToValidate="txtTB" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Epilepsy</label>

            <asp:TextBox ID="txtEpilepsy" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" runat="server" ControlToValidate="txtEpilepsy" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Diabetes</label>

            <asp:TextBox ID="txtDiabetes" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ForeColor="Red" runat="server" ControlToValidate="txtDiabetes" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Others</label>

            <asp:TextBox ID="txtOthers" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ForeColor="Red" runat="server" ControlToValidate="txtOthers" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="clearfix"></div>


     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
        <label>Note:it is Desirable that</label>
    </div>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
        <label>(a)All Children have vaccination once in 3 years</label>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
        <label>(b)T.A.B inclusion is Advisable once in a Year</label>
    </div>

     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

   <div class="form-group">
    <label>Date</label>
       <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtDate"></asp:RequiredFieldValidator>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtDate.ClientID %>').datetimepicker();
           });
           </script>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-sm-offset-3 col-md-4 col-md-offset-4 col-lg-4 col-lg-offset-4">

        <div class="form-group">
            <label>Signature:</label>

        </div>
    </div>
    <div class="clearfix"></div>


    </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkNoProb" EventName="CheckedChanged" />
            </Triggers>
            </asp:UpdatePanel>
    

     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="z" OnClick="btnUpdate_Click" CssClass="btn btn-primary btnlg" />
</div>

</asp:Content>
