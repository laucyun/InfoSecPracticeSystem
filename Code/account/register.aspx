<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="account_register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>创建一个新帐号！- 信息安全竞赛练习系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="../images/logo.png"  itemprop="image" />
    <link rel="shortcut icon" href="../images/logo.png"  type="image/x-icon" />
    <link rel="Stylesheet" type="text/css" href="../css/account/register.css" />
    <script language="javascript" type="text/javascript" src="../js/ajax.js"></script>
    <script language="javascript" type="text/javascript" src="../js/common.js"></script>
    <script language="javascript" type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <script language="javascript" type="text/javascript" src="../js/register.js"></script>
    <script language="javascript" type="text/javascript">
        function changeImg()
        {
            document.getElementById("imgOK").src = "VerifyCode.ashx?active=" + new Date().getMilliseconds();
        }
        function CreateAccount()
        {
            document.getElementById("createAccountsFrom").submit();
        }
    </script>
</head>
<body style="left: 0; right: 0; width: 522px; margin: 0; float: left; position: absolute;">
    <div class="account-register" style="margin-left: 0px; height: 430px; border-radius: 0px; -webkit-border-radius: 0px;">
        <form method="post" action="../account/register.aspx" onsubmit="return checkAll();" id="createAccountsFrom">
        <input name="action" type="hidden" value="" />
        <div class="account-register-card">
            <table>
                <tr>
                    <td>
                        <label class="account-register-card-label">
                            <span style="color: #f30">*</span>用户名</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input class="account-register-card-input" id="CreateUsername" name="CreateUsername"
                            maxlength="21" type="text" placeholder="可用邮箱作为您的用户名" onblur="javascript:checkUser();"
                            onkeyup="javascript:checkUserLength();" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span id="msg_username" class="account-register-span">6~20个字符，可使用汉字、字母、数字，区分大小写。</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="account-register-card-label">
                            <span style="color: #f30">*</span>密码</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input class="account-register-card-input" id="CreatePassword" name="CreatePassword"
                            type="password" onkeyup="javascript:safe();" onblur="javascript:checkPass();"
                            onkeyup="javascript:safe();" onfocus="javascript:document.getElementById('msg_password').className = 'account-register-span';document.getElementById('msg_password').innerHTML = '密码强度：';document.getElementById('passwdSocre').style.display = '';"
                            maxlength="16" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span id="msg_password" class="account-register-span">6~16个字符，可使用字母、数字、符号，区分大小写。</span><em
                            id="passwdSocre"><i class="w1" style="display: none;" id="w1">弱</i> <i class="w2"
                                style="display: none;" id="w2">中</i> <i class="w3" style="display: none;" id="w3">强</i>
                            <i class="w4" style="display: none;" id="w4">极强</i> </em>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="account-register-card-label">
                            <span style="color: #f30">*</span>确认密码</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input class="account-register-card-input" id="CreateRePassword" name="CreateRePassword"
                            type="password" onblur="javascript:checkRepass();" maxlength="16" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span id="msg_repassword" class="account-register-span">请再输入一次。</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="account-register-card-label">
                            <span style="color: #f30">*</span>验证码</label>
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td>
                        <input class="account-register-card-input" id="validate" name="validate" type="text"
                            style="width: 210px;" onblur="javascript:checkValidate_sj();" />
                        <div id="code">
                            <img id="imgOK" src="VerifyCode.ashx" onclick="changeImg();return false;" alt="验证码" />
                            <a id="codeImg" href="#" onclick="changeImg();return false;">看不清，换一张</a>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span id="msg_validate" class="account-register-span">请填写图片中的字符，不区分大小写。</span>
                    </td>
                </tr>
                <tr style="height: 32px;">
                    <td>
                        <label class="remember account-login-remember" style="margin-left: 8px;">
                            <input id="registerAgree" name="registerAgree" type="checkbox" value="yes" checked="checked" />
                            <span class="account-register-agree-span">我已阅读并接受
                                <a class="registeragree" href="javascript:;">"服务条款"</a>
                                和
                                <a class="registeragree" href="javascript:;">"用户须知"</a>、
                                <a class="registeragree" href="javascript:;">"隐私权相关政策"</a>
                            </span>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="RegisterSubmit" name="RegisterSubmit" class="account-register-button-sumbit"
                            type="submit" value="创建账户" onsubmit="CreateAccount()" />
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
