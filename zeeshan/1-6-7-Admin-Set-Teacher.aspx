<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-6-7-Admin-Set-Teacher.aspx.cs" Inherits="zeeshan.SetTeacher" %>

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

            .margin {
                margin-left: 100px;
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

            .margin {
                margin-left: 200px;
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



    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">

        <h3 class="text-info">Set Class Teacher</h3>
    </div>
    <br />
    <br />


    <%--Grid Two--%>
    <div class="col-xs-12 col-sm-10 col-sm-offset-1 col-md-7 col-md-offset-5 col-lg-6 col-lg-offset-2 table-responsive">

        <asp:GridView ID="dgv" runat="server" CssClass="margin" OnRowDataBound="dgv_RowDataBound" AutoGenerateColumns="false" OnRowEditing="dgv_RowEditing" OnRowCancelingEdit="dgv_RowCancelingEdit" OnRowUpdating="dgv_RowUpdating">
            <Columns>
                <%--Sr No--%>
                <asp:TemplateField>
                    <HeaderTemplate>Sr</HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lbl2" ControlStyle-CssClass="btn btn-primary btn-xs" Text='<% #bind("classId")%>' runat="server"></asp:Label>
                    </ItemTemplate>


                </asp:TemplateField>
                <%-- End Sr No--%>


                <%--Subject--%>
                <asp:TemplateField>
                    <HeaderTemplate>Class</HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lbl1" Text='<% #bind("className")%>' runat="server"></asp:Label>
                    </ItemTemplate>


                </asp:TemplateField>
                <%-- End Subject--%>

                <%--Instructor--%>

                <asp:TemplateField>
                    <HeaderTemplate>Teacher</HeaderTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEditTeacherName" runat="server">
                        </asp:DropDownList>

                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="lbl" Text='<% #bind("Name")%>' runat="server"></asp:Label>
                        <%--<asp:HiddenField ID="hiddenId" runat="server"  Value='<% #Eval("StaffId")%>' />--%>


                    </ItemTemplate>


                </asp:TemplateField>

                
               
                <asp:CommandField HeaderText="Edit_Records  " ControlStyle-CssClass="btn btn-primary btn-xs Editbtn" ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs Editbtn" />
                </asp:CommandField>
                <%-- End Instructor--%>
            </Columns>
            <RowStyle CssClass="RowStyle" ForeColor="#000066" />
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <HeaderStyle CssClass="HeaderStyle" BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <EditRowStyle CssClass="EditRowStyle" />
            <AlternatingRowStyle CssClass="AltRowStyle" />

        </asp:GridView>

        <br />


    </div>

    <%--End Grid Two--%>
    <br />
    <br />
    <div class=" col-xs-6 col-xs-offset-4 col-sm-3 col-sm-offset-5   col-md-3 col-md-offset-4  col-lg-4 col-lg-offset-5  ">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="z" OnClick="btnSave_Click" CssClass="btn btn-primary btnlg" />
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  CssClass="btn btn-primary btnlg"/>
        <br />
        <br />
    </div>









</asp:Content>

