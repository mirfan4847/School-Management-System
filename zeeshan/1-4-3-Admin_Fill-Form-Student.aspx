<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-4-3-Admin_Fill-Form-Student.aspx.cs" Inherits="Future._1_4_3_Admin_Fill_Form_Student" %>
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
                 
                margin-top:25%;
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
             #myModal .modal-dialog  {width:400px;}
         
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

             .marginImage {
                 margin-left: 35%;
             }
               #myModal {
                 top: 5%;
                

             }
             #myModal .modal-dialog  {width:443px;}
             
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
                     $('#<%=Image1.ClientID%>').prop('src', e.target.result)
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
                <asp:Button ID="btnSearch" runat="server" Text="Search" cssClass="btn btn-primary" OnClick="btnSearch_Click"  UseSubmitBehavior="false" data-dismiss="modal" />
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

    <%--Student Edit Form--%>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Print Student Record </h3>
    </div>



    <div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4">
            <h5><asp:Label ID="lblRecordNotFound" runat="server" Text="" ForeColor="Red"></asp:Label> </h5>
           
        </div>

        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <%--<h5>Last Admission ID was:<asp:Label ID="lblLastAdmission" runat="server" Text="02222"></asp:Label></h5>--%>
        </div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4 ">
            <div class="divforimage marginImage">
                <asp:Image ID="Image1" ImageUrl="~/Images/Student_Img.jpg" Height="148" Width="148" runat="server" CssClass="img-rounded" />
                <asp:FileUpload ID="fuImg" runat="server" onchange="ShowImagePreview(this);" />
            </div>
        </div>




    </div>


    <div class="clearfix"></div>
    

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    
        <button type="button" id="OpenModal" class="btn btn-primary btnlg" >Search</button>
        
