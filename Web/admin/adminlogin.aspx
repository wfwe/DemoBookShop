<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="BookShop.Web.admin.adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站后台登录</title>
   
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
   <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="assets/css/form-elements.css"/>
        <link rel="stylesheet" href="assets/css/style.css"/>

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"/></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets/ico/favicon.png">
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>
</head>
<body style="background-color: silver">


    <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>书店管理</strong> 登录页面</h1>
                            <div class="description">
                            	<p>
	                            	仅内部管理人员登录！ 
                            	</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>登录管理页面</h3>
                            		<p>输入您的用户名和密码：</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-lock"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form form id="form1" runat="server" class="login-form">
			                    	<div class="form-group">
			                    		<label class="sr-only" for="form-username">Username</label>
                                         <asp:TextBox runat="server" ID="txtLoginId" Cssclass="form-username form-control"  placeholder="用户名："></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="用户名必须填写">用户名必须填写！</asp:RequiredFieldValidator>
			                        	
			                        </div>
			                        <div class="form-group">
			                        	<label class="sr-only" for="form-password">Password</label>
                                        <asp:TextBox runat="server" ID="txtLoginPwd" TextMode="Password" Cssclass="form-password form-control"  placeholder="密码："></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtLoginPwd" Display="Dynamic" ErrorMessage="请输入密码！" 
            SetFocusOnError="True">密码必须填写！</asp:RequiredFieldValidator>
			                        	
			                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" />
			                        	
			                        </div>
			                        
                                    <asp:Button ID="Button1" runat="server" Text="登录" CssClass="btn btn-primary btn-lg  btn-block"  OnClick="Button1_Click"/>
			                    </form>
		                    </div>
                        </div>
                    </div>
                    
                </div>
            </div>
            
        </div>


        <!-- Javascript -->
        <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->


   
</body>
</html>
