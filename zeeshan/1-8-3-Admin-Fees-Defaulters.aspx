<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-8-3-Admin-Fees-Defaulters.aspx.cs" Inherits="Future._1_8_3_Admin_Fees_Defaulters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        @media screen and (max-width:360px) {


            .btnlg {
                margin-top: 10%;
                margin-left:55%;
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

    <script>

        setTimeout(function () {
            $("#RecordNotFound").hide();
        }, 4000);


    </script>

 

<%--      <script type="text/javascript">
          $(function () {
             

              $('#RecordNotFound').modal(options);

              var options = {
                  "backdrop": "true",
                  "keyboard":"true"
                  
              }


          });
           </script>--%>
   <%-- <script>

        $('#RecordNotFound').on('hidden.bs.modal', function () {
            window.alert('hidden event fired!');
        })
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="content ">
        <ul id="tabs" class="nav nav-pills red" data-tabs="tabs">
            <li class="active "><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=1">January</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=2">February</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=3">March</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=4">April</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=5">May</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=6 ">June</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=7">July</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=8">August</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=9">September</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=10">October</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=11">November</a></li>
            <li><a class="btn btn-primary btn-xs" href="1-8-3-Admin-Fees-Defaulters.aspx?m=12">December</a></li>
        </ul>
        <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active">

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






                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

                    <h3 class="text-info">Fees Defaulters</h3>
                </div>

                <br />
                <br />
                <br />

                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">

                    <h3 class="text-info">
                        <asp:Label ID="lblMonth" runat="server" Text=""></asp:Label>

                    </h3>
                </div>
                <br />
                <br />
                <br />
                <br />


                <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">

                    <div class="form-group">
                        <label>Select Class</label>

                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem>Choose</asp:ListItem>



                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="Choose" runat="server" ErrorMessage="Choose Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class=" col-xs-6 col-sm-4 col-md-4 col-lg-4">

                    <div class="form-group">
                        <label>Select Section</label>

                        <asp:DropDownList ID="ddlSection" runat="server" AppendDataBoundItems="true" ValidationGroup="p" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem>Choose</asp:ListItem>

                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="Choose" ValidationGroup="p" runat="server" ErrorMessage="Choose Section" ForeColor="Red" ControlToValidate="ddlSection"></asp:RequiredFieldValidator>

                    </div>

                </div>

                <div class=" col-xs-6  col-sm-3 col-sm-offset-1  text-left   col-md-3 col-md-offset-1  col-lg-3 col-lg-offset-1  ">
                    <asp:Button ID="btnAllDefaulters" runat="server" Text="All Defaulter" ValidationGroup="" OnClick="btnAllDefaulters_Click" CssClass="btn btn-primary btnlg" />

                </div>




                <div class="clearfix"></div>

                <%-- Grid View Div--%>

                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8 col-lg-offset-2 table-responsive">

                    <%-- Grid View Start--%>

                    <asp:GridView ID="dgvFee" runat="server" AutoGenerateColumns="False" ShowHeader="true" OnRowCommand="dgvFee_RowCommand" ShowHeaderWhenEmpty="True">
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

                            <%--Fee-Month--%>

                            <asp:TemplateField>
                                <HeaderTemplate>Fee-Month</HeaderTemplate>
                                <%-- <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth" CssClass="TextBox" runat="server"></asp:TextBox>

                                        </EditItemTemplate>--%>

                                <ItemTemplate>
                                    <asp:Label ID="lblMonth" Text='<% #bind("Fee_Month")%>' runat="server"></asp:Label>


                                </ItemTemplate>


                            </asp:TemplateField>



                            <%--End Fee-Month--%>
                            <%--Fees--%>


                            <asp:TemplateField>
                                <HeaderTemplate>Fees</HeaderTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFees" CssClass="TextBox" runat="server"></asp:TextBox>

                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Label ID="lblFees" Text='<% #bind("Fee_Status")%>' runat="server"></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>


                            <%--End Fees--%>
                            <asp:TemplateField>

                                <HeaderTemplate>Email</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnGridViewEmail" runat="server" CssClass="btn btn-primary sm" CommandArgument='<% #bind("AdmissionId")%>' CommandName="dgvEmail" Text="Email" />
                                </ItemTemplate>

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
                <%-- End Grid View Div--%>
                <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="btn btn-primary btnlg" />

                    <asp:Button ID="btnEmail" runat="server" Text="Email To All" ValidationGroup=""  OnClick="btnEmail_Click" CssClass="btn btn-primary btnlg" />
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

            </div>


            <%--End January--%>
        </div>
        <%-- End Nav Content--%>
    </div>
    <%-- Main For Tabs--%>
</asp:Content>
