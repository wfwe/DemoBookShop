using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// RoleRightManager
	/// </summary>
	public partial class RoleRightManager
	{
		private readonly BookShop.DAL.RoleRightServices dal=new BookShop.DAL.RoleRightServices();
        DAL.RoleInfoServices roleInfoServices = new BookShop.DAL.RoleInfoServices();
        DAL.SysFunServices sysfunServices = new BookShop.DAL.SysFunServices();
		public RoleRightManager()
		{}
		#region  Method

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
		public bool Exists(int RoleRightId)
		{
			return dal.Exists(RoleRightId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BookShop.Model.RoleRight model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.RoleRight model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleRightId)
		{
			
			return dal.Delete(RoleRightId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RoleRightIdlist )
		{
			return dal.DeleteList(RoleRightIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.RoleRight GetModel(int RoleRightId)
		{
			
			return dal.GetModel(RoleRightId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop.Model.RoleRight GetModelByCache(int RoleRightId)
		{
			
			string CacheKey = "RoleRightModel-" + RoleRightId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleRightId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.RoleRight)objModel;
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
		public List<BookShop.Model.RoleRight> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.RoleRight> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.RoleRight> modelList = new List<BookShop.Model.RoleRight>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.RoleRight model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BookShop.Model.RoleRight();
					if(dt.Rows[n]["RoleRightId"].ToString()!="")
					{
						model.RoleRightId=int.Parse(dt.Rows[n]["RoleRightId"].ToString());
					}
					if(dt.Rows[n]["RoleId"].ToString()!="")
					{
						int RoleId=int.Parse(dt.Rows[n]["RoleId"].ToString());
                        model.RoleInfo = roleInfoServices.GetModel(RoleId);
					}
					if(dt.Rows[n]["NodeId"].ToString()!="")
					{
						int NodeId=int.Parse(dt.Rows[n]["NodeId"].ToString());
                        model.SysFun = sysfunServices.GetModel(NodeId);
                        if (model.SysFun == null)
                        {
                            continue;
                        }
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


   


		#endregion  Method
	}
}

