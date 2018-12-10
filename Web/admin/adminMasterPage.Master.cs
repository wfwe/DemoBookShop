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
using System.Collections.Generic;

namespace BookShop.Web.admin
{
    public partial class adminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BookShop.Web.Common.WebComm.CheckUser())
            //{
            //    BookShop.Web.Common.WebComm.GoToPage();
            //    return;
            //}
            if (!Page.IsPostBack)
            {
                BLL.SysFunManager sysfunManager = new BookShop.BLL.SysFunManager();
                List<Model.SysFun> list = sysfunManager.GetModelList("");//获取所有的菜单数据项
                if (list != null)
                {

                    BindTreeView("mainFrame", list);
                }
            }
        }

        /// <summary>
        /// 将菜单绑定到TreeView.
        /// </summary>
        /// <param name="target">菜单项所链接地址打开的方式</param>
        /// <param name="list">数据源</param>
        protected void BindTreeView(string target, List<Model.SysFun> list)
        {
            this.tvAdmin.Nodes.Clear();
            this.tvAdmin.Font.Name = "黑体";
            this.tvAdmin.Font.Size = FontUnit.Parse("9");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ParentNodeId == 0)//表示绑定根菜单.
                {
       
                    string nodeID = list[i].NodeId.ToString();
                    string text = list[i].DisplayName;
                    //string url=list
                    //string imageUrl = list[i].ImageUrl;
                   // int pemissionID = list[i].PermissionID;//菜单权限编号

                    //BLL.UserBLL bll = new BLL.UserBLL();
                    //ArrayList arrayList = bll.GetPermissionIDList(Convert.ToInt32(Session["UserID"]));//根据用户的编号，得到用户的权限编号

                    //在用户所具有的权限编号中查找指定的菜单的权限编号。
                   // if (arrayList.Contains(pemissionID) || pemissionID == -1)
                  //  {
                        TreeNode node = new TreeNode();
                        node.Value = nodeID;
                        node.Text = text;
                       // node.ImageUrl = "../" + imageUrl;
                        node.Expanded = true;
                        this.tvAdmin.Nodes.Add(node);
                        BindChildTreeNodes(Convert.ToInt32(nodeID), target, node.ChildNodes, list);
                    //}
                }
            }


        }

        protected void BindChildTreeNodes(int nodeID, string target, TreeNodeCollection collections, List<Model.SysFun> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ParentNodeId == nodeID)
                {
                    string nID = list[i].NodeId.ToString();
                    string text = list[i].DisplayName;
                   // string imageUrl = list[i].ImageUrl;
                    string url = list[i].NodeURL;
                    //int pemissionID = list[i].PermissionID;
                   // BLL.UserBLL bll = new BLL.UserBLL();
                   // ArrayList arrayList = bll.GetPermissionIDList(Convert.ToInt32(Session["UserID"]));
                    //if (arrayList.Contains(pemissionID) || pemissionID == -1)
                    //{
                        TreeNode node = new TreeNode();
                        node.Value = nID;
                        node.Text = text;
                        node.NavigateUrl = url;
                        node.Target = target;
                        //node.ImageUrl = "../" + imageUrl;
                        collections.Add(node);//将当前的子节点添加到父节点的集合中。
                        BindChildTreeNodes(Convert.ToInt32(nID), target, node.ChildNodes, list);
                    //}
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
