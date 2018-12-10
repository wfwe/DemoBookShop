using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BookShop.Web
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected Model.Orders orderModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["orderId"]))
            {
                BLL.OrdersManager orderBll = new BookShop.BLL.OrdersManager();
                 orderModel=orderBll.GetModel(Request.QueryString["orderId"]);
                if (orderModel != null)//判断该订单是否存在
                {
                    BLL.OrderBookManager orderBookBll = new BookShop.BLL.OrderBookManager();
                    List<Model.OrderBook>list=orderBookBll.GetModelList("OrderID='" + Request.QueryString["orderId"]+"'");//根据订单号获取订单的详细信息;注意 给接收到的订单号加上  '  ' （单引号）

                    this.rptDetails.DataSource = list;
                    this.rptDetails.DataBind();
                }
            }
        }

        /// <summary>
        /// 判读订单的状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string GetState(int state)
        {
            if (state == 0)
            {
                return "未付款，未发货!";
            }
            else if (state == 1)
            {
                return "已付款，未发货!";
            }
            else
            {
                return "已付款，已发货!";
            }
        }
    }
}
