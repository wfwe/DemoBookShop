using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace BookShop.DAL
{
    /// <summary>
    /// 过滤词操作
    /// </summary>
  public  class Article_Words
    {
      /// <summary>
      /// 查找指定的词
      /// </summary>
      /// <param name="word"></param>
      /// <returns></returns>
      public Model.Article_Words GetWord(string word)
      {
          string sql = "select * from Articel_Words where WordPattern=@WordPattern";
          using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, new SqlParameter("@WordPattern", word)))
          {
              if (reader.Read())
              {
                  Model.Article_Words mode = new BookShop.Model.Article_Words();
                  mode.Id = Convert.ToInt32(reader["Id"]);
                  mode.IsForbid = Convert.ToBoolean(reader["IsForbid"]);
                  mode.IsMod = Convert.ToBoolean(reader["IsMod"]);
                  mode.ReplaceWord = reader["ReplaceWord"].ToString();
                  mode.WordPattern = reader["WordPattern"].ToString();
                  return mode;
              }
              else
              {
                  return null;
              }
          }
         
      }

      /// <summary>
      /// 添加词到数据表中
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public int Add(Model.Article_Words model)
      {
          string sql = "insert into Articel_Words(IsForbid,IsMod,ReplaceWord,WordPattern)values(@IsForbid,@IsMod,@ReplaceWord,@WordPattern)";

          SqlParameter[] par = { 
                               
                                 new SqlParameter("@IsForbid",model.IsForbid),
                                  new SqlParameter("@IsMod",model.IsMod),
                                   new SqlParameter("@ReplaceWord",model.ReplaceWord),
                                    new SqlParameter("@WordPattern",model.WordPattern)
                               };

          return DbHelperSQL.ExecuteSql(sql,par);
      }

      /// <summary>
      /// 获取所有的词库
      /// </summary>
      /// <returns></returns>
      public List<Model.Article_Words> GetAll()
      {
          string sql = "select * from Articel_Words";
          using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
          {
              List<Model.Article_Words>list=new List<BookShop.Model.Article_Words>();
              while(reader.Read())
              {
                  Model.Article_Words mode = new BookShop.Model.Article_Words();
                  mode.Id = Convert.ToInt32(reader["Id"]);
                  mode.IsForbid = Convert.ToBoolean(reader["IsForbid"]);
                  mode.IsMod = Convert.ToBoolean(reader["IsMod"]);
                  mode.ReplaceWord = reader["ReplaceWord"].ToString();
                  mode.WordPattern = reader["WordPattern"].ToString();
                  list.Add(mode);
              }
              return list;
              
          }
      }

      /// <summary>
      /// 查出所有的禁用词放入List集合中
      /// </summary>
      /// <returns></returns>
      public List<string> GetForbWord()
      {
          string sql = "select * from Articel_Words where IsForbid=1";
          List<string> list = new List<string>();
          using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
          {
              while (reader.Read())
              {
                  list.Add(reader["WordPattern"].ToString());
              }
              return list;
          }
      }

      /// <summary>
      /// 获取相应的审核词
      /// </summary>
      /// <returns></returns>
      public List<string> GetModWord()
      {
          string sql = "select * from Articel_Words where IsMod=1";
          List<string> list = new List<string>();
          using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
          {
              while (reader.Read())
              {
                  list.Add(reader["WordPattern"].ToString());
              }
              return list;
          }
      }

      /// <summary>
      /// 查找出所有的替换词
      /// </summary>
      /// <returns></returns>
      public List<Model.Article_Words> GetReplaceWord()
      {
          string sql = "select * from Articel_Words where IsMod=0 and IsForbid=0";
          List<Model.Article_Words> list = new List<BookShop.Model.Article_Words>();
          using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
          {
              while (reader.Read())
              {
                  Model.Article_Words mode = new BookShop.Model.Article_Words();
                  mode.Id = Convert.ToInt32(reader["Id"]);
                  mode.IsForbid = Convert.ToBoolean(reader["IsForbid"]);
                  mode.IsMod = Convert.ToBoolean(reader["IsMod"]);
                  mode.ReplaceWord = reader["ReplaceWord"].ToString();
                  mode.WordPattern = reader["WordPattern"].ToString();
                  list.Add(mode);
              }
              return list;
          }
      }

    }
}
