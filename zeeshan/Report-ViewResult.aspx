﻿<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="Report-ViewResult.aspx.cs" Inherits="zeeshan.Report_ViewResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
         function prints() {
             $("#content").printArea();

         }
   </script>

      <style type="text/css">
        @media screen and (max-width:360px) {


            .btnlg {
                margin-top: 34%;
            }
        }



        @media screen and (min-width:768px) {
            .btnlg {
                margin-top: 24%;
            }
        }


        @media screen and (min-width:980px) {
            .btnlg {
                margin-top: 17%;
            }
            .margin{
                margin-left:100px;
            }
        }

        @media screen and (min-width:1280px) {
            .btnlg {
                width: 100px;
                height: 40px;
                margin-left: 15px;
                margin-top: 7%;
            }
        }



        @media screen and (min-width:1920px) {
            .btnlg {
                width: 150px;
                height: 40px;
                margin-left: 40px;
                margin-top: 5%;
            }
              .margin{
                margin-left:200px;
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



        /*End Grid view Designing*/





        /*End Grid*/
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="content">
    <div class="col-lg-1 col-md-2 col-sm-3 col-xs-12 text-center">
        
        <asp:Image ID="Logo" runat="server" ImageUrl="Logos/The_Fernwood_School_Logo.png" CssClass="setimage img-circle" Height="50" Width="50" />
    </div>
        <div class="col-lg-11 col-md-9 col-sm-7 col-xs-12">
             
            <h3 class="text-info" align="center">
                <asp:Label ID="Label1" runat="server" Text="Result of "></asp:Label>
                <asp:Label ID="lblHeader" runat="server" ></asp:Label>
                <asp:Label ID="lblTerm" runat="server" ></asp:Label>
                <asp:Label ID="lblSection" runat="server" ></asp:Label>
            </h3>
        </div>
        <div class="clearfix"></div>
    <div class="col-lg-9 col-md-9 col-sm-10 col-xs-12 col-lg-offset-0 col-md-offset-0 col-sm-offset-0" >
        <table>
            <tr>
                <td colspan="3" align="center">
                    
                    <asp:GridView ID="gvSetSubjects" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate><h5 >Sr</h5></HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Studentid") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate><h5>Name</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("StudentName") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate><h5>Sub1</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub1") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub2</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub2") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub3</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub3") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub4</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub4") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub5</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub5") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub6</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub6") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub7</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub7") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Sub8</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Sub8") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>ObtainedMarks</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("ObtainedMarks") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Total</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("TotalSubjectMarks") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            

                             <asp:TemplateField>
                                <HeaderTemplate><h5>Per_%</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Percentage") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Grade</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("Grade") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate><h5>Status</h5></HeaderTemplate>
                                <ItemTemplate>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text='<% #Bind("PromotedStatus") %>' ></asp:Label></h5>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </td>
            </tr>
           
                    
               
            
        </table>
       
    </div>
        </div>
     <div class=" col-xs-6  col-sm-6 col-sm-offset-4   col-md-4 col-md-offset-3  col-lg-4 col-lg-offset-3  ">
            
        
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
        </div>

</asp:Content>
