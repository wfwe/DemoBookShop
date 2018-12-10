using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AutoComplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["term"]))
            {
                string term = context.Request.QueryString["term"];//接收发过来的需要搜索的数据.
                BLL.BookManager bll = new BookShop.BLL.BookManager();
                List<Model.Book>bookList=bll.GetLikeList(term);//获取相应的图书
                List<string> list = new List<string>();
                foreach (Model.Book model in bookList)
                {
                    list.Add(model.Title);//将书名放在一个新的集合中.
                }

                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                string str = js.Serialize(list.ToArray());
             context.Response.Write(str);//将list集合中保存的书名转成数组，并且声称Json格式返回.


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
