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

namespace BookShop.Web.admin
{
    public partial class adminlogin : System.Web.UI.Page
    {
        public string Msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgb_Cancel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            BLL.UserManager userManager = new BookShop.BLL.UserManager();

            string loginId = txtLoginId.Text.Trim();
            string pwd = txtLoginPwd.Text.Trim();
            string msg;
            Model.User loginuser;
            if (userManager.AdminLogin(loginId, pwd, out msg, out loginuser))
            {
                //返回true表示登录成功!
                Session["adminUser"] = loginuser;
                Response.Redirect("~/admin/listallusers.aspx");

            }
            else
            {
                //登录失败!
                Msg = "用户名密码错误!!";
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtLoginId.Text = "";
            txtLoginPwd.Text = "";
        }
    }
}
