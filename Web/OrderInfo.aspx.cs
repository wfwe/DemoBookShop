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
    public partial class OrderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (common.WebComm.CheckSession())
            {
                BLL.OrdersManager bll = new BookShop.BLL.OrdersManager();
                //根据用户的编号，获取用户已有的订单信息
                List<Model.Orders>list=bll.GetModelList("UserId=" + ((Model.User)Session["user"]).Id);
                this.rptOrderInfo.DataSource = list;
                this.rptOrderInfo.DataBind();
            }
            else
            {
                common.WebComm.GoToPage();
            }
        }

        /// <summary>
        /// 判断用户的状态
        /// </summary>
        /// <param name="sate"></param>
        /// <returns></returns>
        protected string GetOrderState(int state)
        {
            if (state == 0)
            {
                return "<a href='#' onclick='OnGoPay(this)'>未付款</a>";
            }
            else if (state == 1)
            {
                return "以付款，未发货";
            }
            else
            {
                return "以付款，以发货";
            }
        }
    }
}
