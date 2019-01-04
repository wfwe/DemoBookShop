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
using BookShop.Web.common;

namespace BookShop.Web.Control
{
    public partial class UserLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //读取Cookie文件
            if (Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null)
            {
                string CookieName = Request.Cookies["cp1"].Value;//Cookie文件中存储的用户名
                string CookiePass = Request.Cookies["cp2"].Value;//存储的是密码，加密后的密码
                BLL.UserManager userBll=new BookShop.BLL.UserManager();

                Model.User model = userBll.GetModel(CookieName);//根据用户名读取用户的信息
                if (model != null && model.UserState.Name == "正常")
                {
                    string pass = model.LoginPwd;//取出数据库中的密码
                    //从Cookie文件中的密码取出前两个字符对从数据库中取出的密码进行加密（采用相同的加密算法）
                    string enctryPass = Enctry(pass, CookiePass.Substring(0,2));
                    if (CookiePass == enctryPass)
                    {
                        Session["user"] = model;//自动登录，不要忘记添加Session
                        if (!string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                        {
                            Response.Redirect(Request.QueryString["returnUrl"]);
                        }
                        else
                        {

                            Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode("登录成功!") + "&url=/cart.aspx" + "&txt=" + Server.UrlEncode("首页"));
                        }
                    }
                    else//如果是else，说明用户修改了自己的密码
                    {
                        Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
                        return;
                    }

                }
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["loginId"]))
                {
                    this.txtLoginId.Text = Request.QueryString["loginId"];
                }
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            string txtName = this.txtLoginId.Text;
            string txtPass = this.txtLoginPwd.Text;
            BLL.UserManager bll = new BookShop.BLL.UserManager();
            string msg=string.Empty;//记录登录过程的一些信息。
            Model.User model=null;
           bool b= bll.CheckLogin(txtName, txtPass, out msg,out model);//判读用户的用户名与密码
           if (b)
           {
               Session["user"] = model;//创建Session
               //如果该条件成立，说明用户之间访问了受保护页

               if (this.cbAutoLogin.Checked)//如果该条成立表示用户选择“记住我”
               {
                   HttpCookie cookName = new HttpCookie("cp1", model.LoginId);
                   HttpCookie cookPass = new HttpCookie("cp2",Enctry(model. LoginPwd));//创建Cookie
                   cookName.Expires = DateTime.Now.AddDays(3);
                   cookPass.Expires = DateTime.Now.AddDays(3);//设置过期时间
                   Response.Cookies.Add(cookName);
                   Response.Cookies.Add(cookPass);//输出到浏览器端

               }

               if (!string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
               {
                   Response.Redirect(Request.QueryString["returnUrl"]);
               }
               else
               {

                   Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode(msg) + "&url=/cart.aspx" + "&txt=" + Server.UrlEncode("首页"));
               }
           }
           else
           {
               Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode(msg) + "&url=/login.aspx?loginId="+txtName + "&txt=" + Server.UrlEncode("登录页"));
           }

        }


        /// <summary>
        /// 对写入到Cookie文件中的密码进行加密
        /// 设数据库中存储的用户密码为:P
            ///随机产生一个两位的字母:S
      /// 我们写入cookie的这个加密后的密码为:  S+md5(S+md5(p))
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        protected string Enctry(string pass)
        {
            return Enctry(pass, null);
        }

        protected string Enctry(string pass, string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                Random random = new Random();
                 str = ((char)random.Next(65, 91)).ToString() + ((char)random.Next(65, 91)).ToString();//随机产生两个字母
            }
            return str + WebComm.CreateMd5((str + WebComm.CreateMd5(pass)));
        }

        protected void btnRegister_Click(object sender, ImageClickEventArgs e)
        {

        }

      
    }
}