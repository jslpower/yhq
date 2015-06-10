<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenuList.aspx.cs" Inherits="yhq.webMaster.LeftMenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>运营后台左侧菜单</title>
    <link href="/css/manager.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="/js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script language="JavaScript" type="">
        function setMenuTitle(spanId, imgId) {
            //$("#" + spanId).toggle();
            document.getElementById(spanId).style.display = (document.getElementById(spanId).style.display == 'none') ? '' : 'none';
            var $objImg = $("#" + imgId);
            if ($objImg.attr("src") == "/images/webmaster/button_up.gif") {
                $objImg.attr("src", "/images/webmaster/button_down.gif");
            }
            else if ($objImg.attr("src") == "/images/webmaster/button_down.gif") {
                $objImg.attr("src", "/images/webmaster/button_up.gif");
            }
        }

        function setAcss(id_num, cap) {

            setvalue("当前操作：" + cap);
        }

        var strColumns_Current = "20,*";
        //菜单隐藏rows="20,*"
        function hidetoc() {
            strColumns_Current = top.contset.rows
            top.contset.rows = "1,*";
        }
        //菜单显示
        function showtoc() {
            top.contset.rows = strColumns_Current;
        }

        function mouseovertoc() {
            //      window.status = "隐藏菜单";
            document.all.hidemenu.src = "/images/webmaster/hidetoc2.gif";
        }

        function mouseouttoc() {
            document.all.hidemenu.src = "/images/webmaster/hidetoc1.gif";
        }
        //设置单项选中样式
        function setMenuClass(obj) {
            $("a").each(function() {
                $(this).attr("class", "");
            })
            $(obj).attr("class", "menuon");
        }
        $(function() {
            $("a").click(function() {
                setMenuClass(this);
            });
        });
    </script>

    <style type="text/css">
        body
        {
            background-color: #E6EDF2;
            overflow-x: hidden;
        }
        HTML
        {
            overflow-x: hidden;
            overflow-y: auto;
        }
        .linkcsstitle td
        {
            background: url(/images/tiao.jpg);
            height: 26px;
        }
    </style>
