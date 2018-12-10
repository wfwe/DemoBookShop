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

namespace BookShop.Web.member
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 完成注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImage_Click(object sender, ImageClickEventArgs e)
        {
           
            if (!Page.IsValid || !CheckCode())//如果前端的服务端验证控件全部通过验证，那么IsValid:为true.  否则为false.
            {
                return;
            }
            else
            {
                Model.User model = new BookShop.Model.User();
                model.LoginId = this.txtName.Text;//用户名
                model.LoginPwd = this.txtPass.Text;
                model.Mail = this.txtEmail.Text;
                model.Name = this.txtTrueName.Text;
                model.Phone = this.txtPhone.Text;
                model.Address = this.txtAddress.Text;
                model.UserState.Id = 1;//可用的.
                string msg = "";
                BLL.UserManager bll = new BookShop.BLL.UserManager();
                int i = bll.Add(model, out msg);
                if (i > 0)
                {
                    Session["user"] = model;//如果用户注册成功，不需要重新登录.
                    Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode(msg) + "&url=/Default.aspx" + "&txt=" + Server.UrlEncode("首页"));

                }
                else
                {
                    Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode(msg) + "&url=/register.aspx" + "&txt=" + Server.UrlEncode("注册页面"));
                }

            }



        }
        /// <summary>
        /// 对验证码进行校验，不考虑大小写.
        /// </summary>
        /// <returns></returns>
        protected bool CheckCode()
        {
            if (Session["vCode"] != null)
            {
                string code = Session["vCode"].ToString();
                string txtCode = this.txtCode.Text;
                if (code.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
