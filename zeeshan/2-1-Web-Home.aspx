<%@ Page Title="" Language="C#" MasterPageFile="~/My Master Page.Master" AutoEventWireup="true" CodeBehind="2-1-Web-Home.aspx.cs" Inherits="Future.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>

        $(document).ready(function () {

            $("#owl-demo").owlCarousel({

                navigation: false, // Show next and prev buttons
                autoPlay: 3000,
                stopOnHover: true,

                paginationSpeed: 1000,
                goToFirstSpeed: 2000,


                singleItem: true

                // "singleItem:true" is a shortcut for:
                // items : 1, 
                // itemsDesktop : false,
                // itemsDesktopSmall : false,
                // itemsTablet: false,
                // itemsMobile : false

            });
            
            //var abc = $('#nav_bar_aexxx').width();
            //alert(abc);

        });

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



       <%--Owl Crousel--%>
    

        <div class="col-xs-12 crosel crosellg  col-sm-8   col-md-7 col-md-offset-1">
            <div id="owl-demo" class="owl-carousel owl-theme">

                <div class="item">
                    <img src="Images/Capture.PNG" class="imagestyle" />
                </div>
                <div class="item">
                    <img src="Images/big_img7.jpg" class="imagestyle" />
                </div>

                <div class="item">
                    <img src="Images/lower_school_library_body_image.jpg" class="imagestyle" />
                </div>

                <div class="item">
                    <img src="Images/DSC_5005.JPG" class="imagestyle" />
                </div>


                <div class="item">
                    <img src="Images/career-coaching-slider.jpg" class="imagestyle" />
                </div>
                <div class="item">
                    <img src="Images/labb.jpg" class="imagestyle" />
                </div>
            </div>

        </div>



        <%--End Owl Crousel--%>

        <div class="clearfix visible-xs"></div>

        <%--Panel 1--%>

        <div class="col-xs-10 xs_margin  col-sm-4   col-md-3 panel1" >
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title text-center">News and Events</h3>
                </div>
                <div class="panel-body" style="height: 360px;">
<marquee direction="up" behaviour="scroll" scrollamount=4 style="height: 340px;" onmouseover="this.setAttribute('scrollamount', 0, 0);" onmouseout="this.setAttribute('scrollamount', 6, 0);">
    
    <p class="text-info text-center">Admision Open</p>
    <br />
    <br />
    <br />

    <p class="text-danger text-center">Last Date of Submission of form is 02/12/2014</p>
     <br />
    <br />
    <br />

     <p class="text-primary text-center">Download Admission form</p>


     <br />
    <br />
    <br />


     <p class="text-info text-center">Admision Open</p>
    <br />
    <br />
    <br />

    <p class="text-danger text-center">Last Date of Submission of form is 02/12/2014</p>
     <br />
    <br />
    <br />

     <p class="text-primary text-center">Download Admission form</p>


</marquee>

                 
                
                </div>
            </div>


        </div>

        <%--End Panel 1--%>

       
         <%--Panel 2--%>
        <div class="col-xs-10 xs_margin col-sm-12 col-md-10  col-md-offset-1 panel2lg" ">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h2 class="panel-title text-center">Welcome To Zamp Tech</h2>
                </div>
                <div class="panel-body" >

    

                   <%-- Picture 1--%>
                   <div  class="col-xs-12 col-sm-4 col-md-4 col-lg-4  adjustment" style="text-align:center; padding:0px!important;">
<img class="img-thumbnail" alt="Muhammad Abdullah" src="profile_pic/a%20(23).JPG" style="height:140px; width:180px;"/>
<br/>
                       
<p>
<strong>    Director General</strong>
<br/>
Dr.Salman Rizvi
<a class="scroll" style="color:#06F !important" onclick="founder1()" href="#founder1Profile">
<br/>

</a>
</p>
</div>
   
     
                    <%-- Picture 2--%>
                   <div  class="col-xs-12 col-sm-4 col-md-4 col-lg-4  adjustment" style="text-align:center; padding:0px!important;">
<img class="img-thumbnail" alt="Muhammad Abdullah" src="profile_pic/a%20(1).JPG" style="height:140px; width:180px;"/>
<br/>
<p>
<strong>    HOD of IT Deptt.</strong>
<br/>
Dr.Salman Naseer
<a class="scroll" style="color:#06F !important" onclick="founder1()" href="#founder1Profile">
<br/>

</a>
</p>
</div>
                    
                    
                    <%-- Picture 3--%>
                    <div  class="col-xs-12 col-sm-4 col-md-4 col-lg-4  adjustment" style="text-align:center; padding:0px!important;">
<img class="img-thumbnail" alt="Muhammad Abdullah" src="profile_pic/a%20(2).JPG" style="height:140px; width:180px;"/>
<br/>
<p>
<strong>    Associate Professor</strong>
<br/>
Dr.Muhammad Younas
<a class="scroll" style="color:#06F !important" onclick="founder1()" href="#founder1Profile">
<br/>

</a>
</p>
</div>                
                    

   
      
   
  </div><%--panel Body End--%>

</div>
                
    </div>

         <%--End Panel 2--%>







</asp:Content>
