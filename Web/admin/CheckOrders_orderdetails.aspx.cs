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
using BookShop.BLL;

namespace BookShop.Web.admin
{
    public partial class CheckOrders_orderdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            decimal totle = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int count = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                decimal price = Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text);
                GridView1.Rows[i].Cells[5].Text = (count * price).ToString();
                totle += (count * price);


            }
            lbTotle.Text = totle.ToString("0.00");
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {

            OrdersManager orderManager = new OrdersManager();
            string orderId = Request.QueryString["id"];
            Model.Orders oneOrder = orderManager.GetModel(orderId);
            if (oneOrder == null)
            {

                return;
            }
            else
            {
                if (oneOrder.State ==2)
                {
                    Response.Write("此定单已经发货，不要重复操作！");

                    return;
                }
                oneOrder.State = 2;
                orderManager.Update(oneOrder);
                Response.Write("已发货！");
               
            }
        }
    }
}
