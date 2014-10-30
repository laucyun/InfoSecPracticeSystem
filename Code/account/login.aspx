<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="account_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎登录！- 信息安全竞赛练习系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="../images/logo.png"  itemprop="image" />
    <link rel="shortcut icon" href="../images/logo.png"  type="image/x-icon" />
    <link rel="Stylesheet" type="text/css" href="../css/account/login.css" />
    <script language="javascript" type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <script language="javascript" type="text/javascript" src="../js/popwin.js"></script>
    <script language="javascript" type="text/javascript">
        window.onload = function ()
        {
            document.getElementById("<%#loginFocus%>").focus();
        }
        function popRegister()
        {
            registersamll.showWin("522", "482", "创建一个新帐号！", "<%#domain%>/account/register.aspx");
        }
    </script>
</head>
<body>
    <div id="main">
        <div id="login">
            <div class="login-inner">
                <form id="accountLogin" method="post" action="../account/login.aspx">
                <input id="username" name="username" type="text" maxlength="20" value="<%#loginUname%>"
                    placeholder="用户名" class="<%#loginUnameStyle%>" />
                <input id="userpwd" name="userpwd" type="password" maxlength="30" value="<%#loginUpwd%>"
                    placeholder="密码" style="margin-left: 10px;" class="<%#loginUpwdStyle%>" />
                <input id="loginBtn" class="formSubmit" type="submit" value="登&nbsp;&nbsp;录" />
                <div id="login-help">
                    <input id="isRemember" name="isRemember" type="checkbox" checked="checked" value="yes" <%#uisRemember%>/>
                    <span>&nbsp;5天内免登录</span>
                    <a href="javascript:;" onclick="popRegister();"target="_parent" title="注册新帐号">注册新帐号</a> 
                    <span style="color: #d20c12; float: right;"><%#loginErrorMsg%></span>
                </div>
                <input type="hidden" value="yes" name="isSign" />
                </form>
            </div>
        </div>
        <div id="foot">
            Copyright &copy; <%#Year%> <a href="<%#domain%>" target="_blank">信息安全竞赛练习系统.</a> All Rights Reserved.
        </div>
    </div>
</body>
</html>
