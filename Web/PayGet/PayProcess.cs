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

namespace BookShop.Web.PayGet
{
    /// <summary>
    /// 组织发给支付的数据.
    /// </summary>
    public class PayProcess
    {

        public PayProcess(string subject, string body, string out_trade_no, string total_fee)
        {
            this.subject = subject;
            this.body = body;
            this.out_trade_no = out_trade_no;
            this.total_fee = total_fee;
            this.partner = ConfigurationManager.AppSettings["partner"].ToString();
            this.return_url = ConfigurationManager.AppSettings["return_url"].ToString();
            this.seller_email = ConfigurationManager.AppSettings["seller_email"].ToString();

            this.payGateUrl = ConfigurationManager.AppSettings["payGateUrl"].ToString();
            this.key = ConfigurationManager.AppSettings["key"].ToString();

            this.sign = common.WebComm.CreateMd5(total_fee + partner + out_trade_no + subject + key).ToLower();//按照要求生成数字签名.



        }
        //构建发给支付宝URL地址.
        public string GoPayPage()
        {
            string url = string.Format("{0}?partner={1}&return_url={2}&subject={3}&body={4}&out_trade_no={5}&total_fee={6}&seller_email={7}&sign={8}", payGateUrl, partner,return_url, subject, body, out_trade_no, total_fee, seller_email, sign);
            return url;
        }

        private string partner;//商户编号

        public string Partner
        {
            get { return partner; }
            set { partner = value; }
        }


        private string return_url;//回调地址

        public string Return_url
        {
            get { return return_url; }
            set { return_url = value; }
        }

        private string subject;//商品名称

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private string body;//商品描述

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        private string out_trade_no;//订单号！！！(由商户网站生成，支付宝不确保正确性，只负责转发。)

        public string Out_trade_no
        {
            get { return out_trade_no; }
            set { out_trade_no = value; }
        }
        private string total_fee;//总金额


        public string Total_fee
        {
            get { return total_fee; }
            set { total_fee = value; }
        }

        private string seller_email;//卖家邮箱1--

        public string Seller_email
        {
            get { return seller_email; }
            set { seller_email = value; }
        }
        private string sign;//数字签名

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }

        private string key;//密钥

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string payGateUrl;//支付地址

        public string PayGateUrl
        {
            get { return payGateUrl; }
            set { payGateUrl = value; }
        }




    }
}
