﻿<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-8-4-Admin-Print-Daily-Fees.aspx.cs" Inherits="zeeshan.Report_DailyFees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function prints() {
            $("#content").printArea();

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
                        <asp:Label ID="lblStudentIdNotFound" CssClass="text-danger" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
    <%--End Record Not Found--%>
    <div>
        <div id="content">
            <img src="Logos/The_Fernwood_School_Logo.png" height="50" width="50" alt="School Logo"  />

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Daily Fees Collection</h3>
    </div>

    <br />
    <br />
    <br />

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">

        <h3 class="text-info">
            <asp:Label ID="lblFormat" runat="server" Text="DD-MM-YYYY"></asp:Label>
            <br />

            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>

        </h3>
    </div>
    <br />
    <br />
    <br />
    <br />

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8 col-lg-offset-2 table-responsive">

        <%-- Grid View Start--%>

        <asp:GridView ID="dgvDailFee" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true" ShowHeaderWhenEmpty="True">
            <Columns>
                <%--Sr--%>
                <asp:TemplateField>
                    <HeaderTemplate>Sr.No.</HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblSr" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Sr")%>' runat="server"></asp:Label>
                    </ItemTemplate>


                </asp:TemplateField>
                <%-- End Sr--%>

                <%--Admission-ID--%>
                <asp:TemplateField>
                    <HeaderTemplate>Admission-ID</HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblstudentId" Text='<% #bind("studentId")%>' runat="server"></asp:Label>
                    </ItemTemplate>


                </asp:TemplateField>
                <%-- End Admission-ID--%>

                <%--Name--%>

                <asp:TemplateField>
                    <HeaderTemplate>Name</HeaderTemplate>


                    <ItemTemplate>
                        <asp:Label ID="lblName" Text='<% #bind("Name")%>' runat="server"></asp:Label>


                    </ItemTemplate>


                </asp:TemplateField>



                <%-- End Name--%>

                <%--Class--%>

                <asp:TemplateField>
                    <HeaderTemplate>Class</HeaderTemplate>


                    <ItemTemplate>
                        <asp:Label ID="lblClassName" CssClass="Label" Text='<% #bind("className")%>' runat="server"></asp:Label>


                    </ItemTemplate>


                </asp:TemplateField>



                <%-- End Class--%>


                <%--Section--%>
                <asp:TemplateField>
                    <HeaderTemplate>Section</HeaderTemplate>


                    <ItemTemplate>
                        <asp:Label ID="lblSection" Text='<% #bind("sectionName")%>' runat="server"></asp:Label>


                    </ItemTemplate>

                </asp:TemplateField>

                <%--End Section--%>

                <%--Paid_Date--%>

                <asp:TemplateField>
                    <HeaderTemplate>Paid_Date</HeaderTemplate>


                    <ItemTemplate>
                        <asp:Label ID="lblPaidDate" Text='<% #bind("Paid_Date")%>' runat="server"></asp:Label>


                    </ItemTemplate>

                    <FooterTemplate>
                        <h4>
                            <asp:Label ID="lblTotal" runat="server" ControlStyle-CssClass="text-right text-primary" Text="Total:"></asp:Label></h4>

                    </FooterTemplate>

                </asp:TemplateField>



                <%--End Paid_Date--%>
                <%--Balance--%>


                <asp:TemplateField>
                    <HeaderTemplate>Balance</HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lblBalance" Text='<% #bind("Balance")%>' runat="server"></asp:Label>


                    </ItemTemplate>
                    <FooterTemplate>
                       <h4> <asp:Label ID="lblAmount" runat="server" ControlStyle-CssClass="text-right text-primary" Text=""></asp:Label></h4>

                    </FooterTemplate>

                </asp:TemplateField>




            </Columns>
            <RowStyle CssClass="RowStyle" ForeColor="#000066" />
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <EditRowStyle CssClass="EditRowStyle" />
            <AlternatingRowStyle CssClass="AltRowStyle" />
        </asp:GridView>

        <%-- End Grid View--%>
    </div>
            </div>
    <%-- End Grid View Div--%>


        </div>
    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
        <input id="btnPrint" type="button" value="Print" onclick="prints()" class="btn btn-primary btnlg print" /> 
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
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>



</asp:Content>
