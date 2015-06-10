<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeCenter.aspx.cs" Inherits="Eyousoft_yhq.Web.AppPage.ZxingCode.CodeCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/style.css?v=4" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul class="addr_form">
            <li>
                <label>
                    客户姓名：</label><p>
                        <input name="contactname" type="text" class="formsize200 inputbg" runat="server"
                            id="contactname" valid="required" errmsg="客户姓名不能为空！" /><span class="star">*</span></p>
            </li>
            <li>
                <label>
                    性别：</label><p>
                        <asp:DropDownList ID="dl_sex" runat="server">
                        </asp:DropDownList>
            </li>
            <li>
                <label>
                    手机号码：</label><p>
                        <input name="contactmob" type="text" class="formsize200 inputbg" runat="server" id="contactmob"
                            valid="required|isMobile" errmsg="手机号码不能为空！|手机号码格式不正确！" /><span class="star">*</span></p>
            </li>
            <li>
                <label>
                    机票订单号：</label><p>
                        <input name="contacticket" type="text" class="formsize200 inputbg" runat="server"
                            id="contacticket" valid="required" errmsg="机票订单号不能为空！" /><span class="star">*</span></p>
            </li>
            <li>
                <label>
                    订单状态：</label>
                <p>
                    <input id="yzf" name="yzf" type="checkbox" value="2" runat="server" />&nbsp;已支付&nbsp;&nbsp;
                    <input id="ycp" name="ycp" type="checkbox" value="1" runat="server" />&nbsp;已出票&nbsp;&nbsp;
                </p>
            </li>
            <li style="height: auto">
                <label>
                    备注：</label><p>
                        <textarea style="width: 380px; height: 140px;" class="inputbg" name="remark" id="remark"
                            runat="server"></textarea></p>
            </li>
            <li>
                <p style="margin-left: 10em;">
                    <button class="baocunbtn" id="btnsave" onclick="return false">
                        保 存</button></p>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
