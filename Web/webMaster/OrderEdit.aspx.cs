using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EyouSoft.Common;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Web.webMaster
{
    public partial class OrderEdit : EyouSoft.Common.Page.webmasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string save = Utils.GetQueryStringValue("save");
            string id = Utils.GetQueryStringValue("orderid");
            string mark = Utils.GetQueryStringValue("saveType");


            initOrderState();
            if (mark == "1" || mark == "2") savePaysateOrRemoney(id, mark);
            if (dotype == "edit") initPage(id);
            if (save == "save") pageSave(save);
            if (save == "savepdf") pageSave(save);

            if (HuiYuanInfo.LeiXing == Eyousoft_yhq.Model.WebmasterLeiXing.供应商)
            {
                phCaoZuo.Visible = PlaceHolder1.Visible = false;
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="strid"></param>
        protected void initPage(string strid)
        {
            var model = new Eyousoft_yhq.BLL.Order().GetModel(strid);

            if (model != null)
            {
                lblProductName.Text = model.ProductName;
                if (model.isEvery)
                {
                    chk_Isevery.Checked = true;
                    txtsendDate.Visible = false;
                }
                else
                {
                    txtsendDate.Value = Utils.GetDateString(model.TourDate, "yyyy-MM-dd");
                }
                lbType.Text = InitDropDownList(model.ProductType);
                lbContact.Text = Enum.GetName(typeof(Model.ContractType), model.ContractType);
                if (ddl_orderState.Items.FindByValue(((int)model.OrderState).ToString()) != null)
                    ddl_orderState.Items.FindByValue(((int)model.OrderState).ToString()).Selected = true;

                lblOrderPrice.Text = model.OrderPrice.ToString("0.00");
                lblCode.Text = model.FavourCode;
                lblConfirmCode.Text = model.ConfirmCode;
                lblPname.Text = model.MemberName;
                lblPsex.Text = model.MemberSex.ToString();
                lblPtel.Text = model.MemberTel.ToString();
                txtSpecialMark.Value = model.Remark;
                InOrderId.Value = model.OrderCode;
                lblPaystate.Text = model.PayState.ToString();
                txt_ReMoney.Text = model.RebackMoney.ToString("0.00");
                lblFYJE.Text = model.FYJE.ToString("C2");
                if (!string.IsNullOrEmpty(model.AddressID))
                {
                    var address = new Eyousoft_yhq.BLL.Member().GetAddress(model.AddressID);
                    if (address != null)
                    {
                        lbladdressName.Text = address.ContactName;
                        lbladdressinfo.Text = string.Format("{0} {1} {2} {3}", address.AddressProvinceName, address.AddressCityName, address.AddressCountryName, address.AddressInfo);
                        lbladdressZPcode.Text = address.ZpCode;
                        lbladdressmob.Text = address.MobileNum;
                        lbladdresstel.Text = address.TelNum;
                    }
                }
                else
                {
                    PlaceHolder2.Visible = false;
                }


                #region 附件处理
                //附件
                StringBuilder strPdFile = new StringBuilder();
                IList<Eyousoft_yhq.Model.Attach> lstFile = model.SendFile;
                if (null != lstFile && lstFile.Count > 0)
                {
                    strPdFile.AppendFormat("<span class='upload_filename'><a href='{0}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"pageOpt.RemoveFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}|{2}'/></span>", lstFile[0].FilePath, lstFile[0].Name, lstFile[0].IsWebImage);
                }
                this.lblpdfile.Text = strPdFile.ToString();//附件
                #endregion

                #region  页面逻辑处理
                if (model.PayState == Eyousoft_yhq.Model.PaymentState.已支付)
                {
                    place_a.Visible = false;
                    PlaceHolder1.Visible = true;
                }
                if (this.CheckGrantMenu2(Eyousoft_yhq.Model.Privs.订单支付) ) DDZF.Visible = true;
                if (this.CheckGrantMenu2(Eyousoft_yhq.Model.Privs.返佣结算) ) FYZF.Visible = true;


                #endregion
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="doType"></param>
        protected void pageSave(string doType)
        {

            Eyousoft_yhq.Model.Order model = new Eyousoft_yhq.Model.Order();
            Eyousoft_yhq.BLL.Order bll = new Eyousoft_yhq.BLL.Order();
            model.OrderID = Utils.GetQueryStringValue("orderid");
            model.OrderState = (Eyousoft_yhq.Model.OrderState)Utils.GetInt(Utils.GetFormValue(this.ddl_orderState.UniqueID));
            model.Remark = Utils.GetFormValue(this.txtSpecialMark.UniqueID);
            model.OrderPrice = Utils.GetDecimal(Utils.GetFormValue(this.lblOrderPrice.UniqueID));
            model.SendFile = NewGetAttach();



            string OrderIhpone = this.lblPtel.Text;
            string OrderCode = this.InOrderId.Value;
            bool result = false;
            string msg = "";
            Eyousoft_yhq.Model.MCompanySetting exModel = new Eyousoft_yhq.BLL.KV().GetCompanySetting();
            if (model.OrderState == Eyousoft_yhq.Model.OrderState.待付款 || model.OrderState == Eyousoft_yhq.Model.OrderState.已取消)
            {
                if (exModel != null && exModel.MsgNumber > 0)
                {
                    if (doType == "save")
                    {

                        result = bll.Update(model) > 0 ? true : false;
                        msg = result ? "修改成功！" : "修改失败！";
                        if (result == true)
                        {
                            SendMsg(model.OrderState, OrderIhpone, OrderCode, model.OrderID);
                        }

                    }
                }
                else
                {
                    msg = "短信数量不足，修改短信发送失败！";
                }
            }
            else
            {
                if (doType == "save")
                {

                    result = bll.Update(model) > 0 ? true : false;
                    msg = result ? "修改成功！" : "修改失败！";

                }
            }
            if (doType == "savepdf")
            {
                result = bll.SavePDF(model) > 0 ? true : false;
                msg = result ? "保存成功！" : "保存失败！";
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            Response.End();

        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="orderstate">订单状态</param>
        /// <param name="Iphone">订单手机</param>
        /// <param name="OrderId">订单Code</param>
        /// <param name="or">订单ID</param>
        /// <returns></returns>
        protected string SendMsg(Eyousoft_yhq.Model.OrderState orderstate, string Iphone, string OrderId, string or)
        {
            string OM = new Eyousoft_yhq.BLL.Order().GetModel(or).MemberID;
            bool valiUser = new Eyousoft_yhq.BLL.Member().GetModel(OM).valiUser;
            if (!valiUser)
            {
                string result = string.Empty;//返回发送结果
                string sendNum = Iphone; //发送账号
                IList<Eyousoft_yhq.Model.SMSChannel> channel = Eyousoft_yhq.Web.BsendMsg.CommonProcess.GetSMSChannels();
                string Msg = string.Empty;
                if (orderstate == Eyousoft_yhq.Model.OrderState.待付款)
                {
                    Msg = string.Format("订单确认成功，请及时进行支付 订单号：{0}！【惠旅游】", OrderId);
                    Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(sendNum, Msg, channel[0], out result);//发送
                }
                else if (orderstate == Eyousoft_yhq.Model.OrderState.已取消)
                {
                    Msg = "订单确认失败，原因：订单预控人数已经满员！【惠旅游】";
                    Eyousoft_yhq.Web.BsendMsg.CommonProcess.SendSMS(sendNum, Msg, channel[0], out result);//发送





                }
                #region  短信日志
                Eyousoft_yhq.Model.MsgLog MsLog = new Eyousoft_yhq.Model.MsgLog
                {
                    TelCode = sendNum,
                    MsgText = Msg,
                    ReResult = result
                };
                new Eyousoft_yhq.BLL.MsgLog().Add(MsLog);
                #endregion
                return result;
            }
            return "";
        }

        /// <summary>
        /// 初始化产品类型
        /// </summary>
        private string InitDropDownList(int TypeId)
        {
            string TypeName = string.Empty;
            var model = new Eyousoft_yhq.BLL.ProductType().GetModel(TypeId);
            if (model != null) return model.TypeName;
            return TypeName;
        }


        /// <summary>
        /// 初始化订单状态
        /// </summary>
        private void initOrderState()
        {

            var OrderStateList = EnumObj.GetList(typeof(Model.OrderState));
            ddl_orderState.DataSource = OrderStateList;
            ddl_orderState.DataTextField = "Text";
            ddl_orderState.DataValueField = "Value";
            ddl_orderState.DataBind();

        }


        /// <summary>
        /// 附件操作
        /// </summary>
        /// <returns>附件列表</returns>
        private IList<Eyousoft_yhq.Model.Attach> NewGetAttach()
        {
            IList<Eyousoft_yhq.Model.Attach> lst = new List<Eyousoft_yhq.Model.Attach>();
            #region 手机端图片处理
            //新上传附件
            string[] upload = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            if (upload.Length != 0)
            {
                for (int i = 0; i < upload.Length; i++)
                {
                    string[] newupload = upload[i].Split('|');
                    if (newupload != null && newupload.Length > 1)
                    {
                        Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                        attModel.FilePath = newupload[1];
                        attModel.Name = newupload[0];
                        attModel.IsWebImage = false;
                        lst.Add(attModel);
                    }
                }
            }
            else
            {
                //之前上传的附件
                string stroldupload = Utils.GetFormValue("hideFileInfo");

                if (!string.IsNullOrEmpty(stroldupload))
                {
                    string[] oldupload = stroldupload.Split(',');
                    if (oldupload != null && oldupload.Length > 0)
                    {
                        for (int i = 0; i < oldupload.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(oldupload[i]))
                            {
                                string[] uploaditem = oldupload[i].Split('|');
                                Eyousoft_yhq.Model.Attach attModel = new Eyousoft_yhq.Model.Attach();
                                attModel.Name = uploaditem[0];
                                attModel.FilePath = uploaditem[1];
                                attModel.IsWebImage = bool.Parse(uploaditem[2]);
                                lst.Add(attModel);
                            }
                        }
                    }
                }
            }
            #endregion



            return lst;
        }
        /// <summary>
        /// 设置支付状态和返佣金额
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="mark"></param>
        private void savePaysateOrRemoney(string orderid, string mark)
        {
            var model = new Eyousoft_yhq.Model.Order()
            {
                OrderID = orderid,
                RebackMoney = Utils.GetDecimal(Utils.GetFormValue(txt_ReMoney.UniqueID)),
                PayState = Eyousoft_yhq.Model.PaymentState.已支付,
                OrderState = Eyousoft_yhq.Model.OrderState.已成交
            };
            bool result = false;
            string msg = "";
            if (mark == "1")
            {
                result = new Eyousoft_yhq.BLL.Order().SavePayState(model) == 1 ? true : false;
            }
            else if (mark == "2")
            {
                result = new Eyousoft_yhq.BLL.Order().SaveReMoney(model) == 1 ? true : false;
            }
            else
            {
                msg = "参数错误，请从新操作";
            }
            if (result)
            {
                msg = "修改成功";
            }
            else
            {
                msg = "修改失败";
            }
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result ? "1" : "0", msg));
            Response.End();
        }
    }
}
