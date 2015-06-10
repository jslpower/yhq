using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Eyousoft_yhq.Model;
using System.Data;
using System.Linq;

namespace Eyousoft_yhq.Web.HuiYuanWeiXin
{
    public partial class ChouJiang : System.Web.UI.Page
    {
        protected string weixin_jsapi_config = string.Empty;
        protected string MingPianHuiYuanId = string.Empty;
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
        /// 红包者名片ID
        /// </summary>
        protected string MingPianId = string.Empty;
        protected string XingMing = string.Empty;
        protected string TuXiangFilepath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("t") == "1") getFxResult();
            if (Utils.GetQueryStringValue("choujiang") == "1") getResult();
            initFxInfo();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        void initFxInfo()
        {

            string userid = Utils.GetQueryStringValue("huiyuanid");
            var memeber = new Eyousoft_yhq.BLL.Member().GetModel(userid);
            if (memeber != null)
            {
                MingPianHuiYuanId = userid;


                MingPianId = memeber.MingPianId;
                XingMing = memeber.ContactName;
                FenXiangLianJie = string.Format("http://{0}/huiyuanweixin/mingpian.aspx?mingpianid={1}&eventkey=qrscene_01", Request.Url.Host, memeber.MingPianId);
                FenXiangBiaoTi = memeber.ContactName + "送给您红包，小伙伴快点啊！";
                FenXiangMiaoShu = "小伙伴们，快来拿红包吧。";
                TuXiangFilepath = memeber.TuXiangFilepath;
                if (string.IsNullOrEmpty(TuXiangFilepath)) TuXiangFilepath = "/images/weixin/head_no.png";
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuXiangFilepath;


                #region 显示抽奖记录
                var hongbao = new Eyousoft_yhq.BLL.BHongBao().GetInfoByUserID(memeber.UserID);
                if (hongbao != null)
                {

                    var choujianglist = new Eyousoft_yhq.BLL.BChouJiang().GetList(new ChouJiangSer() { ID = hongbao.ID });

                    if (choujianglist != null)
                    {
                        ltrChouJiang.Text = string.Format("已有{0}人参与抽奖", choujianglist.Count);
                        ltrZhongJiang.Text = string.Format("已发出红包{0}元", choujianglist.Select(i => i.DianShu).Sum().ToString("F2"));
                    }
                }
                #endregion


            }
        }

        #region 抽奖
        /// <summary>
        ///  抽奖
        /// </summary>
        void getResult()
        {

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Common.Page.HuiyuanPage.IsLogin(out m);
            if (!isLogin)
            {
                Utils.RCWE_AJAX("0", "未登录");
            }



            var hongbao = new Eyousoft_yhq.BLL.BHongBao().GetInfoByUserID(Utils.GetQueryStringValue("huiyuanid")); //判断是否存在红包
            if (hongbao == null) Utils.RCWE_AJAX("0", "该用户未设置红包");

            if (hongbao.UserID == m.UserID) Utils.RCWE_AJAX("0", "不能抽取自己的红包");

            //判断用户当日是否已经抽奖
            bool isExists = new Eyousoft_yhq.BLL.BChouJiang().Exists(new Eyousoft_yhq.Model.ChouJiang() { CaoZuoRenID = m.UserID, ChouJiangShiJian = DateTime.Now, FangShi = JiangLiFangShi.抽奖 });
            if (isExists) Utils.RCWE_AJAX("0", "每天只能抽奖一次");


            Eyousoft_yhq.Model.ChouJiang info = new Eyousoft_yhq.Model.ChouJiang();
            info.ID = hongbao.ID;
            info.CaoZuoRenID = m.UserID;
            int i = new Random().Next(1000);
            if (i > 700)
            {
                info.JieGuo = ChouJiangJieGuo.中奖;
                info.DianShu = Utils.GetDecimal(getResultMoney(hongbao.HongBaoJinE));

            }
            else
            {
                info.JieGuo = ChouJiangJieGuo.未中奖;
                info.DianShu = 0M;
            }
            int result = new Eyousoft_yhq.BLL.BChouJiang().Insert(info);
            if (result == 1)
            {
                if (info.JieGuo == ChouJiangJieGuo.中奖)
                {
                    Utils.RCWE_AJAX("1", "恭喜中奖", info.DianShu);
                }
                else
                {
                    Utils.RCWE_AJAX("-99", "未中奖，明天再来或分享红包领取奖励", info.DianShu);
                }

            }
            else
            {
                Utils.RCWE_AJAX("0", "操作异常");
            }
            //抽奖
            //返回结果
        }

        /// <summary>
        /// 设置抽奖金额
        /// </summary>
        /// <returns></returns>
        string getResultMoney(decimal hongbaojine)
        {
            int fanwei = new Random().Next(1, 5);
            return (hongbaojine * (fanwei / 100M)).ToString("F2");
        }
        #endregion

        #region 分享
        /// <summary>
        /// 分享链接后红包增值
        /// </summary>
        void HongBaoResult()
        {
            getFxResult();





        }
        /// <summary>
        /// 返回要增值的
        /// </summary>
        /// <param name="JinE"></param>
        /// <returns></returns>
        decimal getResult(decimal JinE)
        {
            int radResult = new Random().Next(100);
            decimal radM = radResult / 1000M;
            return JinE * radM;
        }
        #endregion

        #region 分享获得固定奖励
        /// <summary>
        ///  抽奖
        /// </summary>
        void getFxResult()
        {

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Common.Page.HuiyuanPage.IsLogin(out m);
            if (!isLogin)
            {
                Utils.RCWE_AJAX("0", "请登录后重新操作");
            }



            var hongbao = new Eyousoft_yhq.BLL.BHongBao().GetInfoByUserID(Utils.GetQueryStringValue("huiyuanid")); //判断是否存在红包
            if (hongbao == null) return;

            if (hongbao.HongBaoJinE <= 1M) Utils.RCWE_AJAX("0", "红包被分光啦");


            //判断用户当日是否已经抽奖
            bool isExists = new Eyousoft_yhq.BLL.BChouJiang().Exists(new Eyousoft_yhq.Model.ChouJiang() { CaoZuoRenID = m.UserID, ChouJiangShiJian = DateTime.Now, FangShi = JiangLiFangShi.分享 });
            if (isExists) Utils.RCWE_AJAX("0", "每天分享第一次才可以获得奖励");

            Eyousoft_yhq.Model.ChouJiang info = new Eyousoft_yhq.Model.ChouJiang();
            info.ID = hongbao.ID;
            info.CaoZuoRenID = m.UserID;
            info.JieGuo = ChouJiangJieGuo.未中奖;
            info.DianShu = 1M;
            info.FangShi = JiangLiFangShi.分享;
            int result = new Eyousoft_yhq.BLL.BChouJiang().Insert(info);
            Utils.RCWE_AJAX(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败");
            //抽奖
            //返回结果
        }
        #endregion

        #region ilst to list
        public List<T> IListToList<T>(IList<T> list)
        {
            T[] array = new T[list.Count];
            list.CopyTo(array, 0);
            return new List<T>(array);
        }
        #endregion
    }
}
