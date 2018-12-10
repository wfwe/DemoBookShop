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
    public partial class BookList2 : System.Web.UI.Page
    {
   
        protected string orderPrice = "价格↑";//价格排序按钮的文本值
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterBookList();
            }
        
            //单击了“价格排序”按钮
            if (!string.IsNullOrEmpty(Request.Form["UntpriceDesc"]))
            {
                OrderUnitPrice(Request.Form["UntpriceDesc"]);//按照价格进行排序
            }
            else
            {
                //第一次访问页面时没有值，但是单击完了“价格”排序按钮以后，该ViewState有值了。所以，当用户单击了分页按钮，导致回发，这时该ViewState有值.
                if (ViewState["orderby"] != null)
                {
                    if (ViewState["orderby"].ToString() == "UnitPrice asc")
                    {
                        orderPrice = "价格↓";
                    }
                }
            }
        }


        /// <summary>
        /// 按照价格进行排序
        /// </summary>
        /// <param name="txt">接收到的“价格”排序按钮的文本值</param>
        protected void OrderUnitPrice(string txt)
        {
            if (txt == "价格↑")//表示升序排序
            {
                orderPrice = "价格↓";
                ViewState["orderby"] = "UnitPrice asc";//保留排序依据.
                BindRepeaterBookList();
            }
            else if (txt == "价格↓")
            {
                orderPrice = "价格↑";
                ViewState["orderby"] = "UnitPrice desc";
                BindRepeaterBookList();
            }
        }


        /// <summary>
        /// 绑定Repeater图书列表
        /// </summary>
        protected void BindRepeaterBookList()
        {
            int categoryId=0;//类别编号
            int pageCount=0;//总页数
            int page = 1;//表示当前页
            //接收类别编号
            if(!int.TryParse(Request.QueryString["category"],out categoryId))
            {
                categoryId=0;
            }
            //接收URL传递过来的当前页码值.
            if (!int.TryParse(Request.QueryString["page"], out page))
            {
                page = 1;
            }



            BLL.BookManager bll = new BookShop.BLL.BookManager();
            pageCount=bll.GetPageCount(10, categoryId);//获取总页数

            if (page <= 1)
            {
                page = 1;
            }
            if (page > pageCount)
            {
                page = pageCount;
            }

            this.PageData2.PageCount = pageCount;
            this.PageData2.CurrentPage = page;
        
          //  this.RepeaterList.DataSource = bll.GetModelList("");

            string order = string.Empty;
            //接收排序依据
            if (!string.IsNullOrEmpty(Request.QueryString["orderby"]))
            {
                if (Request.QueryString["orderby"] == "PublishDate asc")
                {
                    this.PublishData.Text = "出版日期↓";
                  
                    //ViewState["orderby"] = "PublishDate asc";
                }
                else if (Request.QueryString["orderby"] == "PublishDate desc")
                {
                    this.PublishData.Text = "出版日期↑";
                    // ViewState["orderby"] = "PublishDate desc";
                   
                }

                order = Request.QueryString["orderby"];
            }

            if (ViewState["orderby"] != null)
            {
                order = ViewState["orderby"].ToString();
            }
          //  this.RepeaterList.DataSource = bll.GetPageList(page, 10, categoryId);//获取到了分页的数据
            this.RepeaterList.DataSource = bll.GetPageList(page, 10, categoryId, order);
            this.RepeaterList.DataBind();
         

        }

        /// <summary>
        /// 将图书内容简介进行截取.
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected string CutString(string txt, int length)
        {
            if (txt.Length > length)
            {
                return txt.Substring(0, length) + "......";
            }
            else
            {
                return txt;
               }
        }

        /// <summary>
   

        /// <summary>
        /// 按照出版日期进行排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PublishData_Click(object sender, EventArgs e)
        {
            string order = "";
            if (this.PublishData.Text == "出版日期↑")
            {
                this.PublishData.Text = "出版日期↓";
                order = "PublishDate asc";
                //ViewState["orderby"] = "PublishDate asc";
            }
            else if (this.PublishData.Text == "出版日期↓")
            {
                this.PublishData.Text = "出版日期↑";
               // ViewState["orderby"] = "PublishDate desc";
                order = "PublishDate desc";
            }

           
            string url = "";

            //判断用户有没有选择图书的类别。
            if (!string.IsNullOrEmpty(Request.QueryString["category"]))
            {
                url = string.Format("/BookList2.aspx?orderby={0}&category={1}", Server.UrlEncode(order), Request.QueryString["category"]);
            }
            else
            {
                url = "/BookList2.aspx?orderby="+Server.UrlEncode(order);
            }



            Response.Redirect(url);

         

            //BindRepeaterBookList();
        }
    }
}
