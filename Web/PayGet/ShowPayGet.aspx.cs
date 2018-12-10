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

namespace BookShop.Web.PayGet
{
    public partial class ShowPayGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["out_trade_no"] != null && Request.QueryString["returncode"] != null && Request.QueryString["total_fee"] != null && Request.QueryString["sign"] != null)
            {
                string out_trade_no = Request.QueryString["out_trade_no"];//订单号.
                string returncode = Request.QueryString["returncode"];
                string total_fee = Request.QueryString["total_fee"];
                string sign = Request.QueryString["sign"];
                string key = ConfigurationManager.AppSettings["key"].ToString();
                string mysign = common.WebComm.CreateMd5(out_trade_no + returncode + total_fee+key).ToLower();//数字签名

                if (mysign == sign)//对数字签名进行比较
                {
                    if (returncode == "ok")
                    {
                        BLL.OrdersManager bll = new BookShop.BLL.OrdersManager();
                        Model.Orders model = bll.GetModel(out_trade_no);
                        if (model != null)
                        {
                            model.State = 1;//如果订单存在，修改该订单的状态，1：表示已付款未发货.
                            bll.Update(model);
                            Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode("支付成功,等待发货!") + "&url=OrderDetail.aspx?orderId=" + out_trade_no+"&txt="+Server.UrlEncode("查看订单信息!"));
                        }
                    }

                }

            }

        }
    }
}
