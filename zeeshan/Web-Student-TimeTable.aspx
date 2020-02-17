<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="Web-Student-TimeTable.aspx.cs" Inherits="zeeshan.Web_Student_TimeTable" %>
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
    <div id="content">
 <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

                    <h3 class="text-info">Class Time Table</h3>
                </div>
                <br />
                <br />

                <br />

     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <h3>
                        <asp:Label ID="lblClass" runat="server"  CssClass="text-info "></asp:Label>
                        <asp:Label ID="lblSection" runat="server" Text="" CssClass="text-info text-left"></asp:Label></h3>
                </div>

          <div class="col-xs-12 col-sm-12 col-md-12 col-lg-10 col-lg-offset-1 table-responsive">

                <asp:GridView ID="dgvClass" runat="server"  AutoGenerateColumns="False"  >

                    <Columns>

                        <%--Class--%>
                       <asp:TemplateField>
                            <HeaderTemplate>Days</HeaderTemplate>
                          
                            <ItemTemplate>
                                <asp:Label ID="lblClass" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Days")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Class--%>


                        <%--Period1--%>
                        <asp:TemplateField>
                            <HeaderTemplate>1</HeaderTemplate>
                            <EditItemTemplate>
                                   <asp:TextBox ID="ddlEditPeriod1" CssClass="TextBox" Text='<% #bind("Lec1")%>' runat="server">
                                   </asp:TextBox>
                              </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPeriod1" Text='<% #bind("Lec1")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Period1--%>

                        <%--Period2--%>

                        <asp:TemplateField>
                            <HeaderTemplate>2</HeaderTemplate>
                            <EditItemTemplate>
                                 <asp:TextBox ID="ddlEditPeriod2"  CssClass="TextBox" Text='<% #bind("Lec2")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod2" Text='<% #bind("Lec2")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period2--%>

                        <%--Period3--%>

                        <asp:TemplateField>
                            <HeaderTemplate>3</HeaderTemplate>
                            <EditItemTemplate>
                             <asp:TextBox ID="ddlEditPeriod3"  CssClass="TextBox" Text='<% #bind("Lec3")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod3" CssClass="Label" Text='<% #bind("Lec3")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period3--%>

                        <%--Period4--%>

                        <asp:TemplateField>
                            <HeaderTemplate>4</HeaderTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="ddlEditPeriod4"  CssClass="TextBox" Text='<% #bind("Lec4")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod4" Text='<% #bind("Lec4")%>' runat="server"></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>



                        <%-- End Period4--%>

                        <%--Period5--%>

                        <asp:TemplateField>
                            <HeaderTemplate>5</HeaderTemplate>
                            <EditItemTemplate>
                             <asp:TextBox ID="ddlEditPeriod5"  CssClass="TextBox" Text='<% #bind("Lec5")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod5" Text='<% #bind("Lec5")%>' runat="server"></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>



                        <%-- End Period5--%>

                        <%--Period6--%>

                        <asp:TemplateField>
                            <HeaderTemplate>6</HeaderTemplate>
                            <EditItemTemplate>
                               <asp:TextBox ID="ddlEditPeriod6"  CssClass="TextBox" Text='<% #bind("Lec6")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod6" Text='<% #bind("Lec6")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period6--%>

                        <%--Period7--%>

                        <asp:TemplateField>
                            <HeaderTemplate>7</HeaderTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="ddlEditPeriod7"  CssClass="TextBox" Text='<% #bind("Lec7")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod7" Text='<% #bind("Lec7")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period7--%>

                        <%--Period8--%>

                        <asp:TemplateField>
                            <HeaderTemplate>8</HeaderTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="ddlEditPeriod8"  CssClass="TextBox" Text='<% #bind("Lec8")%>' runat="server">
                                   </asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod8" Text='<% #bind("Lec8")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>






                      



                        <%-- End Period8--%>
                    </Columns>
                    <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>

            </div>
</div>

     <div class=" col-xs-8 col-xs-offset-3 col-sm-5 col-sm-offset-4   col-md-5 col-md-offset-4  col-lg-6 col-lg-offset-4  ">
                   
         <input id="btnPrint" type="button" value="Print" onclick="prints()" class="btn btn-primary btnlg" />
                    
                    <br />
                    <br />
                    <br />
                    <br />

                </div>
</asp:Content>
