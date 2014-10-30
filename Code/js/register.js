//检查用户名
function checkUser()
{
    username = document.getElementById("CreateUsername").value;
    if (username == '')
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span';
        document.getElementById("msg_username").innerHTML = '6~20个字符，可使用汉字、字母、数字，区分大小写。';
        return false;
    }
    if (/^[_\.0-9a-zA-Z-]+@([0-9a-zA-Z][0-9a-zA-Z-]+\.)+[a-zA-Z]{2,4}$/.test(username))
    {
        document.getElementById("CreateEmail").value = username;
    }
    if (username.length < 6)
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span-error';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-error"></b>&nbsp;最少6个字符。';
        return false;
    }
    if (username.replace(/[^\x00-\xff]/g, "**").length > 20)
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span-error';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-error"></b>&nbsp;请不要超过20个字符。';
        return false;
    }
    if (/[^\u4E00-\u9FA5\w_@\.\-]/.test(username))
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span-error';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-error"></b>&nbsp;请输入汉字、字母、数字。';
        return false;
    }
    startrequest('../account/register.ashx?', 'type=username&value=' + username, 1, function (response)
    {
        if (response == 1)
        {
            err = 1;
        }
        else
        {
            err = 0;
        }
    });
    if (err == 1)
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span-error';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-error"></b>&nbsp;此帐号已被注册，请重新输入。';
        return false;
    }
    if (username != username.toLowerCase())
    {
        document.getElementById("msg_username").style.display = '';
        document.getElementById("msg_username").className = 'account-register-span-right';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-right"></b>&nbsp;恭喜，此帐号可注册。登录时区分大小写。';
    }
    else
    {
        document.getElementById("msg_username").className = 'account-register-span-right';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-right"></b>&nbsp恭喜，此帐号可注册。';
    }
    return true;
}
//检查用户名的长度
function checkUserLength()
{
    document.getElementById("msg_username").style.display = '';
    var username = document.getElementById("CreateUsername").value;
    if (username.length > 20)
    {
        document.getElementById("msg_username").className = 'account-register-span-error';
        document.getElementById("msg_username").innerHTML = '<b class="account-register-error"></b>&nbsp;请不要超过20个字符。';
        return false;
    }
    document.getElementById("msg_username").className = 'account-register-span';
    document.getElementById("msg_username").innerHTML = '6~20个字符，可使用汉字、字母、数字，区分大小写。';
    return true;
}
//检查密码
function checkPass()
{
    var pass = document.getElementById("CreatePassword").value;
    if (pass == "")
    {
        document.getElementById("msg_password").style.display = '';
        document.getElementById("msg_password").className = 'account-register-span';
        document.getElementById("msg_password").innerHTML = '6~16个字符，可使用字母、数字、符号，区分大小写。';
        return false;
    }
    if (pass.length < 6)
    {
        document.getElementById("msg_password").style.display = '';
        document.getElementById('passwdSocre').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span-error';
        document.getElementById("msg_password").innerHTML = '<b class="account-register-error"></b>&nbsp;最少6个字符。';

        return false;
    }
    if (pass.length > 16)
    {
        document.getElementById("msg_password").style.display = '';
        document.getElementById('passwdSocre').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span-error';
        document.getElementById("msg_password").innerHTML = '<b class="account-register-error"></b>&nbsp;最多16个字符。';
        return false;
    }
    if (pass == document.getElementById('CreateUsername').value)
    {
        document.getElementById("msg_password").style.display = '';
        document.getElementById('passwdSocre').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span-error';
        document.getElementById("msg_password").innerHTML = '<b class="account-register-error"></b>&nbsp;密码不能与帐号一致，请重新输入。';
        return false;
    }
    if (pass == '123456' || pass == '654321' || pass == '111222' || checkPassSame(pass) == false)
    {
        document.getElementById("msg_password").style.display = '';
        document.getElementById('passwdSocre').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span-error';
        document.getElementById("msg_password").innerHTML = '<b class="account-register-error"></b>&nbsp;您的密码过于简单，请重新输入。';
        return false;
    }
    document.getElementById("msg_password").className = 'account-register-span-right';
    document.getElementById("msg_password").innerHTML = '<b class="account-register-right"></b>&nbsp;密码强度：';
    document.getElementById('passwdSocre').style.display = '';
    return true;
}
//检查二次输入的密码
function checkRepass()
{
    var pass = document.getElementById("CreateRePassword").value;
    if (pass == "")
    {
        document.getElementById("msg_repassword").style.display = '';
        document.getElementById("msg_repassword").className = 'account-register-span';
        document.getElementById("msg_repassword").innerHTML = '请再输入一次。';
        return false;
    }
    if (pass.length < 6)
    {
        document.getElementById("msg_repassword").style.display = '';
        document.getElementById("msg_repassword").className = 'account-register-span-error';
        document.getElementById("msg_repassword").innerHTML = '<b class="account-register-error"></b>&nbsp;最少6个字符。';
        return false;
    }
    if (pass.length > 16)
    {
        document.getElementById("msg_repassword").style.display = '';
        document.getElementById("msg_repassword").className = 'account-register-span-error';
        document.getElementById("msg_repassword").innerHTML = '<b class="account-register-error"></b>&nbsp;最多16个字符。';
        return false;
    }
    if (pass != document.getElementById("CreatePassword").value)
    {
        document.getElementById("msg_repassword").style.display = '';
        document.getElementById("msg_repassword").className = 'account-register-span-error';
        document.getElementById("msg_repassword").innerHTML = '<b class="account-register-error"></b>&nbsp;两次输入的密码不一致。';
        return false;
    }
    if (pass == document.getElementById('CreateUsername').value)
    {
        document.getElementById("msg_repassword").style.display = '';
        document.getElementById("msg_repassword").className = 'account-register-span-error';
        document.getElementById("msg_repassword").innerHTML = '<b class="account-register-error"></b>&nbsp;密码不能与帐号一致，请重新输入。';
        return false;
    }
    document.getElementById("msg_repassword").className = 'account-register-span-right';
    document.getElementById("msg_repassword").innerHTML = '<b class="account-register-right"></b>&nbsp;两次输入的密码一致。';
    return true;
}
//验证码
function checkValidate_sj()
{
    val = document.getElementById("validate").value;
    if (val == '')
    {
        document.getElementById("msg_validate").className = 'account-register-span';
        document.getElementById("msg_validate").innerHTML = '请填写图片中的字符，不区分大小写';
        return false;
    }
    startrequest('../account/register.ashx?', 'type=validate&value=' + val, 1, function (response)
    {
        if (response == 1)
        {
            err = 1;
        }
        else
        {
            err = 0;
        }
    });
    if (err == 1)
    {
        document.getElementById("msg_validate").className = 'account-register-span-right';
        document.getElementById("msg_validate").innerHTML = '<b class="account-register-right"></b>&nbsp;您输入的验证码正确';
        document.getElementById("code").style.display = "none";
        return true;
    }
    else
    {
        document.getElementById("msg_validate").style.display = '';
        document.getElementById("msg_validate").className = 'account-register-span-error';
        document.getElementById("validate").value = '';
        document.getElementById("validate").focus()
        document.getElementById("msg_validate").innerHTML = '<b class="account-register-error"></b>&nbsp;您输入的验证码错误，请重新输入';
        document.getElementById('imgOK').src = "../account/VerifyCode.ashx?active=" + new Date().getMilliseconds();
        return false;
    }
}
function checkAll()
{
    if (!checkUser())
    {
        document.getElementById("CreateUsername").focus();
        return false;
    }
    if (!checkPass())
    {
        document.getElementById("CreatePassword").focus();
        return false;
    }
    if (!checkRepass())
    {
        document.getElementById("CreateRePassword").focus();
        return false;
    }
    if (!checkValidate_sj())
    {
        document.getElementById("validate").focus();
        return false;
    }
    if (!document.getElementById("registerAgree").checked)
    {
        alert("请阅读并接受\"服务条款\"和\"用户须知\"、\"隐私权相关政策\"");
        return false;
    }
    $("input[name='action']").val("Register");
    return true;
}

