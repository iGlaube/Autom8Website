<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE_TeamZephyr.WebPages.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8">

    <div id="fadeIn" class="alignCenter">
        <img class="first-slide" src="<%=Page.ResolveUrl("~/Content/Images/Generic%20Images/Autom8Logo.png")%>" alt="Autom8 Logo" height="104" width="136" />
        <h1>The Faster, Cheaper and Cleaner way to travel! </h1>
    </div>

    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="../../assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="../Content/PageSpecificStyles/AccordionStyle.css" rel="stylesheet" />
    <script src="../Scripts/AccordionScript/AccordionScript.js"></script>


    <link href="carousel.css" rel="stylesheet">
    <link href="../../dist/css/bootstrap.min.css" rel="stylesheet">
   
     <!-- =======================
        Carousel
         ======================= -->
    
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
      </ol>
      <div class="carousel-inner" role="listbox">
        <div class="item active">
          
      
          <img class="first-slide" src="../Content/Images/SplashView/tiltShift-carpool1.jpg" alt="First slide">
          <div class="container">
            <div class="carousel-caption">
              <h1>Sign Up Today</h1>
                    <p><strong>Personalised to your needs - Click below to create an account for yourself or your business and learn more about what Autom8 can do for you.</strong></p>
            </div>
          </div>
        </div>


            <div class="item">
            <img class="second-slide" src="../Content/Images/SplashView/tiltshift-Carpooling-%20business.jpg" alt="Second slide"/>
          <div class="container">
            <div class="carousel-caption">
              <h1>Connect your Business</h1>
                    <p>Save on employee parking and help them network</p>
                    <strong><a href="Account/Register.aspx">Register Here!</a></strong>
            </div>
          </div>
        </div>
        <div class="item">
          <img class="third-slide" src="../Content/Images/SplashView/tiltShift-Belfast1.jpg" alt="Third slide">
          <div class="container">
            <div class="carousel-caption">
              <h1>Reduce your Carbon Footprint</h1>
                    <p><strong>With Autom8, tracking your environmental influence is now easier. Click below to learn more about how Autom8 can help you protect the environment.</strong></p>
            </div>
          </div>
        </div>
      </div>
      <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div><!-- /.carousel -->
    
    <br />
    <hr />
    <br />
    <!-- Marketing messaging and featurettes
    ================================================== -->
    <!-- Wrap the rest of the page in another container to center all the content. -->
       
    <div class="container marketing">

        <!-- Three columns of text below the carousel -->
        <div class="row" >
            <div align="center">
            <div class="col-lg-4" >
                <img class="img-circle" src="../Content/Images/Generic%20Images/soloDriver.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 style="color: orange">For Individuals</h2>
                <p>Organise a one off or regular carpooling commute with other Autom8 car-riders</p>
                <p><a class="btn btn-default" href="/Webpages/Universal/About.aspx"role="button">View details &raquo;</a></p>
                
            </div><!-- /.col-lg-4 -->
                </div>
            <div class="col-lg-4">
                <div align="center">
                <img class="img-circle" src="https://static.wixstatic.com/media/f02240_f4028f43260d450cb530c1f6134d0689~mv2_d_3333_2363_s_2.jpg" alt="../Content/Images/Generic%20Images/carpoolGroup2.jpg" width="140" height="140">
                <h2 style="color: orange">For Business</h2>
                <p>Carpooling for any size of business, tailored to your needs - help facilitate commutes to work and track your companies environmental impact with our stat feedback.</p>
                <p><a class="btn btn-default" href="/Webpages/Universal/About.aspx" role="button">View details &raquo;</a></p>
            </div><!-- /.col-lg-4 -->
                </div>
            <div class="col-lg-4">
                <div align="center">
                <img class="img-circle" src="../Content/Images/Generic%20Images/futureReleases.jpg" alt="Generic placeholder image" width="140" height="140">
                <h2 style="color: orange">Future Releases</h2>
                <p>Stay tuned here to follow future plans and updates that Autom8 has for all of it's riders and customers</p>
                <p><a class="btn btn-default" href="/Webpages/Universal/About.aspx"  role="button">View details &raquo;</a></p>
            </div><!-- /.col-lg-4 -->
        </div><!-- /.row -->
        </div>
        <!-- START THE FEATURETTES -->
        <hr class="featurette-divider">

        <div class="row featurette">
            <div class="col-md-7">
                <h2 style="color: orange" class="featurette-heading">Multi-Platform. <span class="text-muted"></span></h2>
                <p class="lead">Never be without a ride again. Autom8 is available on your PC, Tablet or Phone. Just click and ride with our easy to use platform.</p>
            </div>
            <div class="col-md-5">
                <img class="featurette-image img-responsive center-block" src="../Content/Images/SplashView/multiplatform.png" alt="Generic placeholder image" width="200" height="200">
            </div>
        </div>

        <hr class="featurette-divider">

        <div class="row featurette">
            <div class="col-md-7 col-md-push-5">
                <h2 style="color: orange" class="featurette-heading">Read our Reviews <span class="text-muted"></span></h2>
                <p class="lead">"Autom8 has helped me match with carpooling partners, share stories and music while we travel" - Sarah</p>
                <p class="lead">"I haven't used your site" - Developers Friend</p>
                <p class="lead">"Using Autom8 has saved me money and made for a more relaxing travel to work and about town, it's just great!" - Michael</p>
            </div>
            <div class="col-md-5 col-md-pull-7">
                <img class="featurette-image img-responsive center-block" src="https://img.clipartfest.com/7ecdb319fdc7f79129862e81626018b2_big-image-png-thumbs-up-down-clipart_2400-1728.png" alt="../Content/Images/SplashView/review.png" width="240" height="240">
            </div>
        </div>

    </div><!-- /.container -->



    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
</asp:Content>
