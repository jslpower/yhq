using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eyousoft_yhq.Web.AppPage.weixin
{
    public partial class MenuView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 绑定微信菜单树
                TreeDeptList.Nodes.Clear();
                TreeNode node = new TreeNode();
                node.Text = " 微信菜单";
                node.ImageUrl = "/images/base.gif";
                node.Expanded = true;
                node.NavigateUrl = "javascript:void(0)";
                TreeDeptList.Nodes.Add(node);
                TreeDeptList.ShowLines = true;
                node = null;
                Bind_Tv();
                #endregion
            }
        }
        private void Bind_Tv()
        {
            var menulist = BsendMsg.WeiXin.GetMenu();
            if (menulist != null)
            {
                TreeNode tn;
                foreach (var row in menulist)
                {
                    tn = new TreeNode();//建立一个新节点
                    //tn.Value = row.key.ToString();
                    tn.Text = row.name.ToString();
                    tn.ImageUrl = "/images/folderopen.gif";
                    #region 子菜单
                    var childMenu = row.sub_button;
                    foreach (var subrow in childMenu)
                    {
                        TreeNode subTN = new TreeNode();//建立一个新节点
                        //subTN.Value = subrow.key.ToString();
                        subTN.Text = subrow.name.ToString();
                        subTN.ImageUrl = "/images/page.gif";
                        tn.ChildNodes.Add(subTN);
                    }
                    #endregion
                    TreeDeptList.Nodes.Add(tn);//将该节点加入到TreeView中                    
                }
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BsendMsg.WeiXin.CreateMenu();
            Response.Redirect("MenuView.aspx");
        }
    }
}