//检查密码是否一致
function checkPassSame(pass)
{
    var first = pass.substring(0, 1);
    var exp = new RegExp('^' + first + '+document.getElementById');
    if (exp.test(pass))
    {
        return false;
    }
    if (first == 'a' || first == 'A')
    {
        f = pass.charCodeAt(0);
        for (i = 1; i < pass.length; i++)
        {
            tmp = pass.charCodeAt(i);
            if (tmp - f != i)
            {
                return true;
            }
        }
        return false;
    }
    return true;
}
function safe()
{
    var pass = document.getElementById("CreatePassword").value;
    if (pass.length < 6)
    {
        var score = 0;
    }
    else if (pass == document.getElementById('CreateUsername').value)
    {
        var score = 0;
    }
    else if (pass == '123456' || pass == '654321' || pass == '111222' || checkPassSame(pass) == false)
    {
        var score = 0;
    }
    else
    {
        var score = passwordGrade(pass);
    }
    if (score <= 10)
    {
        document.getElementById('w1').style.display = '';
        document.getElementById('w2').style.display = 'none';
        document.getElementById('w3').style.display = 'none';
        document.getElementById('w4').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span';
        document.getElementById("msg_password").innerHTML = '密码强度：';
    }
    else if (score >= 11 && score <= 20)
    {
        document.getElementById('w1').style.display = 'none';
        document.getElementById('w2').style.display = '';
        document.getElementById('w3').style.display = 'none';
        document.getElementById('w4').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span';
        document.getElementById("msg_password").innerHTML = '密码强度：';
    }
    else if (score >= 21 && score <= 30)
    {
        document.getElementById('w1').style.display = 'none';
        document.getElementById('w2').style.display = 'none';
        document.getElementById('w3').style.display = '';
        document.getElementById('w4').style.display = 'none';
        document.getElementById("msg_password").className = 'account-register-span';
        document.getElementById("msg_password").innerHTML = '密码强度：';
    }
    else
    {
        document.getElementById('w1').style.display = 'none';
        document.getElementById('w2').style.display = 'none';
        document.getElementById('w3').style.display = 'none';
        document.getElementById('w4').style.display = '';
        document.getElementById("msg_password").className = 'account-register-span';
        document.getElementById("msg_password").innerHTML = '密码强度：';
    }
}
//计算密码安全系数
function passwordGrade(pwd)
{
    var score = 0;
    var regexArr = ['[0-9]', '[a-z]', '[A-Z]', '[\\W_]'];
    var repeatCount = 0;
    var prevChar = '';
    //check length
    var len = pwd.length;
    score += len > 18 ? 18 : len;
    //check type
    for (var i = 0, num = regexArr.length; i < num; i++)
    {
        if (eval('/' + regexArr[i] + '/').test(pwd))
            score += 4;
    }
    //bonus point
    for (var i = 0, num = regexArr.length; i < num; i++)
    {
        if (pwd.match(eval('/' + regexArr[i] + '/g')) && pwd.match(eval('/' + regexArr[i] + '/g')).length >= 2)
            score += 2;
        if (pwd.match(eval('/' + regexArr[i] + '/g')) && pwd.match(eval('/' + regexArr[i] + '/g')).length >= 5)
            score += 2;
    }
    //deduction
    for (var i = 0, num = pwd.length; i < num; i++)
    {
        if (pwd.charAt(i) == prevChar)
            repeatCount++;
        else
            prevChar = pwd.charAt(i);
    }
    score -= repeatCount * 1;
    return score;
}