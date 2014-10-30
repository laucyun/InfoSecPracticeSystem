$(document).ready(function ()
{
    var qid = $('input[name=tihao1]').val();
    $('a#' + qid).addClass('currentbg');
    selectTimu(qid);
    var ck = $("input[type='checkbox']").is(':checked');
    if (ck == true)
    {
        showdaan();
    }
    $("input[type='checkbox']").click(function ()
    {
        var ck = $("input[type='checkbox']").is(':checked');
        if (ck == true)
        {
            showdaan();
        }
        else
        {
            $("div.rightdaan").text("");
        }
    });

    $(document).bind("contextmenu", function (e)
    {
        return false;
    });
});
/*ajax操作*/
function getDataAjax(action, tihao, timuid, timutype, daanid, response)
{
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function ()
    {
        if (xhr.readyState == 4)
        {
            if (xhr.status == 200)
            {
                response(xhr.responseText);
            }
        }
    };
    xhr.open("POST", "kaoshi.ashx", true);
    var formdata = new FormData();
    formdata.append("action", action);
    formdata.append("tihao", tihao);
    formdata.append("timuid", timuid);
    formdata.append("timutype", timutype);
    formdata.append("daanid", daanid);
    xhr.send(formdata);
}
function shangyiti()
{
    var val = $('#currentTihao').val();
    var cok = $("#currentOk").val();
    if (val == 1)
    {
        alert('已经是第一题啦!');
    }
    else
    {
        var tno = parseInt(val) - 1;
        var timuid = $("input[name='tihao" + tno + "']").val();
        selectTimu(timuid);
    }
}
function xiayiti()
{
    var val = $('#currentTihao').val();
    if (val == $("input[name^='tihao']").length)
    {
        alert("已经是第一题啦！");
    }
    else
    {
        var tno = parseInt(val) + 1;
        var timuid = $("input[name='tihao" + tno + "']").val();
        selectTimu(timuid);
    }
}
function showdaan()
{
    var tno = $('#currentTihao').val();
    var timuid = $("input[name='tihao" + tno + "']").val();
    showRight(timuid);
}
function selectTimu(qid)
{
    $("a#" + qid).addClass('currentbg');
    $("body [id!=" + qid + "]").removeClass('currentbg');
    var tno = $("a#" + qid).find("b").html();
    $("#currentTihao").val(tno);
    /*获取题目内容*/
    getDataAjax("getContent", "", qid, "", "", function (response)
    {
        var con = eval("[" + response + "]");
        var timucontent = con[0].value;
        var timutype = con[1].value;
        var timuoptions = parseInt(con[2].value);
        /*选项列表*/
        var timuoptionstr = "";
        for (var i = 3; i < con.length; i++)
        {
            timuoptionstr += "<li>" + con[i].value + "</li>";
        }
        /*题目内容*/
        var timutypestr = "";
        if (timutype == "0")
        {
            timutypestr = "（判断题）";
            timuoptionstr = "";
        }
        else if (timutype == "1")
        {
            timutypestr = "（单选题）";
        }
        else if (timutype == "2")
        {
            timutypestr = "（多选题）";
            timuoptionstr += "<li><input name=\"timuoptions\" type=\"button\" value=\"确定\" onclick=\"tijiao(" + tno + "," + timutype + "," + qid + ")\" /></li>";
        }
        $("div.timucontent").html("<span>" + timutypestr + tno + "、" + timucontent + "</span>");
        $("ul.timuoptions").html(timuoptionstr);
        /*选择*/
        var selectstr = "<span>请选择：</span>";
        if (timutype == "0")
        {
            selectstr += "<input id=\"" + qid + "01\" name=\"timuoptions\" type=\"button\" onclick=\"dati('" + tno + "','" + timutype + "','" + qid + "','√','" + qid + "01')\" value=\"√\" />";
            selectstr += "&nbsp;<input id=\"" + qid + "02\" name=\"timuoptions\" type=\"button\" onclick=\"dati('" + tno + "','" + timutype + "','" + qid + "','×','" + qid + "02')\" value=\"×\" />";
        }
        else if (timutype == "1" || timutype == "2")
        {
            for (var i = 0; i < timuoptions; i++)
            {
                selectstr += "&nbsp;<input id=\"" + con[i + 3].opid + "\" name=\"timuoptions\" type=\"button\" onclick=\"dati('" + tno + "','" + timutype + "','" + qid + "','" + getCaps(i) + "','" + con[i + 3].opid + "')\" value=\"" + getCaps(i) + "\" />";
            }
        }
        $("div.selectoptions").html(selectstr);
        /*处理该题是否已经做了，做了则不能选*/
        var rightstr = $("input[name='isRight" + tno + "']").val();
        if (rightstr == "0" || rightstr == "1")
        {
            $("input[name='timuoptions']").removeAttr("onclick");
            $("input[name='timuoptions']").attr("disabled", true);

            var myopid = $("input[name='timudaan" + tno + "']").val();
            var myopidArr = new Array();
            myopidArr = myopid.split(",")
            var myopidVal = "";
            for (var i = 0; i < myopidArr.length; i++)
            {
                if (myopidArr[i] != null && myopidArr[i] != "" && typeof (myopidArr[i]) != "undefined")
                {
                    myopidVal += $("#" + myopidArr[i]).val();
                }
            }
            $("span#youselectdaan").text(myopidVal);
            $("a#" + qid).find("span").text(myopidVal);
        }
        else
        {
            $("span#youselectdaan").text("");
            $("div.rightdaan").text("");
        }
        var ck = $("input[type='checkbox']").is(':checked');
        if (ck == true)
        {
            showRight(qid);
        }
    });
}
function getCaps(i)
{
    var x = "";
    switch (i)
    {
        case 0:
            x = "A";
            break;
        case 1:
            x = "B";
            break;
        case 2:
            x = "C";
            break;
        case 3:
            x = "D";
            break;
        case 4:
            x = "E";
            break;
        case 5:
            x = "F";
            break;
    }
    return x;
}
function dati(tihao, timutype, timuid, options, opid)
{
    if (timutype == "0" || timutype == "1")
    {
        $("span#youselectdaan").text(options);
        $("input[name='timudaan" + tihao + "']").val(opid);
        tijiao(tihao, timutype, timuid);
    }
    /*多选题*/
    if (timutype == "2")
    {
        var currentop = $("span#youselectdaan").text();
        var currentDaan = $("input[name='timudaan" + tihao + "']").val();
        if (currentop.search(options) == -1)
        {
            currentop += options;
            currentDaan += opid + ",";
        }
        else
        {
            currentop = currentop.replace(options, "");
            currentDaan = currentDaan.replace(opid + ",", "");
        }
        /*对答案排序*/
        var resop = "";
        var arr = new Array('A', 'B', 'C', 'D', 'E', 'F');
        for (var i = 0; i < arr.length; i++)
        {
            if (currentop.search(arr[i]) > -1)
            {
                resop += arr[i];
            }
        }
        $("span#youselectdaan").text(resop);
        $("input[name='timudaan" + tihao + "']").val(currentDaan);
    }
}
/*判断对错*/
function tijiao(tihao, timutype, timuid)
{
    var daanid = $("input[name='timudaan" + tihao + "']").val();
    getDataAjax("isRight", tihao, timuid, timutype, daanid, function (response)
    {
        $("a#" + timuid).find("span").text($("span#youselectdaan").text());
        $("input[name='isRight" + tihao + "']").val(response);
        if (response == "1")
        {
            $("a#" + timuid).addClass("rightbg");
            xiayiti();
        }
        if (response == "0")
        {
            $("a#" + timuid).addClass("errorbg");
            showRight(timuid);
        }
        $("#currentOk").val($("#currentOk").val() + tihao + ",");

    });
}
function showRight(qid)
{
    /*显示正确答案*/
    getDataAjax("getRight", "", qid, "", "", function (response)
    {
        var rightcon = eval("[" + response + "]");
        var timutype = rightcon[0].value;
        var rightOptions = "";
        for (var i = 1; i < rightcon.length; i++)
        {
            rightOptions += $("#" + rightcon[i].opid).val();
        }
        /*对答案排序*/
        var resop = "";
        if (timutype == "2")
        {

            var arr = new Array('A', 'B', 'C', 'D', 'E', 'F');
            for (var i = 0; i < arr.length; i++)
            {
                if (rightOptions.search(arr[i]) > -1)
                {
                    resop += arr[i];
                }
            }
        }
        else
        {
            resop = rightOptions;
        }
        $("div.rightdaan").text("正确答案：" + resop);
    });
}
