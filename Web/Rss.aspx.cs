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
    public partial class Rss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.BookManager bll = new BookShop.BLL.BookManager();
            this.rssRepeater.DataSource = bll.GetModelList("");
            this.rssRepeater.DataBind();
        }
    }
}
