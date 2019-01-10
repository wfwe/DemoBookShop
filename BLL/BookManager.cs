using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using BookShop.Model;
using BookShop.DAL;
namespace BookShop.BLL
{
	/// <summary>
	/// 业务逻辑类BooksManager 的摘要说明。
	/// </summary>
	public class BookManager
	{
        PublisherServices publisherServices = new PublisherServices();
        CategoryServices categoryServices = new CategoryServices();
		private readonly BookShop.DAL.BookServices dal=new BookShop.DAL.BookServices();
		public BookManager()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BookShop.Model.Book model)
		{
            
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(BookShop.Model.Book model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			
			dal.Delete(Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Book GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public BookShop.Model.Book GetModelByCache(int Id)
		{
			
			string CacheKey = "BooksModel-" + Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.Book)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Book> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Book> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Book> modelList = new List<BookShop.Model.Book>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Book model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BookShop.Model.Book();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Author=dt.Rows[n]["Author"].ToString();
					if(dt.Rows[n]["PublisherId"].ToString()!="")
					{
						int PublisherId=int.Parse(dt.Rows[n]["PublisherId"].ToString());
                        model.Publisher = publisherServices.GetModel(PublisherId);
					}
					if(dt.Rows[n]["PublishDate"].ToString()!="")
					{
						model.PublishDate=DateTime.Parse(dt.Rows[n]["PublishDate"].ToString());
					}
					model.ISBN=dt.Rows[n]["ISBN"].ToString();
					if(dt.Rows[n]["WordsCount"].ToString()!="")
					{
						model.WordsCount=int.Parse(dt.Rows[n]["WordsCount"].ToString());
					}
					if(dt.Rows[n]["UnitPrice"].ToString()!="")
					{
						model.UnitPrice=decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
					}
					model.ContentDescription=dt.Rows[n]["ContentDescription"].ToString();
					model.AurhorDescription=dt.Rows[n]["AurhorDescription"].ToString();
					model.EditorComment=dt.Rows[n]["EditorComment"].ToString();
					model.TOC=dt.Rows[n]["TOC"].ToString();
					if(dt.Rows[n]["CategoryId"].ToString()!="")
					{
						 int CategoryId=int.Parse(dt.Rows[n]["CategoryId"].ToString());
                         model.Category = categoryServices.GetModel(CategoryId);
					}
					if(dt.Rows[n]["Clicks"].ToString()!="")
					{
						model.Clicks=int.Parse(dt.Rows[n]["Clicks"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        //-----------------------------------
        /// <summary>
        /// 求出总的页数
        /// </summary>
        /// <param name="pageNum">每页显示的记录数</param>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public int GetPageCount(int pageNum,int categoryId)
        {
            int rowCount = dal.GetRowCount(categoryId);//求出指定类别下的记录数
            int pageCount =Convert.ToInt32(Math.Ceiling((double) rowCount / pageNum));//求出在指定类别下的页数
            return pageCount;
        }
        /// <summary>
        /// 获取分页的数据
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageNum">每页显示的记录数</param>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public List<Model.Book> GetPageList(int pageIndex,int pageNum,int categoryId,string orderby)
        {
            int start=(pageIndex-1)*pageNum+1;//由于在数据层中的SQL语句时>=start,所以在这里要加1.
            int end=pageIndex*pageNum;
            DataSet ds = dal.GetPageList(start, end, categoryId, orderby);//获取分页数据
           return DataTableToList(ds.Tables[0]);
        }

          /// <summary>
        /// 获取分页的数据
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageNum">每页显示的记录数</param>
        /// <param name="categoryId">类别编号</param>
        /// <returns></returns>
        public List<Model.Book> GetPageList(int pageIndex, int pageNum, int categoryId)
        {
            return GetPageList(pageIndex, pageNum, categoryId, null);
        }



        
        /// <summary>
        /// 根据传递过来的书名，查找该书.(模糊查询)
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public List<Model.Book> GetLikeList(string term)
        {
         DataSet ds=   dal.GetLikeList(term);
         return DataTableToList(ds.Tables[0]);

        }

		#endregion  成员方法
	}
}

