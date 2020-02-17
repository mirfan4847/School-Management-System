<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAuthenticated.aspx.cs" Inherits="zeeshan.NotAuthenticated_aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.spacelab.css" rel="stylesheet" />

</head>
<body>
  <form id="form1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background-color:#1f4764">
    <br />
    <br />
    <br />
    <br />
    <br />
    </div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <h3 style="text-align:center;">You are not Authenticated User,Please Login with User Account </h3>
            <br />
            <br />

            
                <div class=" col-xs-4 col-xs-offset-2 col-sm-4 col-sm-offset-2   col-md-4 col-md-offset-2  col-lg-4 col-lg-offset-2  ">
                    <asp:Button ID="btnWeb" runat="server" Text="Login as Student" CssClass="btn btn-primary btnlg" OnClick="btnWeb_Click" />
                   
                    <br />
                    <br />

                </div>

                <div class=" col-xs-4 col-xs-offset-2 col-sm-4 col-sm-offset-2   col-md-4 col-md-offset-2  col-lg-4 col-lg-offset-2  ">
            
                    <asp:Button ID="btnAdmin" runat="server" Text="Login as Admin" CssClass="btn btn-primary btnlg" OnClick="btnAdmin_Click" />
                   
                    <br />
                    <br />

                </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background-color:#1f4764">
    <br />
    <br />
    <br />
    <br />
    <br />
    </div>
    </form>
</body>
</html>

