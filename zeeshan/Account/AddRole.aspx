<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="zeeshan.Account.AddRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Roll</h3>
                    </div>
                    <div class="panel-body">

                        <fieldset>
                            <div class="form-group">



                                <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                            </div>




                            <asp:Button ID="btnAddRole" class="btn btn-lg btn-primary btn-block"  runat="server" Text="Add Role" OnClick="btnAddRole_Click" />


                        </fieldset>

                    </div>


                     
                </div>
            </div>
        </div>
    </div>


     <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Delete</h3>
                    </div>
                    <div class="panel-body">

                        <fieldset>
                            <div class="form-group">

                            <asp:DropDownList ID="ddlDelete" runat="server" Height="20px" Width="200"></asp:DropDownList>


                            </div>



                            <asp:Button ID="btnDelete" class="btn btn-lg btn-primary btn-block" OnClick="btnDelete_Click"  runat="server" Text="Delete Role" />



                        </fieldset>

                    </div>


                     
                </div>
            </div>
        </div>
    </div>



    </div>
    </form>
</body>
</html>
