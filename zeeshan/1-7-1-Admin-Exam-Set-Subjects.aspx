<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-7-1-Admin-Exam-Set-Subjects.aspx.cs" Inherits="Future.Set_Grades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Set Subject of Class</h3>
    </div>
    <br />
    <br />
    <div class=" col-xs-8 col-sm-4 col-md-4 col-lg-4">

        <div class="form-group">
            <label>Search Class Wise</label>

            <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True" >
                <asp:ListItem>Choose Your Class</asp:ListItem>
                


            </asp:DropDownList>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Your Class" ForeColor="Red" InitialValue="Choose Your Class" ValidationGroup="vg" ControlToValidate="ddlClass"></asp:RequiredFieldValidator>


        </div>
    </div>

    <div class=" col-xs-4  col-sm-3 col-sm-offset-5  text-right   col-md-3 col-md-offset-5  col-lg-4 col-lg-offset-4  ">
        <asp:Button ID="Print" runat="server" Text="Print" CssClass="btn btn-primary btnlg" OnClick="Print_Click" />

    </div>
    <div class="clearfix"></div>

   


     
    <br />
    <br />

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
           
             <%--Grid View Start--%>
    <div class="col-xs-12 col-sm-11 col-sm-offset-1 col-md-9 col-lg-9 col-md-offset-3 col-lg-offset-3 table-responsive">
        
                <asp:GridView ID="dgvGradesAndSubjects"   runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowCancelingEdit="Cancel_Editing" OnRowDeleting="Delete_Row" OnRowEditing="Edit_Row" OnRowUpdating="Update_Row" >
                    <Columns>
                        <%--Sr No--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Sr</HeaderTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="lblSerial" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Sr")%>' runat="server" ></asp:Label>
                                <asp:HiddenField ID="hiddenId" runat="server" Value='<% #Eval("id") %>' />
                            </ItemTemplate>
                           


                        </asp:TemplateField>
                        <%-- End Sr No--%>

                          <%-- Start of Hidden Field Id--%>

                       <%-- <asp:TemplateField>

                            <ItemTemplate>
                                
                            </ItemTemplate>
                            
                        </asp:TemplateField>--%>

                        <%-- End of Hidden Field Id--%>


                        <%--Start of Subject--%>
                        <asp:TemplateField >
                            <HeaderTemplate>
                                Name
                                </HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditSubject" CssClass="TextBox" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSubject" Text='<% #bind("Name")%>' runat="server" CssClass="TextBox"></asp:Label>
                                <asp:HiddenField runat="server" Value="computer" />
                            </ItemTemplate>
                           <FooterTemplate>
                               <asp:TextBox ID="txtFooterSubjectName" runat="server" CssClass="TextBox form-control"></asp:TextBox>
                           </FooterTemplate>


                        </asp:TemplateField>

                        <%-- End of Subject--%>


                      

                        <%--Start of Subject Marks--%>

                        <asp:TemplateField>
                            <HeaderTemplate>Marks</HeaderTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditMarks" CssClass="TextBox" runat="server"></asp:TextBox>

                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblMarks" Text='<% #bind("SubjectMarks")%>' runat="server" CssClass="TextBox"></asp:Label>
                                <asp:HiddenField runat="server" Value="100" />

                            </ItemTemplate>
                           
                             <FooterTemplate>
                               <asp:TextBox ID="txtFooterSubjectMarks" runat="server" CssClass="TextBox form-control"></asp:TextBox>
                           </FooterTemplate>

                        </asp:TemplateField>

                        <%--End of Subject Marks--%>

                        <%--Start of Add Button--%>

                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="btnFooterAdd" runat="server" Text="Add" CssClass="btn btn-primary btn-sm " OnClick="btnFooterAdd_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <%--End of Add Button--%>

                       

                        

                        <asp:CommandField HeaderText="Edit-Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                        </asp:CommandField>



                        <asp:CommandField HeaderText="Delete" ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowDeleteButton="True" ButtonType="Button">



                            <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                        </asp:CommandField>



                        
                    </Columns>
                      <RowStyle CssClass="RowStyle" ForeColor="#000066" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />

                </asp:GridView>


             </div>

                <%--End Grid View--%>

        <%--</ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="ddlClass" EventName="SelectedIndexChanged" />

        </Triggers>
    </asp:UpdatePanel>--%>

    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btnlg" OnClick="btnSave_Click" ValidationGroup="vg" />
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
