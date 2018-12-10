using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Drawing;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ImageMark : IHttpHandler
    {

        private const string WATERMARK_URL = "~/Images/watermark.jpg";   //水印的图片的url路径
        private const string DEFAULTIMAGE_URL = "~/Images/default.jpg";  //无图片时显示的图片
        public void ProcessRequest(HttpContext context)
        {

            string isbn = context.Request.QueryString["isbn"];
            //用户请求图片的url路径
            string imgUrl = "~/images/bookcovers/" + isbn + ".jpg";
            //用户请求图片的物理路径
            string filePath = context.Server.MapPath(imgUrl);
            Image Cover;

            if (File.Exists(filePath))
            {
                //如果文件存在

                //加载封面文件
                Cover = Image.FromFile(filePath);

                //加载水印图片
                Image watermark = Image.FromFile(context.Server.MapPath(WATERMARK_URL));
                //实例化画布
                Graphics g = Graphics.FromImage(Cover);

                //new Rectangle(
                //在image上绘制水印
            
                g.DrawImage(watermark, new Rectangle(Cover.Width - watermark.Width, Cover.Height - watermark.Height, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);
                //释放画布
                g.Dispose();
                //释放水印图片
                watermark.Dispose();
            }
            else
            {
                //封面图片不存在
                //加载默认图片
                Cover = Image.FromFile(context.Server.MapPath(DEFAULTIMAGE_URL));
            }
            //设置输出格式
            context.Response.ContentType = "image/jpeg";
            //将图片存入输出流            
            Cover.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Cover.Dispose();
            context.Response.End();
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
