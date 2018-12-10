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
    public partial class PayProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["orderid"]))
            {
                BLL.OrdersManager bll = new BookShop.BLL.OrdersManager();
                Model.Orders model = bll.GetModel(Request.QueryString["orderid"]);
                if (model != null)
                {
                    if (model.State == 1)
                    {
                        Response.Write("以付款，无需重新付款");
                    }
                    else
                    {
                        PayGet.PayProcess process = new BookShop.Web.PayGet.PayProcess("图书", "网上书城", Request.QueryString["orderid"], model.TotalPrice.ToString());

                        string url = process.GoPayPage();
                        Response.Redirect(url);//向支付宝发出请求.
                    }

                }
            }
        }
    }
}
