using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:RoleRightServices
	/// </summary>
	public partial class RoleRightServices
	{
        SysFunServices sysfunServices = new SysFunServices();
        RoleInfoServices roleInfoServices = new RoleInfoServices();
		public RoleRightServices()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleRightId", "RoleRight"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleRightId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RoleRight");
			strSql.Append(" where RoleRightId=@RoleRightId");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleRightId", SqlDbType.Int,4)
};
			parameters[0].Value = RoleRightId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BookShop.Model.RoleRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RoleRight(");
			strSql.Append("RoleId,NodeId)");
			strSql.Append(" values (");
			strSql.Append("@RoleId,@NodeId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@NodeId", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleInfo.RoleId;
			parameters[1].Value = model.SysFun.NodeId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.RoleRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RoleRight set ");
			strSql.Append("RoleId=@RoleId,");
			strSql.Append("NodeId=@NodeId");
			strSql.Append(" where RoleRightId=@RoleRightId");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@NodeId", SqlDbType.Int,4),
					new SqlParameter("@RoleRightId", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleInfo.RoleId;
			parameters[1].Value = model.SysFun.NodeId;
			parameters[2].Value = model.RoleRightId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleRightId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoleRight ");
			strSql.Append(" where RoleRightId=@RoleRightId");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleRightId", SqlDbType.Int,4)
};
			parameters[0].Value = RoleRightId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RoleRightIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoleRight ");
			strSql.Append(" where RoleRightId in ("+RoleRightIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.RoleRight GetModel(int RoleRightId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleRightId,RoleId,NodeId from RoleRight ");
			strSql.Append(" where RoleRightId=@RoleRightId");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleRightId", SqlDbType.Int,4)
};
			parameters[0].Value = RoleRightId;

			BookShop.Model.RoleRight model=new BookShop.Model.RoleRight();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleRightId"].ToString()!="")
				{
					model.RoleRightId=int.Parse(ds.Tables[0].Rows[0]["RoleRightId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RoleId"].ToString()!="")
				{
					 int RoleId=int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                     model.RoleInfo = roleInfoServices.GetModel(RoleId);
				}
				if(ds.Tables[0].Rows[0]["NodeId"].ToString()!="")
				{
					int nodeId=int.Parse(ds.Tables[0].Rows[0]["NodeId"].ToString());
                    model.SysFun = sysfunServices.GetModel(nodeId);
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RoleRightId,RoleId,NodeId ");
			strSql.Append(" FROM RoleRight ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}







		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RoleRightId,RoleId,NodeId ");
			strSql.Append(" FROM RoleRight ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}







		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "RoleRight";
			parameters[1].Value = "RoleRightId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

