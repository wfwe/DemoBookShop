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
    public class DownLoadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string filename = context.Server.UrlEncode("词库12.txt");
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", filename));//填充一个保存窗口
            BLL.Article_Words bll = new BookShop.BLL.Article_Words();
            List<Model.Article_Words>list=bll.GetAll();
            foreach (Model.Article_Words model in list)
             {
                 string WordPatter = model.WordPattern;
                 string patter;
                 if (model.IsForbid == true)
                 {
                     patter = "{BANNED}";
                 }
                 else if (model.IsMod == true)
                 {
                     patter = "{MOD}";
                 }
                 else
                 {
                     patter = model.ReplaceWord;
                 }

                 context.Response.Write(WordPatter + "=" + patter + "\r\n");
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
