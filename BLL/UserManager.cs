using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using BookShop.Model;
using BookShop.DAL;


namespace BookShop.BLL
{
	/// <summary>
	/// 业务逻辑类UsersManager 的摘要说明。
	/// </summary>
	public class UserManager
	{
        RoleInfoServices roleinfoServices = new RoleInfoServices();
        UserStateServices userStateServices = new UserStateServices();
		private readonly BookShop.DAL.UserServices dal=new BookShop.DAL.UserServices();
		public UserManager()
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
		public int  Add(BookShop.Model.User model)
		{
          
                return dal.Add(model);
           
		}

       

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(BookShop.Model.User model)
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

        public void DeleteModel(BookShop.Model.User model)
        {

            dal.Delete(model.Id);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.User GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

 

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public BookShop.Model.User GetModelByCache(int Id)
		{
			
			string CacheKey = "UsersModel-" + Id;
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
			return (BookShop.Model.User)objModel;
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
		public List<BookShop.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.User> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.User> modelList = new List<BookShop.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BookShop.Model.User();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.LoginId=dt.Rows[n]["LoginId"].ToString();
					model.LoginPwd=dt.Rows[n]["LoginPwd"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Address=dt.Rows[n]["Address"].ToString();
					model.Phone=dt.Rows[n]["Phone"].ToString();
					model.Mail=dt.Rows[n]["Mail"].ToString();
					
					if(dt.Rows[n]["UserStateId"].ToString()!="")
					{
					    int UserStateId=int.Parse(dt.Rows[n]["UserStateId"].ToString());
                        model.UserState = userStateServices.GetModel(UserStateId);
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
        //.........................,..........................................

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BookShop.Model.User model,out string msg)
        {

            //在向数据库中保存用户信息时，先判断用户名是否已经被占用.

            if (CheckName(model.LoginId))
            {
                msg = "注册失败,请更换用户名!";
                return -1;
            }
            else
            {
                msg = "注册成功";
                return dal.Add(model);
            }

        }

        /// <summary>
        /// 对用户名进行校验，如果存在，该方法返回true,否则返回false.
        /// </summary>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        protected bool CheckName(string LoginId)
        {
            if (dal.GetModel(LoginId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

         
        }


        /// <summary>
        /// 根据用户名获取用户的实体
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public Model.User GetModel(string loginId)
        {
            return dal.GetModel(loginId);
        }

        /// <summary>
        /// 对用户的用户名与密码进行校验
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPass">密码</param>
        /// <param name="msg">信息</param>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        public bool CheckLogin(string userName, string userPass, out string msg,out Model.User model)
        {
            model = GetModel(userName);//根据用户名找用户
            if (model != null)//如果用户存在
            {
                if (model.UserState.Name == "正常")
                {
                    if (model.LoginPwd == userPass)
                    {
                        msg = "登录成功!";
                        return true;
                    }
                    else
                    {
                        msg = "登录失败!";
                        return false;
                    }
                }
                else
                {
                    msg = "用户已经被锁定!";
                    return false;
                }
            }
            else
            {
                msg = "登录失败!";
                return false;
            }
        }



        /// <summary>
        /// 对管理员登录时的账户和密码进行校验
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="userPwd"></param>
        /// <param name="msg"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>

        public bool AdminLogin(string loginId, string userPwd, out string msg, out User loginUser)
        {
            msg = "";

            loginUser = dal.GetModel(loginId);
            if (loginUser != null)
            {
                //当前用户已经存在!
                if (loginUser.LoginPwd == userPwd)
                {
                    return true;

                }
                else
                {
                    msg = "密码错误或权限不够!";
                    return false;
                }

            }
            else
            {
                msg = "用户名不存在!";
                return false;
            }
        }


		#endregion  成员方法
	}
}

