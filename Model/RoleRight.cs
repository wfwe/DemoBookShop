using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleRight:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleRight
	{
		public RoleRight()
		{}
		#region Model
        private int _rolerightid;


        private RoleInfo _roleInfo = new RoleInfo();

        public RoleInfo RoleInfo
        {
            get { return _roleInfo; }
            set { _roleInfo = value; }
        }
        private SysFun _sysFun = new SysFun();

        public SysFun SysFun
        {
            get { return _sysFun; }
            set { _sysFun = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int RoleRightId
		{
			set{ _rolerightid=value;}
			get{return _rolerightid;}
		}

		#endregion Model

	}
}

