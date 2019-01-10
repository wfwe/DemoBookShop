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
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.Web.admin
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BookShop.Web.Common.WebComm.CheckUser())
            //{
            //    BookShop.Web.Common.WebComm.GoToPage();
            //    return;
            //}
        }
  

        protected void odsAddBook_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                FileUpload fupload = ((FileUpload)dvAddBook.FindControl("FileUpload1"));
                string isbn = ((TextBox)dvAddBook.FindControl("TextBox4")).Text.Trim();
                if (fupload.PostedFile.ContentLength > 10)
                {
                    fupload.PostedFile.SaveAs(Server.MapPath("~/images/BookCovers/") + isbn + ".jpg");
                }
                Response.Write("图书添加成功！");    
             
                //int bookId = Convert.ToInt32(e.ReturnValue);
               


            }
        }

        protected void hh() {
               
             
        }


        protected void dvAddBook_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (!IsValid)
                e.Cancel = true;//通过验证
            string Title = e.Values["Title"].ToString();
            Response.Write(Title);

            

        }

        protected void dvAddBook_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
           Response.Write(e.NewValues["Title"]);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FileUpload fupload = ((FileUpload)dvAddBook.FindControl("FileUpload1"));
            string isbn = ((TextBox)dvAddBook.FindControl("TextBox4")).Text.Trim();
            if (fupload.PostedFile.ContentLength > 10)
            {
                fupload.PostedFile.SaveAs(Server.MapPath("~/images/BookCovers/") + isbn + ".jpg");
            }
            Response.Write("图书添加成功！"); 
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dvAddBook_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
}
