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
    public partial class ListOfBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BookShop.Web.Common.WebComm.CheckUser())
            //{
            //    BookShop.Web.Common.WebComm.GoToPage();
            //    return;
            //}
        }

        protected void gvBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


                LinkButton lb = e.Row.FindControl("lnkbtnDelete") as LinkButton;

                lb.Attributes.Add("onclick", "return confirm('确认删除吗？')");
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
    }
}
