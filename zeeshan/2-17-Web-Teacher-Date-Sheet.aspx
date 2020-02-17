  <%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-17-Web-Teacher-Date-Sheet.aspx.cs" Inherits="zeeshan._2_17_Web_Date_Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <script type="text/javascript">



         function prints() {
             $("#contents").printArea();

         }
   </script>

      <style type="text/css">
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
        /*Grid Start*/

        /*Grid view Designing*/
        .GridViewStyle {
            font-family: Arial, Sans-Serif;
            font-size: small;
            table-layout: auto;
            border-collapse: collapse;
            border: #1d1d1d 5px solid;
        }
        /*Header and Pager styles*/
        .HeaderStyle, .PagerStyle /*Common Styles*/ {
            background-image: url(Images/HeaderGlassBlack.jpg);
            background-position: center;
            background-repeat: repeat-x;
            background-color: #1d1d1d;
        }

            .HeaderStyle th {
                padding: 10px;
                color: #ffffff;
                text-align: center;
            }

            .HeaderStyle a {
                text-decoration: none;
                color: #ffffff;
                display: block;
                text-align: left;
                font-weight: normal;
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



     <div id="content ">
        <ul id="tabs" class="nav nav-pills red" data-tabs="tabs">
            <li class="active "><a class="btn btn-primary btn-xs" href="2-17-Web-Teacher-Date-Sheet.aspx?m=1" >First Term</a></li>
            <li><a  class="btn btn-primary btn-xs"   href="2-17-Web-Teacher-Date-Sheet.aspx?m=2">Second Term</a></li>
            <li><a class="btn btn-primary btn-xs"  href="2-17-Web-Teacher-Date-Sheet.aspx?m=3">Third Term</a></li>
            
        </ul>
         <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active" id="January">

                <div id="contents">
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Date Sheet</h3>
    </div>
    <br />
    <br />
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
              <h3> <asp:Label ID="lbl" runat="server" Text="Term:"></asp:Label>
                  <asp:Label ID="lblTerm" runat="server" Text=""></asp:Label>
              </h3>

           </div>     
    <div class=" col-xs-8 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Search Class Wise</label>

            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                <asp:ListItem>Choose Your Class</asp:ListItem>
               


            </asp:DropDownList>


            <asp:RequiredFieldValidator ID="rfvClass" runat="server" ControlToValidate="ddlClass" ErrorMessage="Select Your Class" ForeColor="Red" InitialValue="Choose Your Class" ValidationGroup="vg"></asp:RequiredFieldValidator>


        </div>
    </div>

   
    <div class="clearfix"></div>

   


     
    <br />
    <br />


   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>--%>
           <%--Grid View--%>
    <div class="col-xs-12 col-sm-12 col-md-10 col-lg-9 col-md-offset-2 col-lg-offset-3 table-responsive">
        
                <asp:GridView ID="dgvDateSheet"  runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <%--Sr No--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Sr</HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:Label ID="lbl2" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #Eval("Sr")%>' runat="server"></asp:Label>
                                <asp:HiddenField ID="dbID"  runat="server" Value='<% #Eval("DateSheetId") %>'/>
                            </ItemTemplate>
                           


                        </asp:TemplateField>
                        <%-- End Sr No--%>


                        <%--Date--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Date</HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="lbl1" Text='<% #Eval("Date")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                           


                        </asp:TemplateField>
                        <%-- End Date--%>

                        <%--Subject--%>

                        <asp:TemplateField>
                            <HeaderTemplate>Subjects</HeaderTemplate>
                           

                            <ItemTemplate>
                                <asp:Label ID="lbl" Text='<% #Eval("Name")%>' runat="server"></asp:Label>


                            </ItemTemplate>
                           


                        </asp:TemplateField>

                        <%--End of Subject--%>

                        <%--Start Time--%>

                        <asp:TemplateField>
                            <HeaderTemplate>Start_Time</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<% #Eval("Start_Time") %>'>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%--End of Start Time--%>

                        <%--End Time--%>
                         <asp:TemplateField>
                            <HeaderTemplate>End_Time</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<% #Eval("End_Time") %>'>'></asp:Label>

                            </ItemTemplate>
                           
                           
                        </asp:TemplateField>

                        <%--End of End Time--%>

                      







                       



                        
                    </Columns>
                      <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />

                </asp:GridView>


             </div>
</div>
                <%--End Grid View--%>
       <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlClass" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>

     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">

         <input id="btnPrint" type="button" value="Print" onclick="prints()" class="btn btn-primary btnlg" />


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
         <br />
                    <br /><br />
                    <br />
                </div>
                </div>
            </div>
         </div>

</asp:Content>
