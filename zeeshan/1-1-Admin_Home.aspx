<%@ Page Title="" Language="C#" MasterPageFile="~/My Admin Master.Master" AutoEventWireup="true" CodeBehind="1-1-Admin_Home.aspx.cs" Inherits="Future.Admin_Home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function FeeDefaulters(textVal) {
           

            $('#feedefaulters').text("");
            $('#feedefaulters').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }


        function FailStudents(textVal) {


            $('#fStudents').text("");
            $('#fStudents').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }

       

        function SystemUsers(textVal) {


            $('#SystemUsers').text("");
            $('#SystemUsers').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }

      

       
        


        function SystemRoles(textVal) {
          

            $('#Roles').text("");
            $('#Roles').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }
        
        
        function TotalStudents(textVal) {
           

            $('#student').text("");
            $('#student').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }


        function TotalStaff(textVal) {


            $('#staff').text("");
            $('#staff').append('<h4><p class=" text-right " style="color:#ffffff;font-size:x-large;">' + textVal + '</p></h4>');

        }
    </script>
    
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Dashboard <small>School Management System</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-dashboard"></i>Dashboard
                </li>
            </ol>
        </div>
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-12">
            <div class="alert alert-info alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <i class="fa fa-info-circle"></i><strong>Get an overview whats going on in</strong>
            </div>
        </div>
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-comments fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="feedefaulters">
                                <%-- Code from behind page --%>

                              

                            </div>
                            <div>Fee Defaulters !</div>
                        </div>
                    </div>
                </div>
                <a href="1-8-3-Admin-Fees-Defaulters.aspx" target="_blank">
                    <div class="panel-footer">
                        <span class="pull-left">Send Emails</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-tasks fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="fStudents">

                                <%-- Code from behind page --%>


                            </div>
                            <div>Failed Students!</div>
                        </div>
                    </div>
                </div>
                <a href="1-7-6-Admin-Exam-Failed-Students.aspx" target="_blank">
                    <div class="panel-footer">
                        <span class="pull-left">Send Emails</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-shopping-cart fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="SystemUsers">
                                <%-- Code from behind page --%>


                            </div>
                            <div>System Users!</div>
                        </div>
                    </div>
                </div>
                <a href="1-8-8-Admin-Register-users.aspx" target="_blank">

                    <div class="panel-footer">
                        <span class="pull-left">Add/Delete System Users</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-support fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="Roles">

                                <%-- Code from behind page --%>



                            </div>
                            <div>Role Management</div>
                        </div>
                    </div>
                </div>
                <a href="1-8-7-Admin-Manage-users.aspx" target="_blank">
                    <div class="panel-footer">
                        <span class="pull-left">Add/Delete Roles</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
            <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-support fa-5x" ></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="student" >

                                <%-- Code from behind page --%>



                            </div>
                            <div>Students</div>
                        </div>
                    </div>
                </div>
                <a href="1-8-11-Admin-Total-Students.aspx" target="_blank">
                    <div class="panel-footer">
                        <span class="pull-left">See All Students!</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
         <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-support fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge" id="staff">

                                <%-- Code from behind page --%>



                            </div>
                            <div>School Staff!</div>
                        </div>
                    </div>
                </div>
                <a href="1-8-10-Admin-Total-Staff.aspx" target="_blank">
                    <div class="panel-footer">
                        <span class="pull-left">See All Staff</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
       
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o fa-fw"></i>Admission Charts</h3>
                </div>
                <div class="panel-body">

                    <%-- Colomn Chart 1 --%>

                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart1" runat="server" CssClass="img-responsive" Width="525px" Height="450px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="No of Students in a Class">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#446E9B" IsValueShownAsLabel="false"
                                    Name="No of Students in a Class" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 1 --%>

                    <%-- Colomn Chart 2 --%>
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart2" runat="server" CssClass="img-responsive" Width="525px" Height="450px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="Admission Capacity in Classes">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#D9534F" IsValueShownAsLabel="false"
                                    Name="New Admission Capacity" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 2 --%>
                </div>
            </div>

        </div>
    </div>
    <!-- /.row -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-long-arrow-right fa-fw"></i>Fees Charts</h3>
                </div>
                <div class="panel-body">
                    <%-- Colomn Chart 3 --%>
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart3" runat="server" CssClass="img-responsive" Width="525px" Height="450px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="Monthly Defaulters">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#446E9B" IsValueShownAsLabel="false"
                                    Name="Monthly Defaulters" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 3 --%>

                    <%-- Colomn Chart 4 --%>
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart4" runat="server" CssClass="img-responsive" Width="525px" Height="490px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="Yearly Defaulters">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#D9534F" IsValueShownAsLabel="false"
                                    Name="Yearly Defaulters" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 4 --%>
                </div>
            </div>
        </div>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-clock-o fa-fw"></i>Exam Charts</h3>
                </div>
                <div class="panel-body">
                    <%-- Colomn Chart 5 --%>

                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart5" runat="server" CssClass="img-responsive" Width="525px" Height="450px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="Passed Students">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#446E9B" IsValueShownAsLabel="false"
                                    Name="Passed Students" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 5 --%>


                    <%-- Colomn Chart 6 --%>
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-6">

                        <asp:Chart ID="Chart6" runat="server" CssClass="img-responsive" Width="525px" Height="490px" BorderWidth="2px">
                            <BorderSkin BorderWidth="1" BackColor="White"></BorderSkin>

                            <Titles>
                                <asp:Title
                                    Text="Failed Students">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series MarkerSize="3" Legend="Legend1" BorderWidth="1" Color="#D9534F" IsValueShownAsLabel="false"
                                    Name="Failed Students" MarkerStyle="Circle">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" BackColor="White" ShadowColor="">
                                    <AxisY LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisY>
                                    <AxisX LineWidth="2" Interval="1">
                                        <LabelStyle Font=" 8.25pt" />
                                        <MajorGrid LineColor="64, 220, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <%-- Colomn Chart 6 --%>
                </div>
            </div>
        </div>
      
    </div>
    <!-- /.row -->






</asp:Content>
