using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// RoleInfoManager
	/// </summary>
	public partial class RoleInfoManager
	{
		private readonly BookShop.DAL.RoleInfoServices dal=new BookShop.DAL.RoleInfoServices();
		public RoleInfoManager()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RoleId)
		{
			return dal.Exists(RoleId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(BookShop.Model.RoleInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(BookShop.Model.RoleInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int RoleId)
		{
			
			return dal.Delete(RoleId);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string RoleIdlist )
		{
			return dal.DeleteList(RoleIdlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public BookShop.Model.RoleInfo GetModel(int RoleId)
		{
			
			return dal.GetModel(RoleId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public BookShop.Model.RoleInfo GetModelByCache(int RoleId)
		{
			
			string CacheKey = "RoleInfoModel-" + RoleId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.RoleInfo)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<BookShop.Model.RoleInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<BookShop.Model.RoleInfo> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.RoleInfo> modelList = new List<BookShop.Model.RoleInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.RoleInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BookShop.Model.RoleInfo();
					if(dt.Rows[n]["RoleId"].ToString()!="")
					{
						model.RoleId=int.Parse(dt.Rows[n]["RoleId"].ToString());
					}
					model.RoleName=dt.Rows[n]["RoleName"].ToString();
					model.RoleDesc=dt.Rows[n]["RoleDesc"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

