<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-6-3-Admin-Print-Staff-Info.aspx.cs" Inherits="Future.Print_Staff_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
         .HeaderStyle th {
            padding: 10px;
            text-align: center;
        }

        .RowStyle td /*Common Styles*/ {
            padding: 4px;
            border-right: solid 1px #1d1d1d;
        }
        .AltRowStyle td {
            padding: 4px;
            width: 80px;
            border-right: solid 1px #1d1d1d;
        }


        .EditRowStyle td {
            padding: 0px;
        }

    </style>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#OpenModal").click(function () {
                $("#myModal").modal('show');
            });
        });



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="myModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title text-info">Search Student</h4>
            </div>
            <div class="modal-body">
                <label>Enter Staff ID</label>
                <asp:TextBox ID="txtSearchAdmission" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSearch" runat="server" Text="Search" cssClass="btn btn-primary"  UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnSearch_Click"/>
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


     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Print Staff Information</h3>
    </div>


    <div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4">
            <h5><asp:Label ID="lblLastCodeNo" runat="server" Text=""></asp:Label>
            </h5>
        </div>

        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
            <h5>Code Number:<asp:Label ID="lblLastAdmission" runat="server" Text="02222"></asp:Label></h5>
        </div>

        <div class="col-xs-12 col-sm-3 col-md-4 col-lg-4 ">
            <div class="divforimage marginImage">
                <asp:Image ID="Image1" ImageUrl="~/Images/1.jpg" Height="146" Width="146" runat="server" CssClass="img-rounded" />
                <asp:FileUpload ID="fuImg" runat="server"/>
            </div>
        </div>

        <br />
        <br />
    </div>

    <div class="clearfix"></div>

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    
        <button type="button" id="OpenModal" class="btn btn-primary btnlg" >Search</button>
        
