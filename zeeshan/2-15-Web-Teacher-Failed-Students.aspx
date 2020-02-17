<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-15-Web-Teacher-Failed-Students.aspx.cs" Inherits="zeeshan._2_15_Web_Teacher_Failed_Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">



         function prints() {
             $("#contents").printArea();

         }
   </script>

    <style type="text/css">
        @media screen and (max-width:360px) {


            .btnlg {
                margin-top: 10%;
                margin-left: 55%;
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
                margin-top: 11%;
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
            width: 70px;
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


        .modal.fade:not(.in).bottom .modal-dialog {
            -webkit-transform: translate3d(0, 25, 0);
            transform: translate3d(0, 25, 0);
            /*top: translate3d(0, -25%, 0)
bottom: translate3d(0, 25%, 0)
left: translate3d(-25%, 0, 0)
right: translate3d(25%, 0, 0)*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <%--Record Not Found--%>
                <div id="RecordNotFound" class="modal fade bottom">
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
            <li class="active "><a class="btn btn-primary btn-xs" href="2-15-Web-Teacher-Failed-Students.aspx?m=1" >First Term</a></li>
            <li><a  class="btn btn-primary btn-xs"   href="2-15-Web-Teacher-Failed-Students.aspx?m=2">Second Term</a></li>
            <li><a class="btn btn-primary btn-xs"  href="2-15-Web-Teacher-Failed-Students.aspx?m=3">Third Term</a></li>
            
        </ul>
        <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active" id="January">
                <div id="contents">
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Failed Students</h3>
    </div>
    <br />
    <br />
    

                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <h3><asp:Label ID="Label4" runat="server" Text="Term:" CssClass="text-info "></asp:Label>
                <asp:Label ID="lblTerm" runat="server" Text="" CssClass="text-info text-left"></asp:Label></h3>
                    </div>
     <div class=" col-xs-12 col-sm-6 col-md-5 col-lg-5">



        <div class="form-group">
            <label>Search Class Wise</label>

            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AppendDataBoundItems="true"  AutoPostBack="true"  OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                <asp:ListItem>Choose Your Class</asp:ListItem>
               


            </asp:DropDownList>


        </div>
    </div>

     <div class=" col-xs-12 col-sm-6 col-md-5 col-lg-5">

        <div class="form-group">
            <label>Search Section Wise</label>

            <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control"  AppendDataBoundItems="true" Enabled="False" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" >
                <asp:ListItem>Choose Your Section</asp:ListItem>
                
                
               


            </asp:DropDownList>


        </div>
    </div>
     <br />
    <br />

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

                        <div class="col-xs-12 col-sm-12 col-md-9 col-lg-12 col-md-offset-3 col-lg-offset-2 table-responsive">
        
                <asp:GridView ID="dgvPromotedStudents"  runat="server" AutoGenerateColumns="false" CssClass="gv" >
                    <Columns>
                        <%--Roll_No--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Roll_No</HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Studentid")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%-- End Roll_No--%>


                        <%--Student Name--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Student Name</HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<% #bind("StudentName")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <%-- End Student Name--%>

                       

                        <%--Obtained Marks--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Obtained Marks</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblObtainedMarks" runat="server" Text='<% #bind("ObtainedMarks") %>'>' ></asp:Label>
                            </ItemTemplate>
                             
                           
                            
                        </asp:TemplateField>

                        <%--End of Obtained Marks--%>

                         <%--Total Marks--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Total Marks</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTotalMarks" runat="server" Text='<% #bind("TotalSubjectMarks") %>'>'></asp:Label>

                            </ItemTemplate>
                            
                            
                        </asp:TemplateField>

                        <%--End of Total Marks--%>

                         <%--Percentage--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Percentage</HeaderTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPercentage" runat="server" Text='<% #bind("Percentage") %>'>'></asp:Label>

                            </ItemTemplate>

                        </asp:TemplateField>

                        <%--End of Percentage--%>

                         <%--Grade--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Grade</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGrade" runat="server" Text='<% #bind("Grade") %>'>'></asp:Label>

                            </ItemTemplate>
                           
                        </asp:TemplateField>

                        <%--End of Grade--%>

                         <%-- Start ofStatus--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Status</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<% #bind("PromotedStatus") %>'>'></asp:Label>

                            </ItemTemplate>
                           
                        </asp:TemplateField>

                        <%--End of Status--%>

                      
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

       <%-- </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="ddlSection" EventName="SelectedIndexChanged" />

        </Triggers>
    </asp:UpdatePanel>--%>

    <div class=" col-xs-8 col-xs-offset-3 col-sm-5 col-sm-offset-4   col-md-5 col-md-offset-4  col-lg-6 col-lg-offset-4  ">
                    &nbsp;&nbsp;&nbsp;
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
                    <br />        
                </div>
                </div>
            </div>
        </div>
</asp:Content>
