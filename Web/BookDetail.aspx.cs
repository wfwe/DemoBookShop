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
using System.Text;

namespace BookShop.Web
{
    public partial class BookDetail : System.Web.UI.Page
    {
        protected string strHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = 0;
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    Response.Redirect("BookList2.aspx");
                }
                else
                {
                    BLL.BookManager bll = new BookShop.BLL.BookManager();
                   Model.Book model= bll.GetModel(id);//根据书的编号，查找该书.
                   if (model != null)
                   {
                       StringBuilder builder = new StringBuilder();
                       builder.Append("<table border='1' >");
                       builder.Append("<tr><th width='30px'>书名:</th><td>"+model.Title+"</td></tr>");
                       builder.Append("<tr><th>封面:</th><td><img src=/Images/BookCovers/" +model.ISBN+ ".jpg/></td></tr>");
                       builder.Append("<tr><th>作者:</th><td>" + model.Author+ "</td></tr>");
                       builder.Append("<tr><th>出版日期::</th><td>" + model.PublishDate.ToShortDateString() + "</td></tr>");
                       builder.Append("<tr><th>单价:</th><td>&yen;" + model.UnitPrice.ToString("0.00") + "<a href='cart.aspx?id="+model.Id+"'><img src='/Images/sale.gif' border='0'/></a></td></tr>");
                       builder.Append("<tr><th>简介:</th><td>" + model.ContentDescription + "</td></tr>");
                       builder.Append("<tr><th>目录::</th><td>" + model.TOC + "</td></tr>");
                       builder.Append("</table>");
                       strHtml = builder.ToString();
                   }
                   else
                   {
                       Response.Redirect("/showinfo.aspx?msg="+Server.UrlEncode("图书部存在")+"&url=/BookList2.aspx"+"&txt="+Server.UrlEncode("图书列表页面"));
                   }
                }
            }
            else
            {
                Response.Redirect("BookList2.aspx");
            }
        }
    }
}
