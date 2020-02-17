<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-6-4-Admin-Staff_Time_Table.aspx.cs" Inherits="Future.Staff_Time_Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Teacher Time Table</h3>
    </div>

    <br />
    <br />

    <div class=" col-xs-8 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Search Name Wise</label>

            <asp:DropDownList ID="ddlTeacher" runat="server" ValidationGroup="z" CssClass="form-control">
                <asp:ListItem>Choose</asp:ListItem>
                <asp:ListItem>Play Group</asp:ListItem>
                <asp:ListItem>Nursery</asp:ListItem>
                <asp:ListItem>1st</asp:ListItem>
                <asp:ListItem>2nd</asp:ListItem>
                <asp:ListItem>3rd</asp:ListItem>
                <asp:ListItem>4th</asp:ListItem>
                <asp:ListItem>5th</asp:ListItem>
                <asp:ListItem>6th</asp:ListItem>
                <asp:ListItem>7th</asp:ListItem>
                <asp:ListItem>8th</asp:ListItem>
                <asp:ListItem>9th</asp:ListItem>
                <asp:ListItem>10th</asp:ListItem>


            </asp:DropDownList>


        </div>
    </div>

    <div class=" col-xs-4  col-sm-3 col-sm-offset-5  text-right   col-md-3 col-md-offset-5  col-lg-4 col-lg-offset-4  ">
        <asp:Button ID="Print" runat="server" Text="Print" ValidationGroup="z" OnClick="Print_Click" CssClass="btn btn-primary btnlg" />

    </div>
    <div class="clearfix"></div>

   


     
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-10 col-lg-offset-1 table-responsive">

                <asp:GridView ID="dgvTeacher" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvTeacher_RowDeleting" OnRowEditing="dgvTeacher_RowEditing" OnRowCancelingEdit="dgvTeacher_RowCancelingEdit" OnRowUpdating="dgvTeacher_RowUpdating">

                    <Columns>

                        <%--Class--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Sr.No.</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditTime" CssClass="TextBox" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClass" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Time")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Class--%>


                        <%--Period1--%>
                        <asp:TemplateField>
                            <HeaderTemplate>1</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod1" CssClass="TextBox" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPeriod1" Text='<% #bind("Period1")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Period1--%>

                        <%--Period2--%>

                        <asp:TemplateField>
                            <HeaderTemplate>2</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod2" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod2" Text='<% #bind("Period2")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period2--%>

                        <%--Period3--%>

                        <asp:TemplateField>
                            <HeaderTemplate>3</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod3" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod3" CssClass="Label" Text='<% #bind("Period3")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period3--%>

                        <%--Period4--%>

                        <asp:TemplateField>
                            <HeaderTemplate>4</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod4" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod4" Text='<% #bind("Period4")%>' runat="server"></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>



                        <%-- End Period4--%>

                        <%--Period5--%>

                        <asp:TemplateField>
                            <HeaderTemplate>5</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod5" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod5" Text='<% #bind("Period5")%>' runat="server"></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>



                        <%-- End Period5--%>

                        <%--Period6--%>

                        <asp:TemplateField>
                            <HeaderTemplate>6</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod6" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod6" Text='<% #bind("Period6")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period6--%>

                        <%--Period7--%>

                        <asp:TemplateField>
                            <HeaderTemplate>7</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod7" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod7" Text='<% #bind("Period7")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <%-- End Period7--%>

                        <%--Period8--%>

                        <asp:TemplateField>
                            <HeaderTemplate>8</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPeriod8" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblPeriod8" Text='<% #bind("Period8")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>



                        <asp:CommandField HeaderText="Edit-Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                        </asp:CommandField>



                        <asp:CommandField HeaderText="Delete" ControlStyle-CssClass="btn btn-primary btn-xs" ShowDeleteButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs" />
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
            <asp:AsyncPostBackTrigger ControlID="ddlTeacher" EventName="SelectedIndexChanged" />
        </Triggers>


    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

            <ContentTemplate>
                <div class="clearfix"></div>



                <%--End Grid one--%>


                <br />
                <br />
                

                <%--Grid Two--%>
    <div class="col-xs-12 col-sm-10 col-sm-offset-1 col-md-6 col-md-offset-4 col-lg-5 col-lg-offset-3 table-responsive">
        
                <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <%--Sr No--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Sr</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt2" CssClass="TextBox" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl2" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Sr")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Sr No--%>


                      

                        <%--Instructor--%>

                        <asp:TemplateField>
                            <HeaderTemplate>Teacher</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbl" Text='<% #bind("Instructor")%>' runat="server"></asp:Label>


                            </ItemTemplate>


                        </asp:TemplateField>




                          <%--Subject--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Class</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt1" CssClass="TextBox" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl1" Text='<% #bind("Class")%>' runat="server"></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <%-- End Subject--%>


                        <asp:CommandField HeaderText="Edit-Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                        </asp:CommandField>



                        <asp:CommandField HeaderText="Delete" ControlStyle-CssClass="btn btn-primary btn-xs" ShowDeleteButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs" />
                        </asp:CommandField>



                        <%-- End Instructor--%>
                    </Columns>
                      <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />

                </asp:GridView>


             </div>

                <%--End Grid Two--%>

                <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="z" OnClick="btnSave_Click" CssClass="btn btn-primary btnlg" />
                    <br />
                    <br />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlTeacher" EventName="SelectedIndexChanged" />
            </Triggers>


        </asp:UpdatePanel>






</asp:Content>
