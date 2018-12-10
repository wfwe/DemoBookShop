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

namespace BookShop.Web.admin
{
    public partial class AddBooksCatagory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BookShop.Web.Common.WebComm.CheckUser())
            //{
            //    BookShop.Web.Common.WebComm.GoToPage();
            //    return;
            //}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BLL.CategoryManager category=new BookShop.BLL.CategoryManager();

            Model.Category cat = new BookShop.Model.Category();
            cat.Name = txtCateGory.Text;
            category.Add(cat);
            Response.Write("添加成功！");            
            txtCateGory.Text = "";
            gvMain.DataBind();

        }
    }
}
