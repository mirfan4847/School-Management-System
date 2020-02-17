<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-5-Web-Law.aspx.cs" Inherits="Future.law" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .width {
            width:100%;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12" style=" border-top: 2px solid #000000">
    <div class="text-capitalize text-center"><h1>DEPARMENT OF LAW <img src="Logos/Lawdept.jpg"" height="50" width="50" class="img-rounded" /></h1>
        </div>
            </div>
        <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12 text-center">
            <h3>Admission Criteria of LAW</h3>
        </div>
        <div class=" col-lg-12 col-md-12 col-xs-12 col-sm-12 text-center" >
            At leaset 50% marks in ICS/FSC. Pre Engineering/ Pre Medical with addtional math/A-Level with math or 
            equilent qualification. Or at least 60% marks in DAE in a relevant discipline.
        </div>

         <%--Panel first Start --%>
        <div class="width col-lg-12 col-md-12 col-sm-12 col-xs-12">
           <div class="panel panel-primary" style="margin-top:20px;">
               <div class="panel-heading">
                   <h1 class="panel-title text-center">Courses Offered in LAW</h1>
                   </div>
                   <div class="panel-body">

                       <%--Portion first Start --%>
                       <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 text-left ">
                           <h4>1st Year</h4>
                           <h5 class="text text-center">Subjects:</h5>
                               <ul>
                                    <li>Introduction To Computing</li>
                                    <li>Calculus I</li>
                                    <li>Mecanics ans Wave Motion</li>
                                    <li>Writing Workshop</li>
                                    <li>Islamic Studies I</li>
                               </ul>
                       </div>
                       <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 text-left">
                           <h4 >2nd Year</h4>
                           <h5 class="text text-center">Subjects:</h5>
                               <ul >
                                    <li>Introduction To Computing</li>
                                    <li>Calculus I</li>
                                    <li>Mecanics ans Wave Motion</li>
                                    <li>Writing Workshop</li>
                                    <li>Islamic Studies I</li>
                                 </ul>
                       </div>
                       <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 text-left">
                           <h4>3rd Year</h4>
                           <h5 class="text text-center">Subjects:</h5>
                               <ul >
                                    <li>Introduction To Computing</li>
                                    <li>Calculus I</li>
                                    <li>Mecanics ans Wave Motion</li>
                                    <li>Writing Workshop</li>
                                    <li>Islamic Studies I</li>
                                 </ul>
                       </div>
                       
                       <%--Portion first End --%>

                      

                       
                   </div>
               </div>
           
        </div>
        <%--Panel first End --%>

</asp:Content>
