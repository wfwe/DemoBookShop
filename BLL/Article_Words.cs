using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BookShop.BLL
{
   public class Article_Words
    {
       DAL.Article_Words dal = new BookShop.DAL.Article_Words();
       /// <summary>
      /// 查找指定的词
      /// </summary>
      /// <param name="word"></param>
      /// <returns></returns>
       public Model.Article_Words GetWord(string word)
       {
           return dal.GetWord(word);
       }
        /// <summary>
      /// 添加词到数据表中
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
       public int Add(Model.Article_Words model)
       {
           return dal.Add(model);
       }
         /// <summary>
      /// 获取所有的词库
      /// </summary>
      /// <returns></returns>
       public List<Model.Article_Words> GetAll()
       {
           return dal.GetAll();
       }
        /// <summary>
      /// 查出所有的禁用词放入List集合中
      /// </summary>
      /// <returns></returns>
       public bool GetForbWord(string msg) 
       {
           List<string>list=dal.GetForbWord();//得到所有的禁用词
           //foreach (string str in list)
           //{
           //   return  msg.Contains(str);
           //}

           //正则表达式.  10倍.

           //"价格","发票"  ---价格|发票|
           string str=string.Join("|", list.ToArray());//aa|bb|cc|dd
           str = str.Replace(@"\", @"\\").Replace("{2}", ".{0,2}");
         return  Regex.IsMatch(msg, str);

       }
        /// <summary>
      /// 获取相应的审核词
      /// </summary>
      /// <returns></returns>
       public bool GetModWord(string msg)
       {
           List<string> list = dal.GetModWord();
           string str = string.Join("|", list.ToArray());//aa|bb|cc|dd
           str = str.Replace(@"\", @"\\").Replace("{2}",".{0,2}");
           return Regex.IsMatch(msg, str);
       }

       /// <summary>
      /// 查找出所有的替换词
      /// msg:是用户输入的评论信息
      /// 我们的政府很强大，你信不信，反正我信了。
       ///  我们的天朝很强大，你信不信，反正我信了。
      /// </summary>
      /// <returns></returns>
       public string GetReplaceWord(string msg)
       {

           List<Model.Article_Words>list=dal.GetReplaceWord();//包含替换词的数据记录
           string result = msg;
      
               foreach (Model.Article_Words model in list)//将用户输入的文本信息中需要替换的词按照从词库中取出的内容进行替换
               {
                   result=result.Replace(model.WordPattern, model.ReplaceWord);
               }
               return result;
           

       }

    }
}
