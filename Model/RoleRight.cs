using System;
namespace BookShop.Model
{
	/// <summary>
	/// RoleRight:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