</head>
<body>
    <asp:PlaceHolder runat="server" ID="phXiTongYongHu" Visible="false">
        <div class="leftmenu" id="divRouteManage" runat="server">
            <span class="linkcsstitle" id="main0" onclick="javascript: setMenuTitle('spanRouteManage','RouteManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>会员管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="RouteManage" src="/images/webmaster/button_up.gif" name="menutitle0" alt="" />
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanRouteManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trRoute" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder0" runat="server">
                                <img src="/images/webmaster/func_default.gif" alt="" />
                                <a href="MemberList.aspx" target="mainFrame">用户注册信息管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div1" runat="server">
            <span class="linkcsstitle" id="main5" onclick="javascript: setMenuTitle('spanScenicAndTicket','ScenicAndTicket');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>产品展示管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="ScenicAndTicket" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanScenicAndTicket" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr6" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder4" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="ProductList.aspx" target="mainFrame">产品展示管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trScenicTicket" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder5" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="CouponsList.aspx" target="mainFrame">优惠券使用管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div4" runat="server">
            <span class="linkcsstitle" id="Span3" onclick="javascript: setMenuTitle('span4','Img2');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>车票管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="Img2" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span4" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr5" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder7" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="BusTicketList.aspx" target="mainFrame">车票管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div5" runat="server">
            <span class="linkcsstitle" id="Span5" onclick="javascript: setMenuTitle('span6','Img3');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>景点门票管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="Img3" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span6" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr9" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder10" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="ScenicList.aspx" target="mainFrame">景点门票管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div6" runat="server">
            <span class="linkcsstitle" id="Span7" onclick="javascript: setMenuTitle('span8','ImgJP');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>机票管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="ImgJP" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="span8" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr7" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder9" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="PlanTicketList.aspx" target="mainFrame">机票管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div3" runat="server">
            <span class="linkcsstitle" id="Span2" onclick="javascript: setMenuTitle('spanMasterOrderManage','MasterOrderManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>订单管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="MasterOrderManage" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanMasterOrderManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr2" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="OrderList.aspx" target="mainFrame">订单管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr12" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder15" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="JPOrderList.aspx" target="mainFrame">机票订单管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr13" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder17" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="PlanInsList.aspx" target="mainFrame">保险订单管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr16" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder16" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="ConDetallist.aspx" target="mainFrame">消费记录管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr14" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder18" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="WxPayList.aspx" target="mainFrame">充值记录管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="div2" runat="server">
            <span class="linkcsstitle" id="Span1" onclick="javascript: setMenuTitle('spanScenicAndHotel','imgCP');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>产品评论管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="imgCP" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanScenicAndHotel" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr8" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder8" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="CommentList.aspx" target="mainFrame">评论管理 </a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="divUserManage" runat="server">
            <span class="linkcsstitle" id="main1" onclick="javascript: setMenuTitle('spanUserManage','UserManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>后台管理员管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="UserManage" src="/images/webmaster/button_up.gif" name="menutitle1">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanUserManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trUser" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder11" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="AdminList.aspx" target="mainFrame">管理列表</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="divBasicManage" runat="server">
            <span class="linkcsstitle" id="main2" onclick="javascript: setMenuTitle('spanBasicManage','BasicManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>产品类别管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="BasicManage" src="/images/webmaster/button_up.gif" name="menutitle2">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanBasicManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trCompany" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder12" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="ProductTypeList.aspx" target="mainFrame">产品类别管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="AdvImgList.aspx" target="mainFrame">轮换广告管理</a></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="divWXManage" runat="server">
            <span class="linkcsstitle" id="Span9" onclick="javascript: setMenuTitle('spanMasterWXManage','MasterWXManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>微信管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="MasterWXManage" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanMasterWXManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="tr10" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder13" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="CustomMsgLis.aspx" target="mainFrame">信息列表</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr11" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder14" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="YuYueList.aspx" target="mainFrame">预约信息</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr15" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder19" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="HongBao.aspx" target="mainFrame">红包列表</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="divMasterUserManage" runat="server">
            <span class="linkcsstitle" id="main4" onclick="javascript: setMenuTitle('spanMasterUserManage','MasterUserManage');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>基础信息</strong></font>
                        </td>
                        <td width="22">
                            <img id="MasterUserManage" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanMasterUserManage" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trMasterUserInfo" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder23" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="CompanyInfo.aspx" target="mainFrame">公司信息</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder3" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="TravelArticleClass.aspx" target="mainFrame">公告类别 </a></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder6" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="TravelArticleList.aspx" target="mainFrame">公告</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
        <div class="leftmenu" id="divWeiDian" runat="server">
            <span class="linkcsstitle" id="main4" onclick="javascript: setMenuTitle('spanWeiDian','imgWeiDian');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>微店管理</strong></font>
                        </td>
                        <td width="22">
                            <img id="imgWeiDian" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanWeiDian" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trWeiDian" runat="server">
                        <td>
                            <asp:PlaceHolder ID="phWeiDian" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="WeiDian.aspx" target="mainFrame">微店管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="phGysYongHu" Visible="false">
        <div class="leftmenu" id="divGys" runat="server">
            <span class="linkcsstitle" id="main4" onclick="javascript: setMenuTitle('spanGysChanPin','imgGys');">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="125" height="26" valign="center" nowrap="nowrap">
                            <font class="fonttitle">·<strong>供应商工作菜单</strong></font>
                        </td>
                        <td width="22">
                            <img id="imgGys" src="/images/webmaster/button_up.gif" name="menutitle4">
                        </td>
                        <td width="23">
                        </td>
                    </tr>
                </table>
            </span><span id="spanGysChanPin" style="display: none">
                <table cellspacing="0" cellpadding="2" width="100%" align="left">
                    <tr id="trGysChanPin" runat="server">
                        <td>
                            <asp:PlaceHolder ID="phGysChanPin" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="productlist.aspx" target="mainFrame">产品管理</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr id="trGysDingDan" runat="server">
                        <td>
                            <asp:PlaceHolder ID="phGysDingDan" runat="server">
                                <img src="/images/webmaster/func_default.gif" />
                                <a href="orderlist.aspx" target="mainFrame">订单中心</a> </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </span>
        </div>
    </asp:PlaceHolder>
    <div style="height: 30px;">
    </div>
</body>
</html>
