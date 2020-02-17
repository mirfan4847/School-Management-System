<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-7-7-Admin-Exam-Set-Grades.aspx.cs" Inherits="zeeshan._1_7_7_Admin_Exam_Set_Grades" %>
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
        .Addbtn {
            width: 50px; margin-left:10%;
        }


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


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Set Grades For All Class</h3>
    </div>
    <br />
    <br />
   

    
    <div class="clearfix"></div>

   


     
    <br />
    <br />

    
        <%--<ContentTemplate>--%>
           
             <%--Grid View Start--%>
    <div class="col-xs-12 col-sm-11 col-sm-offset-1 col-md-9 col-lg-9 col-md-offset-3 col-lg-offset-3 table-responsive">
        
                <asp:GridView ID="dgvSetGrades" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="Cancel_Editing"  OnRowEditing="Edit_Row" OnRowUpdating="Update_Row"  >
                    <Columns>
                        <%--Sr No--%>
                        <asp:TemplateField>
                            <HeaderTemplate>Sr</HeaderTemplate>
                            
                            <ItemTemplate>

                                <asp:Label ID="lblSerial" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("Sr")%>' runat="server"></asp:Label>
                                <asp:HiddenField ID="hiddenId" runat="server" Value='<% #Eval("Id") %>' />
                            </ItemTemplate>
                           


                        </asp:TemplateField>
                        <%-- End Sr No--%>

                         <%--Start of Set Grades--%>

                        <asp:TemplateField>
                            <HeaderTemplate>Set Grades</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSetGrades" runat="server" Text='<% #bind("GradeName") %>'>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditSetGrades" runat="server" CssClass="TextBox"></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>
                        <%--End of Set Grades--%>

                        <%--Start of Pecentage--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Percentage</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPercentage" runat="server" Text='<% #bind("Percentage") %>'>'></asp:Label>

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPercentage" runat="server" CssClass="TextBox"></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>

                        <%--End of Percentage--%>
                        
                         <%--Start of Status--%>
                         <asp:TemplateField>
                            <HeaderTemplate>Status</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<% #bind("Status") %>'>'></asp:Label>

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditStatus" runat="server" CssClass="TextBox"></asp:TextBox>
                            </EditItemTemplate>
                            
                        </asp:TemplateField>

                        <%--End of Status--%>

                       

                        

                        <asp:CommandField HeaderText="Edit-Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">



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

       

   <div class=" col-xs-8 col-xs-offset-3 col-sm-5 col-sm-offset-4   col-md-5 col-md-offset-4  col-lg-6 col-lg-offset-4  ">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btnlg" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary btnlg" OnClick="btnPrint_Click" />
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
