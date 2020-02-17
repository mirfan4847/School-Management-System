<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-6-6-Admin-Add-Staff-Salary.aspx.cs" Inherits="Future.Add_Staff_Salary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">  Add New Staff </h3>
    </div>

    
    <div class="clearfix"></div>

    <div class=" col-xs-12 col-sm-3 col-md-3 col-lg-3" >

   <div class="form-group">
    <label>Select Any Name</label>
       <asp:DropDownList ID="ddlSelectName" runat="server" CssClass="form-control">
           <asp:ListItem>Select Name</asp:ListItem>
           <asp:ListItem>Less than One Month</asp:ListItem>
           <asp:ListItem>One Month</asp:ListItem>
           <asp:ListItem>Two Month</asp:ListItem>
           <asp:ListItem>None</asp:ListItem>
       </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" InitialValue="Select Name" ErrorMessage="Select Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSelectName"></asp:RequiredFieldValidator>

   </div>
    </div>

    <div class=" col-xs-12 col-sm-3 col-md-3 col-lg-3" >

   <div class="form-group">
    <label>Select Any Section</label>
       <asp:DropDownList ID="ddlSelectSection" runat="server" CssClass="form-control">
           <asp:ListItem>Select Section</asp:ListItem>
           <asp:ListItem>Less than One Month</asp:ListItem>
           <asp:ListItem>One Month</asp:ListItem>
           <asp:ListItem>Two Month</asp:ListItem>
           <asp:ListItem>None</asp:ListItem>
       </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="Select Section" ErrorMessage="Select Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSelectSection"></asp:RequiredFieldValidator>

   </div>
    </div>


    
    <div class=" col-xs-12 col-sm-3 col-md-3 col-lg-3" >

   <div class="form-group">
    <label>Select Any Session</label>
       <asp:DropDownList ID="ddlSelectSession" runat="server" CssClass="form-control">
           <asp:ListItem>Select Session</asp:ListItem>
           <asp:ListItem>Less than One Month</asp:ListItem>
           <asp:ListItem>One Month</asp:ListItem>
           <asp:ListItem>Two Month</asp:ListItem>
           <asp:ListItem>None</asp:ListItem>
       </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="Select Section" ErrorMessage="Select Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSelectSession"></asp:RequiredFieldValidator>

   </div>
    </div>


     <div class=" col-xs-12 col-sm-2 col-md-2 col-lg-2" >

   <div class="form-group">
    <label>Working Days</label>

       <asp:TextBox ID="txtWorkingDays" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Enter a Value" ForeColor="Red" ValidationGroup="z" ControlToValidate="txtWorkingDays"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator7"  ForeColor="Red" runat="server" ControlToValidate="txtWorkingDays" ErrorMessage="Incorrect Format" ValidationGroup="z" ValidationExpression="^[a-zA-Z0-9]*$"></asp:RegularExpressionValidator>

    </div>
    </div>

    <div style="margin-top:23px;" class=" col-xs-12 col-sm-1  col-md-1 col-lg-1">
    <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="z" CssClass="btn btn-primary btnlg" />
</div>

</asp:Content>
