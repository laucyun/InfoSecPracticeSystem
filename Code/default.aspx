<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>信息安全竞赛练习系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="images/logo.png"  itemprop="image" />
    <link rel="shortcut icon" href="images/logo.png"  type="image/x-icon" />
    <link rel="Stylesheet" type="text/css" href="css/default.css" />
    <script charset="utf-8" type="text/javascript" src="js/jquery-1.7.2.js"></script>
    <script charset="utf-8" type="text/javascript" src="js/jquery.cookie.js"></script>
    <script charset="utf-8" type="text/javascript">
        $(document).ready(function ()
        {
            $("#informa").mouseover(function ()
            {
                $("div.informmenu").css("display", "inline");
            });
            $("div.informmenu").mouseover(function ()
            {
                $("div.informmenu").css("display", "inline");
            });
            $("#informa").mouseout(function ()
            {
                $("div.informmenu").css("display", "none");
            });
            $("div.informmenu").mouseout(function ()
            {
                $("div.informmenu").css("display", "none");
            });
        });
        /*ajax*/
        function signout()
        {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function (e)
            {
                if (xhr.readyState == 4)
                {
                    if (xhr.status == 200)
                    {
                        if (xhr.responseText == 1)
                        {
                            window.location.href = "<%#domain%>";
                        }
                    }
                }
            };
            xhr.open("POST", "<%#domain%>/account/signout.aspx", true);
            var formdata = new FormData();
            formdata.append("type", "signout");
            xhr.send(formdata);
        }
    </script>
</head>
<body>
    <div class="inform">
        <a href="javascript:;" id="informa">
            <i><img src="images/header.jpg" alt="" /></i>
            <span><%#uname%></span>
            <s></s>
        </a>
        <div class="informmenu">
            <b></b>
            <a href="javascript:;" target="_blank">个人信息</a>
            <a href="javascript:;" target="_blank">意见反馈</a>
            <a href="javascript:;" target="_blank">帮助中心</a>
            <a href="javascript:;" onclick="signout()">退出登录</a>
        </div>
    </div>
    <div class="wrapper">
        <div class="btn">
            <ul>
                <li><a href="lianxi.aspx?type=b8ca28006a659d5fed930fcf333976be" target="_blank" class="btn-shunxu">
                    <span>顺序练习</span></a> </li>
                <li><a href="lianxi.aspx?type=a1d8bfacd7aa75f6f6500f361e352648" target="_blank" class="btn-suiji">
                    <span>随机练习</span></a> </li>
                <li><a href="cuoti.aspx" target="_blank" class="btn-cuowu"><span>错题集</span></a>
                </li>
                <li><a href="" target="_blank" class="btn-shoucang"><span>收藏题集</span></a> </li>
                <li><a href="kaoshi.aspx" target="_blank" class="btn-kaoshi"><span>模拟考试</span></a>
                </li>
                <li><a href="" target="_blank" class="btn-kaoshijilu"><span>考试记录</span></a> </li>
            </ul>
        </div>
    </div>
    <div class="footer">
         Copyright &copy; <%#Year%> <a href="<%#domain%>" target="_blank">信息安全竞赛练习系统.</a> All Rights Reserved.
    </div>
</body>
</html>
