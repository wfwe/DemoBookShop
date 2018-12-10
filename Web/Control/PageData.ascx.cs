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
using System.Text;

namespace BookShop.Web.Control
{
    public partial class PageData : System.Web.UI.UserControl
    {
        protected string strHtml = "";//保存所有的数字页码条.

        private int currentPage;//当前页面
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        private int pageCount;//总页数

        public int PageCount//当前页和总页数这个字段的值是有使用该用户控件的aspx页面赋给的。
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            string  categoryId="";
            string orderby = "";
            if (pageCount == 1)//如果只有一页，不需要在出现分页数字
            {
                strHtml = "";
                return;
            }

            int start = currentPage - 5;//起始位置，前提是页面上最多显示10个数字.
            if (start <= 1)
            {
                start = 1;
            }
            int end = start + 9;//计算出终止位置.
            if (end > pageCount)
            {
                end = pageCount;
            }
            //接收类别编号.
            if(!string.IsNullOrEmpty(Request.QueryString["category"]))
            {
                categoryId=Request.QueryString["category"];
            }

            //接收排序依据
            if (!string.IsNullOrEmpty(Request.QueryString["orderby"]))
            {
                orderby = Request.QueryString["orderby"];
            }


            if (currentPage > 1)
            {
                builder.Append(string.Format("<a href=?page={0}&category={1}&orderby={2}>上一页</a>&nbsp;", currentPage - 1, categoryId,Server.UrlEncode(orderby)));
            }



            for (int i = start; i <= end; i++)
            {
                if (i == currentPage)//表示当前页,不要加超链接
                {
                    builder.Append("&nbsp;" + i + "&nbsp;");
                }
                else//给不是当前页的页码加超链接
                {
                    builder.Append(string.Format("&nbsp;<a href=?page={0}&category={1}&orderby={2}>[{0}]</a>", i, categoryId, Server.UrlEncode(orderby)));
                }
            }


            if (currentPage < pageCount)
            {
                builder.Append(string.Format("<a href=?page={0}&category={1}&orderby={2}>下一页</a>&nbsp;", currentPage + 1, categoryId, Server.UrlEncode(orderby)));
            }

            strHtml=builder.ToString();

        }
    }
}