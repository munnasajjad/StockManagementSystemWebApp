<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.StockInUI" %>


<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 210px;
    }
</style>
<!--[if lt IE 7 ]><html class="ie ie6" lang="en"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7" lang="en"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!-->
<html class="not-ie" lang="en">
<!--<![endif]-->
<!--
	ucorpora by freshdesignweb.com
	Twitter: https://twitter.com/freshdesignweb
	https://www.freshdesignweb.com/ucorpora/
-->
<head>
    <!-- Basic Meta Tags -->
    <meta charset="utf-8">
    <title>Stock Management System</title>
    <meta name="description" content="ucorpora demo - Free Business Corporate HTML Template">
    <meta name="keywords" content="ucorpora, ucorpora demo, free, template, corporate, clean, modern, bootstrap, creative, design">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!--[if (gte IE 9)|!(IE)]>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8">
  <![endif]-->

    <!-- Favicon -->
    <link href="img/stock.jpg" rel="icon" type="image/png">

    <!-- Styles -->
    <link href="css/styles.css" rel="stylesheet">
    <link href="css/bootstrap-override.css" rel="stylesheet">

    <!-- Font Avesome Styles -->
    <link href="css/font-awesome/font-awesome.css" rel="stylesheet">
    <!--[if IE 7]>
		<link href="css/font-awesome/font-awesome-ie7.min.css" rel="stylesheet">
	<![endif]-->

    <!-- FlexSlider Style -->
    <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen">

    <!-- Internet Explorer condition - HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
		<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->

