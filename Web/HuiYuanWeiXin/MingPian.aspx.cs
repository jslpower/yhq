//会员名片 汪奇志 2015-01-21
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.IO;
using ZXing.QrCode;
using ZXing;
using System.Drawing;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    /// <summary>
    /// 会员名片
    /// </summary>
    public partial class MingPian : HuiYuanWeiXinYeMian
    {
        #region attributes
        /// <summary>
        /// 名片编号
        /// </summary>
        string MingPianId = string.Empty;
        /// <summary>
        /// 名片二维码文件路径
        /// </summary>
        protected string MingPianErWeiMaFilepath = string.Empty;

        protected string weixin_jsapi_config = string.Empty;
        /// <summary>
        /// 分享链接
        /// </summary>
        protected string FenXiangLianJie = string.Empty;
        /// <summary>
        /// 分享标题
        /// </summary>
        protected string FenXiangBiaoTi = string.Empty;
        /// <summary>
        /// 分享描述
        /// </summary>
        protected string FenXiangMiaoShu = string.Empty;
        /// <summary>
        /// 分享图片
        /// </summary>
        protected string FenXiangTuPianFilepath = string.Empty;
        /// <summary>
        /// 会员图像
        /// </summary>
        protected string TuXiangFilepath = string.Empty;
        /// <summary>
        /// 当前名片的会员编号
        /// </summary>
        protected string MingPianHuiYuanId = string.Empty;
        /// <summary>
        /// 微店编号
        /// </summary>
        protected string WeiDianId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("t") == "1") HongBaoResult();


            MingPianId = Utils.GetQueryStringValue("mingpianid");

            if (string.IsNullOrEmpty(MingPianId))
            {
                if (IsLogin)
                {
                    MingPianId = HuiYuanInfo.MingPianId;
                }
            }

            if (string.IsNullOrEmpty(MingPianId))
            {
                YanZhengLogin();
            }

            InitInfo();

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {

            var info = new Eyousoft_yhq.BLL.Member().GetMingPianInfo(MingPianId);

            if (info == null) { RedirectLogin(Request.Url.ToString()); }

            if (HuiYuanInfo != null)
            {
                if (HuiYuanInfo.UserID == info.HuiYuanId)
                {
                    plaHongBao.Visible = true;
                }
            }


            var hongbao = new Eyousoft_yhq.BLL.BHongBao().GetInfoByUserID(info.HuiYuanId);
            if (hongbao != null)
            {
                ltrHongBaoJinE.Text = hongbao.HongBaoJinE.ToString("F2");
            }

            #region 消息提示
            if (new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetLiuYanNum(info.HuiYuanId, info.LiuYanTime) > 0)
            {
                liuyanxiaoxi.Text = "<em class=\"radius\"></em>";
            }
            if (new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetGuanZhuNum(info.HuiYuanId, info.GuanZhuTime) > 0)
            {
                guanzhuxiaoxi.Text = "<em class=\"radius\"></em>";
            }
            if (new Eyousoft_yhq.BLL.BHuiYuanGuanXi().GetDianZanNum(info.HuiYuanId, info.DianZanTime) > 0)
            {
                dianzanxiaoxi.Text = "<em class=\"radius\"></em>";
            }
            ltrYouJiJiShu.Text = new Eyousoft_yhq.BLL.BYouJi().GetYouJiNum(info.HuiYuanId).ToString();
            #endregion


            ltrShouJi.Text = "<a href='tel:" + info.ShouJi + "'>" + info.ShouJi + "</a>";
            ltrWeiXinHao.Text = info.WeiXinHao;
            ltrXingMing.Text = info.XingMing;
            ltrZhiWei.Text = info.ZhiWei;
            ltrGongSiName.Text = info.GongSiName;

            ltrZanJiShu.Text = info.ZanJiShu.ToString();
            ltrGuanZhuJiShu.Text = info.GuanZhuJiShu.ToString();
            ltrLiuYanJiShu.Text = info.LiuYanJiShu.ToString();

            if (IsLogin && HuiYuanInfo.UserID == info.HuiYuanId) phSheZhi.Visible = true;

            TuXiangFilepath = info.TuXiangFilepath;
            if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";

            FenXiangLianJie = string.Format("http://{0}/huiyuanweixin/mingpian.aspx?mingpianid={1}&eventkey=qrscene_01", HOST, MingPianId);
            FenXiangBiaoTi = info.XingMing + "频道";
            FenXiangMiaoShu = "小伙伴们，快来看看我的微名片。";
            FenXiangTuPianFilepath = "http://" + HOST + TuXiangFilepath;
            MingPianErWeiMaFilepath = GetMingPianErWeiMaFilepath(MingPianId, FenXiangLianJie);

            this.Title = info.XingMing + "频道";

            MingPianHuiYuanId = info.HuiYuanId;

            WeiDianId = new Eyousoft_yhq.BLL.BWeiDian().GetWeiDianId(info.HuiYuanId);
            if (!string.IsNullOrEmpty(WeiDianId))
            {
                phWeiDian.Visible = true;
            }
        }

        /// <summary>
        /// 获取名片二维码图片路径
        /// </summary>
        /// <param name="mingPianId">名片编号</param>
        /// <param name="erWeiMaNeiRong">二维码内容</param>
        /// <returns></returns>
        string GetMingPianErWeiMaFilepath(string mingPianId, string erWeiMaNeiRong)
        {
            string filepath = "/ufiles/weixin/mingpianerweima/" + mingPianId + ".png";
            string mappath = Server.MapPath(filepath);

            if (!File.Exists(mappath))
            {
                var options = new QrCodeEncodingOptions
                {
                    Margin = 1,
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 200,
                    Height = 200
                };

                BarcodeWriter writer = null;
                writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                writer.Options = options;

                Bitmap bitmap = writer.Write(erWeiMaNeiRong);

                string dPath = System.IO.Path.GetDirectoryName(mappath);
                if (!Directory.Exists(dPath)) Directory.CreateDirectory(dPath);

                bitmap.Save(mappath);
            }

            return filepath;
        }

        /// <summary>
        /// 分享链接后红包增值
        /// </summary>
        void HongBaoResult()
        {

            if (HuiYuanInfo == null) Utils.RCWE_AJAX("0", "登陆后再操作");
            Eyousoft_yhq.BLL.BHongBao bll = new Eyousoft_yhq.BLL.BHongBao();
            string userid = HuiYuanInfo.UserID;// Utils.GetQueryStringValue("huiyuanid");
            decimal jine = Utils.GetDecimal(Utils.GetFormValue("JINE"), 0M);
            if (jine < 50) Utils.RCWE_AJAX("0", "注入金额不可小于50");
            var member = new Eyousoft_yhq.BLL.Member().GetModel(userid);
            if (member == null) Utils.RCWE_AJAX("0", "数据错误");
            if (member.YuE < jine)  //如果不存在判断账户余额
            {
                Utils.RCWE_AJAX("-99", "账户余额不足，请充值");
            }

            bool isExists = bll.Exists(userid); //判断是否存在红包
            if (isExists)
            {
                //存在的话 增值
                var hongbao = bll.GetInfoByUserID(userid);
                if (hongbao == null) Utils.RCWE_AJAX("0", "数据错误");
                hongbao.HongBaoJinE += jine;// getResult(hongbao.HongBaoJinE);
                int xgResult = bll.Update(hongbao);

                //添加消费明细
                if (xgResult == 1)
                {

                    var model = new Eyousoft_yhq.BLL.Member().GetModel(userid);
                    if (model != null)
                    {
                        new Eyousoft_yhq.BLL.Member().setMoney(userid, model.YuE - jine);
                    }


                    Eyousoft_yhq.BLL.BConDetaile conBll = new Eyousoft_yhq.BLL.BConDetaile();
                    Eyousoft_yhq.Model.MConDetaile con = new Eyousoft_yhq.Model.MConDetaile();
                    con.HuiYuanID = userid;
                    con.JiaoYiHao = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    con.DingDanBianHao = con.JiaoYiHao;
                    con.JinE = jine;
                    con.JiaoYiShiJian = DateTime.Now;
                    con.XFway = Eyousoft_yhq.Model.XFfangshi.红包抽奖;
                    con.DDCarrtes = Eyousoft_yhq.Model.DDleibie.红包消费;
                    conBll.Add(con);
                }
                Utils.RCWE_AJAX(xgResult == 1 ? "1" : "0", xgResult == 1 ? "操作成功" : "操作失败");
            }
            else
            {

                int tjResult = bll.Insert(new Eyousoft_yhq.Model.HongBao() { HongBaoJinE = jine, UserID = userid });      //如果账户充足，添加红包

                if (tjResult == 1)
                {
                    var model = new Eyousoft_yhq.BLL.Member().GetModel(userid);
                    if (model != null)
                    {
                        new Eyousoft_yhq.BLL.Member().setMoney(userid, model.YuE - jine);
                    }
                }

                Utils.RCWE_AJAX(tjResult == 1 ? "1" : "0", tjResult == 1 ? "操作成功" : "操作失败");

            }


        }
        ///// <summary>
        ///// 返回要增值的
        ///// </summary>
        ///// <param name="JinE"></param>
        ///// <returns></returns>
        //decimal getResult(decimal JinE)
        //{
        //    int radResult = new Random().Next(100);
        //    decimal radM = radResult / 1000M;
        //    return JinE * radM;
        //}
        #endregion
    }
}
