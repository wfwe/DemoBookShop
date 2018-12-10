using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private string _roledesc;
		/// <summary>
		/// 
		/// </summary>
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleDesc
		{
			set{ _roledesc=value;}
			get{return _roledesc;}
		}
		#endregion Model

	}
}