</div>
   
    <div class="clearfix"></div>

    <br />
    <br />
     
    <%--Form 3--%>

     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Class Information  </h3>
    </div>

    <br />
    





    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Class</label>

            <asp:DropDownList ID="ddlClass" runat="server" ValidationGroup="z"  CssClass="form-control" AppendDataBoundItems="true" >
      <asp:ListItem>Choose Your Class</asp:ListItem>
            </asp:DropDownList>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="Choose Your Class" runat="server" ErrorMessage="Choose Your Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>
        </div>
    </div>





    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Section</label>

            <asp:DropDownList ID="ddlSection" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">

                <asp:ListItem>Choose Your Section</asp:ListItem>
            </asp:DropDownList>



            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="Choose Your Section" runat="server" ErrorMessage="Choose Your Section" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSection"></asp:RequiredFieldValidator>
        </div>
    </div>


   





    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Medium</label>

             <asp:DropDownList ID="ddlMedium" runat="server" ValidationGroup="z" CssClass="form-control">
                <asp:ListItem>Choose Your Medium</asp:ListItem>

                <asp:ListItem>English</asp:ListItem>
                <asp:ListItem>Urdu</asp:ListItem>
               
               

            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" InitialValue="Choose Your Medium" runat="server" ErrorMessage="Choose Your Medium" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlMedium"></asp:RequiredFieldValidator>
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admission ID</label>

            <asp:TextBox ID="txtAdminId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAdminId"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ForeColor="Red" runat="server" ControlToValidate="txtAdminId" ErrorMessage="Unavailable/InCorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>



    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Session</label>

            <asp:TextBox ID="txtSession" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtSession"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ForeColor="Red" runat="server" ControlToValidate="txtSession" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="\b(198[1-9]|199[0-9]|20[01][0-9]|202[0-6])\b"></asp:RegularExpressionValidator>
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Fees Status</label>

            <asp:TextBox ID="txtFee" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFee"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" ForeColor="Red" runat="server" ControlToValidate="txtFee" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>


    <div class="clearfix"></div>
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Discount%</label>
            <asp:DropDownList ID="ddlDiscount" runat="server" ValidationGroup="z" CssClass="form-control">
                <asp:ListItem>None</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>75</asp:ListItem>

            </asp:DropDownList>
        </div>
    </div>



    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Family No</label>

            <asp:TextBox ID="txtFamilyNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFamilyNo"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator28" ForeColor="Red" runat="server" ControlToValidate="txtFamilyNo" ErrorMessage="Unavailable/Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>


    <div class="clearfix"></div>



    <br />



    <%--Student Form--%>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Personal Information</h3>
    </div>
    <%--Name--%>

    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Name</label>

       <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtName"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>



    <%--Father--%>

       <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">

   <div class="form-group">
    <label>Father Name</label>

       <asp:TextBox ID="txtFather" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFather"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ForeColor="Red" runat="server" ControlToValidate="txtFather" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>




  
      <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">

   <div class="form-group">
    <label>Date of Birth</label>
       <asp:TextBox ID="txtBirth" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtBirth"></asp:RequiredFieldValidator>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtBirth.ClientID %>').datetimepicker();
           });
           </script>
        </div>
    </div>





     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Place of Birth</label>

        <asp:DropDownList ID="ddlPlaceOfBirth" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Selecet City</asp:ListItem>
            <asp:ListItem>Gujranwala</asp:ListItem>
            <asp:ListItem>Lahore</asp:ListItem>
            <asp:ListItem>Multan</asp:ListItem>
            <asp:ListItem>Karachi</asp:ListItem>
            <asp:ListItem>Sialkot</asp:ListItem>
            
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Your City" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlPlaceOfBirth" InitialValue="Selecet City"></asp:RequiredFieldValidator>
 
        </div>
    </div>


    
     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>B.Form No</label>

       <asp:TextBox ID="txtBform" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtBform"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator5"  ForeColor="Red" runat="server" ControlToValidate="txtBform" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>



    
     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Blood Group </label>

       <asp:DropDownList ID="ddlBloodGroup" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Select Your Blood Group</asp:ListItem>
            <asp:ListItem>A+</asp:ListItem>
            <asp:ListItem>A-</asp:ListItem>
            <asp:ListItem>B+</asp:ListItem>
            <asp:ListItem>B-</asp:ListItem>
            <asp:ListItem>O+</asp:ListItem>
            <asp:ListItem>O-</asp:ListItem>
            <asp:ListItem>AB+</asp:ListItem>
            <asp:ListItem>AB-</asp:ListItem>
            
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="Select Your Blood Group" ErrorMessage="Select Your Blood Group" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlBloodGroup" ></asp:RequiredFieldValidator>
 
        </div>
    </div>



     
     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Gender</label>

         <asp:DropDownList ID="ddlGender" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Select Gender</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
           
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="Select Gender" ErrorMessage="Select Gender" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlGender"></asp:RequiredFieldValidator>
 
        </div>
    </div>



     
     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Father CNIC </label>

       <asp:TextBox ID="txtCnic" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtCnic"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator8"  ForeColor="Red" runat="server" ControlToValidate="txtCnic" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>



     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Father Occupation </label>

       <asp:TextBox ID="txtOcupation" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtOcupation"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator9"  ForeColor="Red" runat="server" ControlToValidate="txtOcupation" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Monthly Income</label>

       <asp:TextBox ID="txtIncome" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtIncome"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator17"  ForeColor="Red" runat="server" ControlToValidate="txtIncome" ErrorMessage="Enetr Numeric Values" ValidationGroup="z" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Religion </label>

       <asp:TextBox ID="txtReligion" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtReligion"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator10"  ForeColor="Red" runat="server" ControlToValidate="txtReligion" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Guardian Name </label>

       <asp:TextBox ID="txtGuardian" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtGuardian"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator11"  ForeColor="Red" runat="server" ControlToValidate="txtGuardian" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>



    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Guardian CNIC </label>

       <asp:TextBox ID="txtGuardianCnic" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtGuardianCnic"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator12"  ForeColor="Red" runat="server" ControlToValidate="txtGuardianCnic" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Guardian Education</label>

       <asp:TextBox ID="txtGuardianEducation" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtGuardianEducation"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator16"  ForeColor="Red" runat="server" ControlToValidate="txtGuardianEducation" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Email</label>

       <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter Your Email" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator13"  ForeColor="Red" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enetr a Valid Email" ValidationGroup="z" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Mobile No</label>

       <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator14"  ForeColor="Red" runat="server" ControlToValidate="txtMobile" ErrorMessage="Wrong/Incorrect Format" ValidationGroup="z" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>



     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Home Tel#</label>

       <asp:TextBox ID="txtHomeTel" runat="server" CssClass="form-control"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtHomeTel"></asp:RequiredFieldValidator>--%>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator15"  ForeColor="Red" runat="server" ControlToValidate="txtHomeTel" ErrorMessage="Enter LandLine#" ValidationGroup="z" ValidationExpression="^(\+)?([9]{1}[2]{1})?-? ?(\()?([0]{1})?[1-9]{2,4}(\))?-? ??(\()?[1-9]{4,7}(\))?$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    
     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Student will Stay in Hostel</label>
         <asp:DropDownList ID="ddlHostel" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
           
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" InitialValue="Choose" ErrorMessage="Choose an Option" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlHostel"></asp:RequiredFieldValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Student Need Special Care</label>

        <asp:DropDownList ID="ddlCare" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
           
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" InitialValue="Choose" ErrorMessage="Choose an Option" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlCare"></asp:RequiredFieldValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6">
    <div class="form-group">
    <label>Home Address</label>

       <asp:TextBox ID="txtHome" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Enter Home Address" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtHome"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator20"  ForeColor="Red" runat="server" ControlToValidate="txtHome" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <%--Form 2--%>

      <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">PREVIOUS INSTITUTIONS </h3>
    </div>

