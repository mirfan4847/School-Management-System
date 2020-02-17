<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-5-3-Admin_Class-Time-Table-Student.aspx.cs" Inherits="zeeshan._1_5_3_Admin_Class_Time_Table_Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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



        /*End Grid view Designing*/





        /*End Grid*/
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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




    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Class Time Table</h3>
    </div>

    <br />
    <br />

    <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Class</label>

            <asp:DropDownList ID="ddlClass" runat="server" ValidationGroup="z" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose</asp:ListItem>

            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="Choose" runat="server" ErrorMessage="Choose Class" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>


        </div>
    </div>



    <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Section</label>

            <asp:DropDownList ID="ddlSection" runat="server" ValidationGroup="z" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem>Choose</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="Choose" runat="server" ErrorMessage="Choose Section" ForeColor="Red" ValidationGroup="z" ControlToValidate="ddlSection"></asp:RequiredFieldValidator>


        </div>
    </div>







    <div class=" col-xs-4  col-sm-3 col-sm-offset-1  text-right   col-md-3 col-md-offset-1  col-lg-3 col-lg-offset-1  ">
        <asp:Button ID="Print" runat="server" Text="Print" ValidationGroup="z" OnClick="Print_Click" CssClass="btn btn-primary btnlg" />

    </div>
    <div class="clearfix"></div>


    
    <br />
    <br />
    <br />
    
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
    

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-10 col-lg-offset-1 table-responsive">

                <asp:GridView ID="dgvClass" runat="server" OnRowDataBound="dgvClass_RowDataBound" AutoGenerateColumns="False"  OnRowEditing="dgvClass_RowEditing" OnRowCancelingEdit="dgvClass_RowCancelingEdit" OnRowUpdating="dgvClass_RowUpdating" ShowHeaderWhenEmpty="True">

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
                                   <asp:DropDownList ID="ddlEditPeriod1" AppendDataBoundItems="false" runat="server">
                                   </asp:DropDownList>
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
                                 <%--<asp:DropDownList ID="ddlEditPeriod2" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                                <%-- <asp:DropDownList ID="ddlEditPeriod3" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                              <%--  <asp:DropDownList ID="ddlEditPeriod4" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                               <%--<asp:DropDownList ID="ddlEditPeriod5" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                                <%-- <asp:DropDownList ID="ddlEditPeriod6" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                               <%-- <asp:DropDownList ID="ddlEditPeriod7" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
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
                              <%--  <asp:DropDownList ID="ddlEditPeriod8" AppendDataBoundItems="true" runat="server">
                                   </asp:DropDownList>--%>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod8" Text='<% #bind("Lec8")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <asp:CommandField HeaderText="Edit-Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                        </asp:CommandField>



                      



                        <%-- End Period8--%>
                    </Columns>
                    <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>

            </div>


            <%--End Grid View--%>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSection" EventName="SelectedIndexChanged" />
        </Triggers>


    </asp:UpdatePanel>



    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

        <ContentTemplate>
            <div class="clearfix"></div>

            
    <br />
    <br />

            <%--End Grid one--%>


            <br />
            <br />


            <%--Grid Two--%>
          
            <%--End Grid Two--%>
            <br />
            <br />
           
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSection" EventName="SelectedIndexChanged" />
        </Triggers>


    </asp:UpdatePanel>
     <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="z" OnClick="btnSave_Click" CssClass="btn btn-primary btnlg" />
                <br />
                <br />
            </div>

    <%--End of Content--%>
</asp:Content>
