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
    public partial class BookList : System.Web.UI.Page
    {
        protected string currentPage = string.Empty;//当前页码
        protected string orderPrice = "价格↑";//价格排序按钮的文本值
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//IsPostBack：如果为true,表示是以post方式请求页面，如果为false,表示的是以get方式请求页面.
            {
                BindRepeaterBookList(1);
            }
            //上一页html按钮
            if (!string.IsNullOrEmpty(Request.Form["btnPre"]))
            {
                int Cpage = Convert.ToInt32(Request.Form["hiddenCurrentPage"]);
                BindRepeaterBookList(--Cpage);
            }
            //下一页HTML按钮
            if (!string.IsNullOrEmpty(Request.Form["btnNext"]))
            {
                int Cpage = Convert.ToInt32(Request.Form["hiddenCurrentPage"]);
                BindRepeaterBookList(++Cpage);
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
                BindRepeaterBookList(1);
            }
            else if (txt == "价格↓")
            {
                orderPrice = "价格↑";
                ViewState["orderby"] = "UnitPrice desc";
                BindRepeaterBookList(1);
            }
        }


        /// <summary>
        /// 绑定Repeater图书列表
        /// </summary>
        protected void BindRepeaterBookList(int page)
        {
            int categoryId=0;//类别编号
            int pageCount=0;//总页数
            //接收类别编号
            if(!int.TryParse(Request.QueryString["category"],out categoryId))
            {
                categoryId=0;
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
            currentPage = page.ToString();//将当前页码值给currentPage,然后在前台隐藏域中获取该变量的值
          //  this.RepeaterList.DataSource = bll.GetModelList("");

            string order = string.Empty;
            if (ViewState["orderby"] != null)
            {
                order = ViewState["orderby"].ToString();
            }
          //  this.RepeaterList.DataSource = bll.GetPageList(page, 10, categoryId);//获取到了分页的数据
            this.RepeaterList.DataSource = bll.GetPageList(page, 5, categoryId, order);//根据传递过来的页码值,获取当前页码对应的数据。
            this.lblPageCount.Text = pageCount.ToString();
            this.RepeaterList.DataBind();
            this.lblCurrentPage.Text = page.ToString();

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
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void preBtn_Click(object sender, EventArgs e)
        {
            //int Cpage = Convert.ToInt32(this.lblCurrentPage.Text);//得到当前页
            int Cpage =Convert.ToInt32( Request.Form["hiddenCurrentPage"]);
            BindRepeaterBookList(--Cpage);//获取上一页的数据
        }
        //下一页
        protected void nextBtn_Click(object sender, EventArgs e)
        {
           // int Cpage = Convert.ToInt32(this.lblCurrentPage.Text);//得到当前页
            int Cpage = Convert.ToInt32(Request.Form["hiddenCurrentPage"]);
            BindRepeaterBookList(++Cpage);//获取下一页的数据
        }

        /// <summary>
        /// 跳转到指定的页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageBtn_Click(object sender, EventArgs e)
        {
            int pageNum = 0;
            if (int.TryParse(this.GoPageNum.Text, out pageNum))
            {
                BindRepeaterBookList(pageNum);
            }
            else
            {
                this.GoPageNum.Text = this.lblCurrentPage.Text;
            }
        }

        /// <summary>
        /// 按照出版日期进行排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PublishData_Click(object sender, EventArgs e)
        {
            if (this.PublishData.Text == "出版日期↑")
            {
                this.PublishData.Text = "出版日期↓";
                ViewState["orderby"] = "PublishDate asc";
            }
            else if (this.PublishData.Text == "出版日期↓")
            {
                this.PublishData.Text = "出版日期↑";
                ViewState["orderby"] = "PublishDate desc";
            }

            BindRepeaterBookList(1);
        }
    }
}