<br />
<br />

    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Institution Name</label>

       <asp:TextBox ID="txtInstitute" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  ForeColor="Red" runat="server" ControlToValidate="txtInstitute" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>



     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Institution Admission No</label>

       <asp:TextBox ID="txtInstituteAdmissionNo" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator4"  ForeColor="Red" runat="server" ControlToValidate="txtInstituteAdmissionNo" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>


     <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Institution Address</label>

       <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator6"  ForeColor="Red" runat="server" ControlToValidate="txtAddress" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>




    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Class</label>

       <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator7"  ForeColor="Red" runat="server" ControlToValidate="txtClass" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>


    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

   <div class="form-group">
    <label>Certificate Issue Date</label>
       <asp:TextBox ID="txtCertificate" runat="server" CssClass="form-control" ></asp:TextBox>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtCertificate.ClientID %>').datetimepicker();
           });
           </script>
        </div>
    </div>




    <div class=" col-xs-12 col-sm-6 col-md-6 col-lg-6" >

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


    <br />
    <br />
    <br />

        
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Brother/Sister Studying at this School</h3>
    </div>


    <%--Student One--%>
     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>1.Student Name</label>
       
       <asp:TextBox ID="txtSiblingName1" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator18"  ForeColor="Red" runat="server" ControlToValidate="txtSiblingName1" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Study Status</label>

       <asp:DropDownList ID="ddlStatus1" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Studying</asp:ListItem>
            <asp:ListItem>Struck off</asp:ListItem>
            <asp:ListItem>At Home</asp:ListItem>
           </asp:DropDownList>

   </div>
    </div>


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Admission No</label>

       <asp:TextBox ID="txtAdminNo1" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator19"  ForeColor="Red" runat="server" ControlToValidate="txtAdminNo1" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>

    <%--Student Two--%>


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>2.Student Name</label>
       
       <asp:TextBox ID="txtSiblingName2" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator21"  ForeColor="Red" runat="server" ControlToValidate="txtSiblingName2" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Study Status</label>

       <asp:DropDownList ID="ddlStatus2" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Studying</asp:ListItem>
            <asp:ListItem>Struck off</asp:ListItem>
            <asp:ListItem>At Home</asp:ListItem>
           </asp:DropDownList>

   </div>
    </div>


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Admission No</label>

       <asp:TextBox ID="txtAdminNo2" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator22"  ForeColor="Red" runat="server" ControlToValidate="txtAdminNo2" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>



    <%--Student Three--%>

     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>1.Student Name</label>
       
       <asp:TextBox ID="txtSiblingName3" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator23"  ForeColor="Red" runat="server" ControlToValidate="txtSiblingName3" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Study Status</label>

       <asp:DropDownList ID="ddlStatus3" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Studying</asp:ListItem>
            <asp:ListItem>Struck off</asp:ListItem>
            <asp:ListItem>At Home</asp:ListItem>
           </asp:DropDownList>

   </div>
    </div>


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Admission No</label>

       <asp:TextBox ID="txtAdminNo3" runat="server" CssClass="form-control" ></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator24"  ForeColor="Red" runat="server" ControlToValidate="txtAdminNo3" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
   </div>
    </div>


    <%--Form 2 ENd--%>




    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">For OFFice Use Only   </h3>


    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Admission Date</label>
            <asp:TextBox ID="txtAdmissionDate" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAdmissionDate"></asp:RequiredFieldValidator>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtAdmissionDate.ClientID %>').datetimepicker();
           });
           </script>
        </div>
        </div>
           

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Remarks</label>

            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" ForeColor="Red" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Approved/Not</label>

             <asp:DropDownList ID="ddlApproved" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Choose</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
           
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" InitialValue="Choose" ErrorMessage="Choose an Option" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlApproved"></asp:RequiredFieldValidator>
        </div>
    </div>





    <%--Form 3 End--%>

           
    

     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="btnPrint" runat="server" Text="Print" ValidationGroup="z"  CssClass="btn btn-primary btnlg" OnClick="btnPrint_Click" />
</div>

   <%-- <script type="text/javascript">
        $(window).load(function () {
            $('#myModal').modal('show');
        });
        </script>--%>
   </asp:Content>
