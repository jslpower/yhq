<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jporderlist.aspx.cs" Inherits="Eyousoft_yhq.Web.Jporderlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>无标题文档</title>
    <link rel="stylesheet" href="/css/style.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/style_jp.css" type="text/css" media="screen" />
</head>
<body>
    <div class="header">
        <h1>
            订单查询</h1>
        <a href="#" class="returnico"></a><a href="#" class="icon_phone"></a>
    </div>
    <div class="mainbox">
        <div class="dindan_box">
            <div class="dindan_t">
                <ul class="fixed">
                    <asp:Literal ID="litPay" runat="server"></asp:Literal>
              
                </ul>
            </div>
            <div class="dindan_list">
                <ul>
                    <asp:Literal ID="litJiPlist" runat="server"></asp:Literal>
                    <%--  <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>
              <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>--%>
                    <%-- <li>
                  <div class="dindan_R">
                      <p><span class="price"><dfn>¥</dfn>299</span></p>
                      <p><a href="#" class="fukuan_btn">付款</a></p>
                  </div>
                  <div class="dindan_L">
                      <p>南方航空CZ6412    2014-08-21 周四</p>
                      <p class="font_gray">首都-虹桥</p>
                  </div>
              </li>--%>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>
