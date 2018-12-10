using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BookShop.Web
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                BLL.CategoryManager bll = new BookShop.BLL.CategoryManager();
                List<Model.Category>list=bll.GetModelList("");
                TreeNode node = null;
                if (list != null)
                {
                    foreach (Model.Category model in list)
                    {
                        node = new TreeNode();
                        node.Text = model.Name;
                        node.NavigateUrl = "/BookList.aspx?category="+model.Id;
                        this.tvCategory.Nodes.Add(node);
                    }
                }

                node = new TreeNode();
                node.Text = "全部类别";
                node.NavigateUrl = "/BookList.aspx";
                this.tvCategory.Nodes.AddAt(0, node);
         }
        }
    }
}
