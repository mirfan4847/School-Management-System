﻿<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="Report-Sudent-Leaving.aspx.cs" Inherits="zeeshan.Reports.rdlc.Report_Sudent_Leaving" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-11 col-md-offset-1 col-lg-11 col-lg-offset-1">
   
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Width="815" Height="800" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reports.rdlc\Leaving-Certificate.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
         </div>
</asp:Content>
