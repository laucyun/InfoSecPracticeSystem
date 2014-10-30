<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lianxi.aspx.cs" Inherits="lianxi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%#title%> - 信息安全竞赛练习系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="images/logo.png"  itemprop="image" />
    <link rel="shortcut icon" href="images/logo.png"  type="image/x-icon" />
    <link rel="Stylesheet" type="text/css" href="css/lianxi.css" />
    <link rel="Stylesheet" type="text/css" href="css/loading.css" />
    <script charset="utf-8" type="text/javascript" src="js/jquery-1.7.2.js"></script>
    <script charset="utf-8" type="text/javascript" src="js/lianxi.js"></script>
</head>
<body>
    <div class="wrapper">
        <input type="hidden" value="<%#totalTimu%>" name="totalTimu" />
        <input type="hidden" value="1" id="currentTihao" />
        <input type="hidden" id="isShowDaan" value="0" />
        <div class="timu">
            <div class="broder">
                <div class="timucontent"></div>
                <ul class="timuoptions">
                </ul>
                <div class="select">
                    <div class="selectoptions"></div>
                    <div class="selectdaan">您选择的答案：<span class="redfont" id="youselectdaan"></span></div>
                    <div class="rightdaan redfont"></div>
                    <div class="selectbtn">
                        <input type="checkbox"/><span class="showdaan">显示答案</span>
                        <input class="btnwidth" type="button" onclick="shangyiti()" value="上一题" />
                        <input class="btnwidth" type="button" onclick="xiayiti()" value="下一题" />
                    </div>
                </div>
            </div>
        </div>
        <div class="tihao">
            <table class="table1">
                <tbody>
                    <asp:Repeater ID="tihaoRepeater" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td>
                            <a id="<%#Eval("timuId1")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId1")%>')" class="">
                                <b><%#Eval("tihao1")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao1")%>" value="<%#Eval("timuId1")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao1")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao1")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId2")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId2")%>')" class="">
                                <b><%#Eval("tihao2")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao2")%>" value="<%#Eval("timuId2")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao2")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao2")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId3")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId3")%>')" class="">
                                <b><%#Eval("tihao3")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao3")%>" value="<%#Eval("timuId3")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao3")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao3")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId4")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId4")%>')" class="">
                                <b><%#Eval("tihao4")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao4")%>" value="<%#Eval("timuId4")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao4")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao4")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId5")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId5")%>')" class="">
                                <b><%#Eval("tihao5")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao5")%>" value="<%#Eval("timuId5")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao5")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao5")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId6")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId6")%>')" class="">
                                <b><%#Eval("tihao6")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao6")%>" value="<%#Eval("timuId6")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao6")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao6")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId7")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId7")%>')" class="">
                                <b><%#Eval("tihao7")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao7")%>" value="<%#Eval("timuId7")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao7")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao7")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId8")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId8")%>')" class="">
                                <b><%#Eval("tihao8")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao8")%>" value="<%#Eval("timuId8")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao8")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao8")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId9")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId9")%>')" class="">
                                <b><%#Eval("tihao9")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao9")%>" value="<%#Eval("timuId9")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao9")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao9")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId10")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId10")%>')" class="">
                                <b><%#Eval("tihao10")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao10")%>" value="<%#Eval("timuId10")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao10")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao10")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId11")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId11")%>')" class="">
                                <b><%#Eval("tihao11")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao11")%>" value="<%#Eval("timuId11")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao11")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao11")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId12")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId12")%>')" class="">
                                <b><%#Eval("tihao12")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao12")%>" value="<%#Eval("timuId12")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao12")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao12")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId13")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId13")%>')" class="">
                                <b><%#Eval("tihao13")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao13")%>" value="<%#Eval("timuId13")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao13")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao13")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId14")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId14")%>')" class="">
                                <b><%#Eval("tihao14")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao14")%>" value="<%#Eval("timuId14")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao14")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao14")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId15")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId15")%>')" class="">
                                <b><%#Eval("tihao15")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao15")%>" value="<%#Eval("timuId15")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao15")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao15")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId16")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId16")%>')" class="">
                                <b><%#Eval("tihao16")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao16")%>" value="<%#Eval("timuId16")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao16")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao16")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId17")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId17")%>')" class="">
                                <b><%#Eval("tihao17")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao17")%>" value="<%#Eval("timuId17")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao17")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao17")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId18")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId18")%>')" class="">
                                <b><%#Eval("tihao18")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao18")%>" value="<%#Eval("timuId18")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao18")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao18")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId19")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId19")%>')" class="">
                                <b><%#Eval("tihao19")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao19")%>" value="<%#Eval("timuId19")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao19")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao19")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId20")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId20")%>')" class="">
                                <b><%#Eval("tihao20")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao20")%>" value="<%#Eval("timuId20")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao20")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao20")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId21")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId21")%>')" class="">
                                <b><%#Eval("tihao21")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao21")%>" value="<%#Eval("timuId21")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao21")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao21")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId22")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId22")%>')" class="">
                                <b><%#Eval("tihao22")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao22")%>" value="<%#Eval("timuId22")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao22")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao22")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId23")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId23")%>')" class="">
                                <b><%#Eval("tihao23")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao23")%>" value="<%#Eval("timuId23")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao23")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao23")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId24")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId24")%>')" class="">
                                <b><%#Eval("tihao24")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao24")%>" value="<%#Eval("timuId24")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao24")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao24")%>" value="" />
                            </a>
                        </td>
                        <td>
                            <a id="<%#Eval("timuId25")%>" href="javascript:;" onclick="selectTimu('<%#Eval("timuId25")%>')" class="">
                                <b><%#Eval("tihao25")%></b>
                                <span></span>
                                <input type="hidden" name="tihao<%#Eval("tihao25")%>" value="<%#Eval("timuId25")%>" />
                                <input type="hidden" name="timudaan<%#Eval("tihao25")%>" value="" />
                                <input type="hidden" name="isRight<%#Eval("tihao25")%>" value="" />
                            </a>
                        </td>
                    </tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>