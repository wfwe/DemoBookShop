using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BookShop.Web.common
{
    public class WebComm
    {
        /// <summary>
        /// 将传递过来的字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CreateMd5(string str)
        {
            MD5 md5 = MD5.Create();//创建MD5
            byte[]buffer=System.Text.Encoding.UTF8.GetBytes(str);//将字符串转成字节数组
            byte[]md5Buffer=md5.ComputeHash(buffer);//进行哈希运算
            StringBuilder builder = new StringBuilder();
            foreach (byte s in md5Buffer)
            {
                builder.Append(s.ToString("X2"));
            }
            return builder.ToString();

        }

        /// <summary>
        /// 对Session进行判读
        /// </summary>
        /// <returns></returns>
        public static bool CheckSession()
        {
            //在单独类中，获取Session,Response等对象时通过HttpContext.
            if (HttpContext.Current.Session["user"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 跳转到登录页，同时将访问页的URL地址传递到登录页
        /// </summary>
        public static void GoToPage()
        {
            HttpContext.Current.Response.Redirect("/member/login.aspx?returnUrl="+HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static String GetStreamMD5(Stream stream)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            arrbytHashValue = oMD5Hasher.ComputeHash(stream); //计算指定Stream 对象的哈希值
            //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //替换-
            strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return strResult;
        }
    }
}