</div>


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Name</label>

       <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtName"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ForeColor="Red" runat="server" ControlToValidate="txtName" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
   </div>
    </div>




    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

   <div class="form-group">
    <label>Father Name</label>

       <asp:TextBox ID="txtFather" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFather"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  ForeColor="Red" runat="server" ControlToValidate="txtFather" ErrorMessage="Enetr Alphabets" ValidationGroup="z" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
 
        </div>
    </div>





    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">

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

    <div class="clearfix"></div>


      <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>CNIC Number</label>

       <asp:TextBox ID="txtCnic" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtCnic"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator5"  ForeColor="Red" runat="server" ControlToValidate="txtCnic" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="\d{5}-\d{7}-\d{1}"></asp:RegularExpressionValidator>
 
        </div>
    </div>



    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Phone Number</label>

       <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtPhoneNo"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  ForeColor="Red" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^(\+)?([9]{1}[2]{1})?-? ?(\()?([0]{1})?[1-9]{2,4}(\))?-? ??(\()?[1-9]{4,7}(\))?$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Mobile No</label>

       <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Mobile Number" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator4"  ForeColor="Red" runat="server" ControlToValidate="txtMobile" ErrorMessage="Wrong/Incorrect Format" ValidationGroup="z" ValidationExpression="^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Email</label>

       <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Your Email" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator6"  ForeColor="Red" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enetr a Valid Email" ValidationGroup="z" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
 
        </div>
    </div>




    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Address</label>

       <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
        </div>
    </div>




    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Qualification</label>

       <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtQualification"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator8"  ForeColor="Red" runat="server" ControlToValidate="txtQualification" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <div class="clearfix"></div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" InitialValue="Select Your Blood Group" ErrorMessage="Select Your Blood Group" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlBloodGroup" ></asp:RequiredFieldValidator>
 
          </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Gender</label>

         <asp:DropDownList ID="ddlGender" runat="server" ValidationGroup="z" CssClass="form-control">
            <asp:ListItem>Select Gender</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
           
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" InitialValue="Select Gender" ErrorMessage="Select Gender" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlGender"></asp:RequiredFieldValidator>
 
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Hiring Date</label>

       
       <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtHireDate"></asp:RequiredFieldValidator>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtHireDate.ClientID %>').datetimepicker();
           });
           </script>
        </div>
    </div>



    <div class="clearfix"></div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>designation</label>

       <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtDesignation"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator12"  ForeColor="Red" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Experience</label>

       <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtExperience"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator13"  ForeColor="Red" runat="server" ControlToValidate="txtExperience" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Favourite Subject</label>

       <asp:TextBox ID="txtFavSbj" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtFavSbj"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator14"  ForeColor="Red" runat="server" ControlToValidate="txtFavSbj" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Section</label>

       <asp:TextBox ID="txtSection" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtSection"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator15"  ForeColor="Red" runat="server" ControlToValidate="txtSection" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>College/University</label>

       <asp:TextBox ID="txtclg" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtclg"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator16"  ForeColor="Red" runat="server" ControlToValidate="txtclg" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>
 
        </div>
    </div>



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info"> Academic Qualification Detail</h3>
    </div>
    <div class="clearfix"></div>
    <div class="col-lg-10 col-lg-offset-1 col-md-12 col-sm-12 col-xs-12">
    <asp:GridView ID="gvAcademicQualification" runat="server" AutoGenerateColumns="False" ShowFooter="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Qualification
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQualification" runat="server" Text='<%#Bind("A_Qualification") %>'>'></asp:Label>
                </ItemTemplate>
               

            </asp:TemplateField>
        

        <asp:TemplateField>
                <HeaderTemplate>
                    Year Of Passing
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblYearOfPassing" runat="server" Text='<%#Bind("A_PassingYear") %>'></asp:Label>
                </ItemTemplate>
               

            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Registration Number
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRegistrationNo" runat="server" Text='<%#Bind("A_RegistrationNo") %>'></asp:Label>
                </ItemTemplate>
                

            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Devision
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDevision" runat="server" Text='<%#Bind("A_Devision") %>'></asp:Label>
                </ItemTemplate>
              
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Institution
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblInstitution" runat="server" Text='<%#Bind("A_Institution") %>'></asp:Label>
                </ItemTemplate>
              

            </asp:TemplateField>
            
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
        <FooterStyle ForeColor="#000066"/>
    </asp:GridView>
        </div>

    <div class="clearfix"></div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Professional Qualification</h3>
    </div>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <h4>Details(If any)
            </h4>
        </div>

    <div class="clearfix"></div>

    <div class="col-lg-10 col-lg-offset-1 col-md-12 col-sm-12 col-xs-12 table-responsive">
    <asp:GridView ID="gvProfessionalQualification" runat="server" AutoGenerateColumns="False">

        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Qualification
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQualification" runat="server" Text='<%#Bind("P_Qualification") %>'>'></asp:Label>
                </ItemTemplate>
             

            </asp:TemplateField>
        

        <asp:TemplateField>
                <HeaderTemplate>
                    Year Of Passing
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblYearOfPassing" runat="server" Text='<%#Bind("PassingYear") %>'></asp:Label>
                </ItemTemplate>
            
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Registration Number
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRegistrationNo" runat="server" Text='<%#Bind("RegistrationNo") %>'></asp:Label>
                </ItemTemplate>
            
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Devision
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDevision" runat="server" Text='<%#Bind("Devision") %>'></asp:Label>
                </ItemTemplate>
          

            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Institution
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblInstitution" runat="server" Text='<%#Bind("Institution") %>'></asp:Label>
                </ItemTemplate>
               

            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate></ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkbtnAdd" runat="server">Add</asp:LinkButton></FooterTemplate>
            </asp:TemplateField>

            
        </Columns>
        <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
        <FooterStyle ForeColor="#000066"/>
    </asp:GridView>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">  For Office use only </h3>
    </div>


    <div class="clearfix"></div>

     


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Salary</label>

       <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtSalary"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator7"  ForeColor="Red" runat="server" ControlToValidate="txtSalary" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>

    </div>
    </div>

    
     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Annual Increment</label>

       <asp:TextBox ID="txtAnnualInc" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtAnnualInc"></asp:RequiredFieldValidator>
   </div>
    </div>

    

     


     <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Basic Pay Scale</label>

       <asp:TextBox ID="txtBps" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtBps"></asp:RequiredFieldValidator>
   </div>
    </div>



    <div class="clearfix"></div>

    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Appointed As</label>
       <asp:DropDownList ID="ddlAppointedAs" runat="server" CssClass="form-control">
           <asp:ListItem>Select Designation</asp:ListItem>
           <asp:ListItem>Principle</asp:ListItem>
           <asp:ListItem>Vice Principle</asp:ListItem>
           <asp:ListItem>Senior Science Teacher</asp:ListItem>
           <asp:ListItem>Junior Science Teacher</asp:ListItem>
           <asp:ListItem>Senior Arts Teacher</asp:ListItem>
           <asp:ListItem>Junior Arts Teacher</asp:ListItem>
           <asp:ListItem>Primary Teacher</asp:ListItem>
           <asp:ListItem>Clerk</asp:ListItem>
           <asp:ListItem>Computer Instructer</asp:ListItem>
           <asp:ListItem>Peon</asp:ListItem>
           <asp:ListItem>Watchman</asp:ListItem>
       </asp:DropDownList>

               <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" InitialValue="Select Designation" ErrorMessage="Appointed As" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlAppointedAs"></asp:RequiredFieldValidator>

   </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Trial Period</label>
       <asp:DropDownList ID="ddlTrialPer" runat="server" CssClass="form-control">
           <asp:ListItem>Enter Trial period</asp:ListItem>
           <asp:ListItem>Less than One Month</asp:ListItem>
           <asp:ListItem>One Month</asp:ListItem>
           <asp:ListItem>Two Month</asp:ListItem>
           <asp:ListItem>None</asp:ListItem>
       </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" InitialValue="Enter Trial period" ErrorMessage="Select Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlTrialPer"></asp:RequiredFieldValidator>


   </div>
    </div>


    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4" >

   <div class="form-group">
    <label>Contract </label>

       <asp:TextBox ID="txtContract" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtContract"></asp:RequiredFieldValidator>
   </div>
    </div>

    <div class="clearfix"></div>
    
    <div class=" col-xs-12 col-sm-4 col-md-4 col-lg-4">
    <div class="form-group">
    <label>Date</label>

       
       <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Pick Up Date" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtDate"></asp:RequiredFieldValidator>

       <script type="text/javascript">
           $(function () {
               $('#<%= txtDate.ClientID %>').datetimepicker();
           });
           </script>
        </div>
    </div>

    <div class="clearfix"></div>

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="btnPrint" runat="server" Text="Print" ValidationGroup="z"  CssClass="btn btn-primary btnlg" OnClick="btnPrint_Click" />
</div>
     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
    <asp:Button ID="btnEmptyPrint" runat="server" Text="Print Empty Form"  CssClass="btn btn-primary btnlg" OnClick="btnEmptyPrint_Click" />
</div>

    </asp:Content>
