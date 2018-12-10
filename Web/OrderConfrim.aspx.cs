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
using System.Text;

namespace BookShop.Web
{
    public partial class OrderConfrim : System.Web.UI.Page
    {
        protected Model.User userModel = null;
        protected string strHtml = string.Empty;
        protected decimal totleMoney = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (common.WebComm.CheckSession())
            {
                userModel = (Model.User)Session["user"];
             
            }
            else
            {
                common.WebComm.GoToPage();
            }

            if (!IsPostBack)
            {
                BindCartInfo();//获取购物车中的商品信息.
            }
            if (IsPostBack)
            {
                CreateOrder();//下订单.
            }

            
        }


        /// <summary>
        /// 下订单
        /// </summary>
        protected void CreateOrder()
        {
            if (checkOrderInfo())//如果信息填写完整开始下订单.
            {

                //1:下订单（将购物信息放入订单表中）存储过程。
                string orderNum = DateTime.Now.ToString("yyyyMMddHHmmssfff") + userModel.Id;//订单号.
                string address = string.Format("姓名:{0},地址:{1},电话:{2},邮编:{3}", Request.Form["txtName"], Request.Form["txtAddress"], Request.Form["txtPhone"], Request.Form["txtPostCode"]);

                BLL.OrdersManager orderBll = new BookShop.BLL.OrdersManager();
                decimal totalMoney=orderBll.GetTotalMoney(orderNum, address, userModel.Id);
              
                
                //2:开始向支付宝发送数据，进行支付.
                if (Request.Form["zfPay"] == "zfb")
                {
                    PayGet.PayProcess process = new BookShop.Web.PayGet.PayProcess("图书", "网上书城", orderNum, totalMoney.ToString());

                    string url = process.GoPayPage();
                    Response.Redirect(url);//向支付宝发出请求.
                }
            }
        }


        /// <summary>
        /// 校验用户填写的收获人地址信息是否完整
        /// </summary>
        /// <returns></returns>
        protected bool checkOrderInfo()
        {
            if (Request.Form["txtName"] != null && Request.Form["txtAddress"] != null && Request.Form["txtPhone"] != null && Request.Form["txtPostCode"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void BindCartInfo()
        {
            BLL.CartManager carBll = new BookShop.BLL.CartManager();
            List<Model.Cart>list=carBll.GetModelList("UserId=" + userModel.Id);
            if (list.Count<1)
            {
                Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode("没有商品项，无法下订单") + "&url=/BookList.aspx" + "&txt=" + Server.UrlEncode("返回商品列表"));
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                foreach (Model.Cart model in list)
                {

                    builder.Append("<tr class=\"align_Center\">");
                 
                  builder.Append("<td style=\"PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 5px\">"+model.Book.Id+"</td>");
                 builder.Append(" <td class=align_Left><a onmouseover=\"\" onmouseout=\"\" onclick=\"\" href='BookDetail.aspx?id="+model.Book.Id+"' target=\"_blank\" >"+model.Book.Title+"</a>   </td>");
                   
                  builder.Append("<td><span class=\"price\">￥"+model.Book.UnitPrice.ToString("0.00")+"</span></td>");
                  builder.Append("<td>"+model.Count+"</td>  </tr>");
         
                     totleMoney=totleMoney+(model.Count*model.Book.UnitPrice);
              
                }
                strHtml = builder.ToString();
            }
        }
    }
}
