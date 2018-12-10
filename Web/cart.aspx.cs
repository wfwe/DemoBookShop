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

namespace BookShop.Web
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (common.WebComm.CheckSession())
                {
                    AddCart();//向购物车添加商品
                    BindRepeater();//获取购物车中商品.

                }
                else
                {
                    common.WebComm.GoToPage();
                    return;
                }
            }

        }

        /// <summary>
        /// 取出购物车中的商品项.
        /// </summary>
        protected void BindRepeater()
        {
            BLL.CartManager bll = new BookShop.BLL.CartManager();
            this.RepeaterCart.DataSource=bll.GetModelList("UserId="+((Model.User)Session["user"]).Id);//用户只能查看自己放在购物车中的商品项.
            this.RepeaterCart.DataBind();
        }
        /// <summary>
        /// 向购物车中添加商品信息。
        /// </summary>
        protected void AddCart()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int bookId = 0;
                if (!int.TryParse(Request.QueryString["id"], out bookId))
                {
                    Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode("参数错误") + "&url=BookList.aspx" + "&txt=" + Server.UrlEncode("返回图书列表"));
                }
                else
                {
                    BLL.BookManager bll = new BookShop.BLL.BookManager();
                  Model.Book model= bll.GetModel(bookId);//根据传递过来的书的编号查找该书.
                  if (model != null)
                  {
                      BLL.CartManager cartBll = new BookShop.BLL.CartManager();
                      int userId=((Model.User)Session["user"]).Id;//得到了当前登录用户的编号.
                      Model.Cart cartModel=cartBll.GetModel(model.Id, userId);//根据用户的编号，与书的编号，找出购物车中的商品项.
                      if (cartModel == null)//如果该条件成立，向购物车表中插入一条记录
                      {
                          Model.Cart ModelCart = new BookShop.Model.Cart();
                          ModelCart.User = (Model.User)Session["user"];
                          ModelCart.Book = model;
                          ModelCart.Count = 1;
                          cartBll.Add(ModelCart);
                      }
                      else//更新该商品项的数量
                      {
                          cartModel.Count = cartModel.Count + 1;
                          cartBll.Update(cartModel);

                      }
                  }
                  else
                  {
                      Response.Redirect("/showinfo.aspx?msg=" + Server.UrlEncode("该书不存在") + "&url=BookList.aspx" + "&txt=" + Server.UrlEncode("返回图书列表"));
                  }

                }
            }
        }
    }
}
