using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleInfo:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

