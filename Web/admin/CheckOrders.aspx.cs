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

namespace BookShop.Web.admin
{
    public partial class CheckOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string ConvertState(string stateId)
        {
            if (stateId == "1")
            {
                return "已发货";
            }
            else
            {
                return "未发货";
            }
        }
        protected string ConvertPic(string stateId)
        {
            if (stateId == "1")
            {
                return @"/images/sended.ico";
            }
            else
            {
                return @"/images/nosend.ico";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
