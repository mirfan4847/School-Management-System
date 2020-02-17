<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-6-Web-Staff.aspx.cs" Inherits="Future.staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .textbold{
            font: bolder!important;
            color:black!important;

        }


       
        @media screen and (max-width:360px) {


            .btnlg {
                margin-top: 34%;
            }

            #RecordNotFound {
                top: 25%;
            }
        }



        @media screen and (min-width:768px) {
            .btnlg {
                margin-top: 24%;
            }

            #RecordNotFound {
                top: 5%;
            }

                #RecordNotFound .modal-dialog {
                    width: 400px;
                }
        }


        @media screen and (min-width:980px) {
            .btnlg {
                margin-top: 17%;
            }
        }

        @media screen and (min-width:1280px) {
            .btnlg {
                width: 100px;
                height: 40px;
                margin-left: 15px;
                margin-top: 7%;
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
                margin-top: 5%;
            }
        }

        .TextBox {
            width: 100%;
        }

        .Editbtn {
            width: 50px;
        }

    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


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
                        <asp:Label ID="lblStudentIdNotFound" CssClass="text-danger" runat="server" Text="Please Select Class"></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
     <%--Record Not Found--%>


 <div id="content ">
        <ul id="tabs" class="nav nav-pills red" data-tabs="tabs">
            <li class="active "><a class="btn btn-primary btn-xs" href="2-6-Web-Staff.aspx?m=Science">Science</a></li>
            <li><a class="btn btn-primary btn-xs" href="2-6-Web-Staff.aspx?m=Arts">Arts</a></li>
              <li><a class="btn btn-primary btn-xs" href="2-6-Web-Staff.aspx?m=Computer Science">Computer Science</a></li>
            <li><a class="btn btn-primary btn-xs" href="2-6-Web-Staff.aspx?m=Administrator">Administrator</a></li>

        </ul>
        <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active" id="January">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <h3>
                        <asp:Label ID="lblTerm" runat="server" Text="" CssClass="text-info text-left"></asp:Label></h3>
                </div>
                    <div class="clearfix"></div>
    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
    
    <asp:DataList ID="DataList1"  RepeatColumns="5" RepeatDirection="Horizontal" runat="server" CssClass="no">
        <ItemTemplate>
             <div class="col-lg-1 col-lg-offset-2 ">
            <table  >
                <tr>
                    <td>
                        <asp:Image ID="Image1" class="img-rounded" ImageUrl='<%#Bind("Picture") %>' Height="150px" Width="150px" runat="server" />
                   </td>
                </tr>

                <tr>
                    <td>
                    <asp:Label ID="Label1" CssClass="text-right " runat="server" Text="Name:"></asp:Label>

                    <asp:Label ID="lblname" CssClass="text-right textbold" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </td>
                </tr>
                <br />
                <tr>
                    <td>
                    <asp:Label ID="Label2" CssClass="text-right " runat="server" Text="Designation:"></asp:Label>

                    <asp:Label ID="lbldes" CssClass="text-center textbold" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                    </td>
                        </tr>
                <br />
                <tr>
                    <td>
                    <asp:Label ID="Label3" CssClass="text-right " runat="server" Text="Qualification:"></asp:Label>

                    <asp:Label ID="lblcat" runat="server" CssClass="text-center textbold" Text='<%#Bind("Qualification") %>'></asp:Label>
                    </td>
                        </tr>

                <tr>
                    <td>

                        <h4>Since:</h4><asp:Label ID="lblhireDate" runat="server" CssClass="text-center textbold" Text='<%#Bind("Date") %>'></asp:Label>
                    </td>
                        </tr>
            </table>
        </div>
        </ItemTemplate>
        
    </asp:DataList>
        </div>
        
        <div class="clearfix"></div>
    <br />
    <br />
    <br />
    <br />


                </div>
            </div>
     </div>

    
     
</asp:Content>
