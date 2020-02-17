<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-4-8-Admin_School-Leaving-Certificate-Student.aspx.cs" Inherits="Future._1_4_8_Admin_School_Leaving_Certificate_Student" %>

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

    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgLeaving.ClientID%>').prop('src', e.target.result)
                        .width(148)
                        .height(148);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>


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
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnSearch_Click" />
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

        <h3 class="text-info">School Leaving Certificate</h3>
    </div>
    <br />
    <br />


    <div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4">
            <h5 style="color: red">Last Serial No was:<asp:Label ID="lblLastSerial" ForeColor="Red" runat="server" Text="1"></asp:Label>
            </h5>
        </div>

        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <h5>Serial No:<asp:Label ID="lblSerial" runat="server" Text="2"></asp:Label></h5>
        </div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4 ">
            <div class="divforimage marginImage">
                <asp:Image ID="ImgLeaving" ImageUrl="~/Images/Student_Img.jpg" Height="148" Width="148" runat="server" CssClass="img-rounded" />
                <asp:FileUpload ID="fuImg" runat="server" onchange="ShowImagePreview(this);" />
            </div>
        </div>

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


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admission Date</label>
            <asp:TextBox ID="txtAdmissionDate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAdmissionDate"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtAdmissionDate.ClientID %>').datetimepicker();
                });
            </script>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admitted Class</label>

            <asp:DropDownList ID="ddlClass" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose Your Class</asp:ListItem>
            </asp:DropDownList>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="Choose Your Class" runat="server" ErrorMessage="Choose Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Section</label>

            <asp:DropDownList ID="ddlSection" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose Your Section</asp:ListItem>
            </asp:DropDownList>



            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="Choose Your Section" runat="server" ErrorMessage="Choose Section" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSection"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Present Class</label>

            <asp:DropDownList ID="ddlPresent" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose Your Class</asp:ListItem>
              </asp:DropDownList>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="Choose Your Class" runat="server" ErrorMessage="Choose Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlPresent"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Father Occupation </label>

            <asp:TextBox ID="txtOcupation" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ForeColor="Red" runat="server" ControlToValidate="txtOcupation" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Religion </label>

            <asp:TextBox ID="txtReligion" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtReligion"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ForeColor="Red" runat="server" ControlToValidate="txtReligion" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>

        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <div class="form-group">
            <label>Home Address</label>

            <asp:TextBox ID="txtHome" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Enter Home Address" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtHome"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ForeColor="Red" runat="server" ControlToValidate="txtHome" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">



        <div class="form-group">
            <label>Co-Curricular</label>

            <asp:DropDownList ID="ddlCurricular" runat="server" ValidationGroup="z" CssClass="form-control">
                <asp:ListItem>Choose Activities</asp:ListItem>
                <asp:ListItem>Debate</asp:ListItem>
                <asp:ListItem>Singing</asp:ListItem>
                <asp:ListItem>Cricket</asp:ListItem>
                <asp:ListItem>Fine-Arts</asp:ListItem>
                <asp:ListItem>Gardening</asp:ListItem>
                <asp:ListItem>Music</asp:ListItem>
                <asp:ListItem>Athletics</asp:ListItem>
                <asp:ListItem>Swimming</asp:ListItem>

            </asp:DropDownList>



        </div>
    </div>
    <div class="clearfix"></div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Attendance From</label>
            <asp:TextBox ID="txtAttendanceFrom" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAttendanceFrom"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtAttendanceFrom.ClientID %>').datetimepicker();
                });
            </script>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <div class="form-group">
            <label>Attendance To</label>
            <asp:TextBox ID="txtAttendanceTo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAttendanceTo"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtAttendanceTo.ClientID %>').datetimepicker();
                });
            </script>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <div class="form-group">
            <label>Date of Leaving</label>
            <asp:TextBox ID="txtDateLeaving" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtDateLeaving"></asp:RequiredFieldValidator>

            <script type="text/javascript">
                $(function () {
                    $('#<%= txtDateLeaving.ClientID %>').datetimepicker();
                });
            </script>
        </div>
    </div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <div class="form-group">
            <label>Fee Due</label>

            <asp:TextBox ID="txtFeeDue" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFeeDue"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ForeColor="Red" runat="server" ControlToValidate="txtFeeDue" ErrorMessage="Enetr Numeric Values" ValidationGroup="z" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

        </div>
    </div>

    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <label>Reason of Leaving</label>
        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" ValidationGroup="z" TextMode="MultiLine"></asp:TextBox>
    </div>


    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Fee Remarks</label>

            <asp:TextBox ID="txtFeeRemarks" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" ForeColor="Red" runat="server" ControlToValidate="txtFeeRemarks" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>General Remarks</label>

            <asp:TextBox ID="txtGeneralRemarks" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" runat="server" ControlToValidate="txtGeneralRemarks" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
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

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

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
