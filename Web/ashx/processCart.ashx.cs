using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class processCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["action"]))
            {
                string action = context.Request.Form["action"];
                if (action == "change")//更新商品数量
                {
                    int pk, bookId, count;
                    if (!int.TryParse(context.Request.Form["pk"], out pk))
                    {
                        context.Response.Write("no-参数错误!");
                        return;
                    }
                    if (!int.TryParse(context.Request.Form["count"], out count))
                    {
                        context.Response.Write("no-参数错误!");
                        return;
                    }
                    if (!int.TryParse(context.Request.Form["bookId"], out bookId))
                    {
                        context.Response.Write("no-参数错误!");
                        return;
                    }
                    BLL.BookManager bookBll = new BookShop.BLL.BookManager();
                    Model.Book modelBook=bookBll.GetModel(bookId);
                    if (modelBook != null)//看一下该书是否存在
                    {
                        BLL.CartManager cartBll = new BookShop.BLL.CartManager();
                        Model.Cart cartModel = cartBll.GetModel(pk);
                        if (cartModel != null)//根据主键查找该购物车中商品项
                        {
                            cartModel.Count = count;
                            cartBll.Update(cartModel);//完成数量的更新
                            context.Response.Write("yes");
                        }
                        else
                        {
                            context.Response.Write("no");
                            return;
                        }
                    }
                    else
                    {
                        context.Response.Write("no");
                    }

                }
                    //删除一条记录
                else if (action == "delete")
                {
                    if(!string.IsNullOrEmpty(context.Request.Form["pk"]))
                    {
                          int pkId=0;
                        if(!int.TryParse(context.Request.Form["pk"],out pkId))
                        {
                            context.Response.Write("no");
                            return;
                        }
                     BLL.CartManager bllCart = new BookShop.BLL.CartManager();
                       bllCart.Delete(pkId);
                       context.Response.Write("yes");
                    }
                }

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