</head>
<body>
    <!-- Header -->
    <header id="header">
        <div class="container">
            <div class="row t-container">

                <!-- Logo -->
                <div class="span3">
                    <div class="logo">
                        <a href="IndexUI.aspx">
                            <img src="img/stock.jpg" alt=""></a>
                    </div>
                </div>

                <div class="span9">
                    <div class="row space60"></div>
                    <nav id="nav" role="navigation">
                        <a href="#nav" title="Show navigation">Show navigation</a>
                        <a href="#" title="Hide navigation">Hide navigation</a>
                        <ul class="clearfix">
                            <li><a href="HomeUI.aspx" title="">Home</a></li>
                            <li><a href="SetupCategoryUI.aspx" title="">Category Setup</a></li>
                            <li><a href="SetupCompanyUI.aspx" title="">Company Setup</a></li>
                            <li><a href="ItemSetupUI.aspx" title="">Item Setup</a></li>
                            <li class="active"><a href="StockInUI.aspx" title="">Stock In</a></li>
                            <li><a href="StockOutUI.aspx" title="">Stock Out</a></li>
                            <li><a href="" title=""><span>Features</span></a>
                                <ul>
                                    <!-- Submenu -->
                                    <li><a href="SearchAndViewItemsSummary.aspx" title="">Search & View Items Summary</a></li>
                                    <li><a href="SearchBetweenDateUI.aspx" title="">Search Between Dates</a></li>
                                    <li><a href="IndexUI.aspx" title="">Logout</a></li>
                                </ul>
                                <!-- End Submenu -->
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
            <div class="row space40"></div>
            <div class="slider1 flexslider">
                <!-- Slider -->
                <ul class="slides">
                    <li>
                        <img src="img/slider/5.png" alt="">
                    </li>
                    <li>
                        <img src="img/slider/5.png" alt="">
                    </li>
                    <li>
                        <img src="img/slider/5.png" alt="">
                    </li>
                    <li>
                        <img src="img/slider/5.png" alt="">
                    </li>
                </ul>
            </div>
            <!-- Slider End -->
        </div>
    </header>
    <!-- Header End -->
    <!-- Content -->
    <div id="content">
        <div class="container">
            <div class="f-center">
                <h2>Stock In</h2>
                <div class="head-info">
                    <form id="form1" runat="server">
                        <br />
                        <table class="table" style="width: 61%; top: 4px; left: 68px;" align="center">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label1" runat="server" Text="Company:" Font-Names="Calisto MT" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="companyDropdownList" runat="server" Font-Names="Calisto MT" Font-Size="X-Large" Width="269px" AutoPostBack="True" OnSelectedIndexChanged="companyDropdownList_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label3" runat="server" Text="Item:" Font-Names="Calisto MT" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="itemDropdownList" runat="server" Font-Names="Calisto MT" Font-Size="X-Large" Width="269px" AutoPostBack="True" OnSelectedIndexChanged="itemDropdownList_SelectedIndexChanged"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label2" runat="server" Text="Reorder Level: " Font-Names="Calisto MT" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="reorderLevelTextBox" runat="server" Font-Names="Calisto MT" Font-Size="X-Large" Width="243px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label4" runat="server" Text="Available quantity: " Font-Names="Calisto MT" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="quantityTextBox" runat="server" Font-Names="Calisto MT" Font-Size="X-Large" Width="243px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label5" runat="server" Text="Stock in quantity: " Font-Names="Calisto MT" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="stockInTextBox" runat="server" Font-Names="Calisto MT" Font-Size="X-Large" Width="243px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center> <asp:Label ID="messageLabel" runat="server" Font-Names="Calisto MT" Font-Size="Large"></asp:Label></center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center><asp:Button ID="saveButton" runat="server" Text="Save" BackColor="#009999" BorderColor="#333300" BorderStyle="Groove" Font-Names="Footlight MT Light" Font-Size="X-Large" ForeColor="White" Font-Bold="True" Height="55px" Width="115px" OnClick="saveButton_OnClick" BorderWidth="2px" /></center>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </form>

                </div>
            </div>
            <div class="f-hr"></div>
            <div class="row space40"></div>
            <div class="row">
                <div class="span12">
                    <div class="row">
                        <!-- Service Container -->
                        <!-- Service Container End -->
                    </div>
                </div>

                <div class="span8">
                    &nbsp;
                </div>
                <div class="span4">
                    <div class="ic-1"></div>
                    <div class="title-1">
       <h4>Project Features :</h4>
                    </div>
                    <!-- List -->
                    <div class="text-1">
                        <ul class="list-b">
                            <!-- List Items -->
                            <li><i class="icon-ok"></i>Setup company.</li>
                            <li><i class="icon-ok"></i>Setup category.</li>
                            <li><i class="icon-ok"></i>Setup an item belongs to one company.</li>
                            <li><i class="icon-ok"></i>Stock In product with a specific quantity.</li>
                            <li><i class="icon-ok"></i>Stock Out product based on available quantity.</li>
                            <li><i class="icon-ok"></i>View items summary.</li>
                            <li><i class="icon-ok"></i>Search sell items between a date range.</li>
                        </ul>
                    </div>
                    <!-- List End -->
                </div>

            </div>

            <div class="space40"></div>

            <!-- Our Clients -->
            <div class="row">
                <div class="span12">
                    <h3>Our Clients</h3>
                </div>
            </div>

            <div id="our-clients" class="slider2 flexslider">
                <ul class="slides">
                    <li>
                        <div class="row">
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/1.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/2.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/3.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/4.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/5.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/6.png" alt="">
                                </a>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="row">
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/4.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/3.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/1.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/2.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/5.png" alt="">
                                </a>
                            </div>
                            <div class="span2">
                                <a href="#" rel="external">
                                    <img src="img/our-clients/6.png" alt="">
                                </a>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <!-- Our Clients End -->

            <div class="space50"></div>

        </div>
    </div>
    <!-- Content End -->

    <!-- Footer -->
    <footer id="footer">
        <div class="container">
            <div class="row">
                <div class="span5">
               
                </div>
                <div class="span3 offset3">
                    <h3>Address</h3>
                    BITM(Basis Intitute of Technology & Management)<br>
                    R A Tower<br>
                    Besides Evergreen Hospital<br>
                    Golpahar circle<br>
                    Chattogram
                    <br>
                    <i class="icon-phone"></i>+01 833 482154<br>
                    <i class="icon-envelope"></i><a href="">munnasajjad@yahoo.com</a><br>
                    <i class="icon-home"></i><a href="#">www.example.com</a>

                    <div class="row space40"></div>

                    <a href="#" class="social-network sn2 behance"></a>
                    <a href="#" class="social-network sn2 facebook"></a>
                    <a href="#" class="social-network sn2 pinterest"></a>
                    <a href="#" class="social-network sn2 flickr"></a>
                    <a href="#" class="social-network sn2 dribbble"></a>
                    <a href="#" class="social-network sn2 lastfm"></a>
                    <a href="#" class="social-network sn2 forrst"></a>
                    <a href="#" class="social-network sn2 xing"></a>
                </div>
            </div>

            <div class="row space50"></div>
            <div class="row">
                <div class="span6">
                    <div class="logo-footer">
                        Designed by <a href="">Shinning Star</a>
                    </div>
                </div>
                <div class="span6 right">
                    &copy; 2019. All rights reserved.
                </div>
            </div>

        </div>
    </footer>
    <!-- Footer End -->

    <!-- JavaScripts -->
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/functions.js"></script>
    <script type="text/javascript" defer src="js/jquery.flexslider.js"></script>

</body>
</html>
