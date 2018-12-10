using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile filePost= context.Request.Files["Filedata"];//获取上传的文件
            string fileName = Path.GetFileName(filePost.FileName);//获取上传文件的名称.

            //判读上传文件的类型
            string fileExtions = Path.GetExtension(fileName);

            if (fileExtions == ".jpg")
            {
                DateTime now=DateTime.Now;
                string dirName = "/UpFile/" + now.Year + "/" + now.Month + "/" + now.Day + "/";//根据日期建立不同的文件夹，让上传的图片放在该文件夹下.

                string upFileName = dirName + common.WebComm.GetStreamMD5(filePost.InputStream) + fileExtions;//为什么要对上传的文件进行MD5运算？区分每个文件。
                string fullPath=context.Server.MapPath(upFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));//创建目录.

                filePost.SaveAs(fullPath);//保存文件
                context.Response.Write("ok:" + upFileName);//把文件保存的路径返回给浏览器端.
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
