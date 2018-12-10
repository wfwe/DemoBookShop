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

namespace BookShop.Web
{
    public partial class showinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                this.Label1.Text = Request.QueryString["msg"];
            }
            else
            {
                this.Label1.Text = "暂无信息!";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["url"]))
            {
                this.HyperLink1.NavigateUrl = Request.QueryString["url"];//跳转到的页面的URL路径

            }
            else
            {
                this.HyperLink1.NavigateUrl = "BookList.aspx";
            }

            if (!string.IsNullOrEmpty(Request.QueryString["txt"]))
            {
                this.HyperLink1.Text = Request.QueryString["txt"];
            }
            else
            {
                this.HyperLink1.Text = "图书列表";
            }

        }
    }
}
