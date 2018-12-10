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
    public partial class ListAllUsers : System.Web.UI.Page
    {
        BLL.UserManager userManager=new BookShop.BLL.UserManager();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BookShop.Web.Common.WebComm.CheckUser())
            //{
            //    BookShop.Web.Common.WebComm.GoToPage();
            //    return;
            //}
        }

      

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "resetpwd")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Model.User resetUser = userManager.GetModel(id);
                if (resetUser != null)
                {
                    resetUser.LoginPwd = common.WebComm.CreateMd5("123456");
                    userManager.Update(resetUser);
                    
                }
                else
                {
                  
                }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                LinkButton lb = e.Row.FindControl("lnkbtnDelete") as LinkButton;
                lb.Attributes.Add("onclick", "return confirm('删除用户会将与此用户相关的订单一起删除，确认删除吗？')");

                LinkButton lbReset = e.Row.FindControl("LinkButton1") as LinkButton;
                if (lbReset != null)
                    lbReset.Attributes.Add("onclick", "return confirm('确认要重置密码吗？')");


            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
        }
    }
}
