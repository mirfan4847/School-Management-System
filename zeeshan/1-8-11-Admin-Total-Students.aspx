<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-8-11-Admin-Total-Students.aspx.cs" Inherits="zeeshan._1_8_11_Admin_Total_Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Institution Students</h3>
    </div>
    <br />
    <br />

     <div class=" col-xs-12 col-sm-6 col-md-5 col-lg-5">



        <div class="form-group">
            <label>Search Class Wise</label>

            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AppendDataBoundItems="true"  AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                <asp:ListItem>Choose Your Class</asp:ListItem>
               


            </asp:DropDownList>


        </div>
    </div>

     <div class=" col-xs-12 col-sm-6 col-md-5 col-lg-5">

        <div class="form-group">
            <label>Search Section Wise</label>

            <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control"  AppendDataBoundItems="true" Enabled="False" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                <asp:ListItem>Choose Your Section</asp:ListItem>
                
                
               


            </asp:DropDownList>


        </div>
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
                    <asp:Label ID="Label2" CssClass="text-right " runat="server" Text="Admission ID:"></asp:Label>

                    <asp:Label ID="lbldes" CssClass="text-center textbold" runat="server" Text='<%#Bind("AdmissionId") %>'></asp:Label>
                    </td>
                        </tr>
                <br />
                <tr>
                    <td>
                    <asp:Label ID="Label1" CssClass="text-right " runat="server" Text="Name:"></asp:Label>

                    <asp:Label ID="lblname" CssClass="text-right textbold" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                    </td>
                </tr>
                <br />
               
                <tr>
                    <td>
                    <asp:Label ID="Label3" CssClass="text-right " runat="server" Text="Class:"></asp:Label>

                    <asp:Label ID="lblcat" runat="server" CssClass="text-center textbold" Text='<%#Bind("className") %>'></asp:Label>
                    </td>
                        </tr>

                <tr>
                    <td>
                    <asp:Label ID="Label4" CssClass="text-right " runat="server" Text="Section:"></asp:Label>

                       <asp:Label ID="lblhireDate" runat="server" CssClass="text-center textbold" Text='<%#Bind("sectionName") %>'></asp:Label>
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
</asp:Content>
