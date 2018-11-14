using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOFF
{
	class Medal
	{
		private readonly NameValueInfo mInfo;
		public Medal(NameValueInfo info)
		{
			mInfo = info;
		}

		public String Name
		{
			get { return mInfo.Name; }
		}

		public bool Buy
		{
			get { return SaveData.Instance().ReadBit(0x250 + mInfo.Value / 8, mInfo.Value % 8); }
			set { SaveData.Instance().WriteBit(0x250 + mInfo.Value / 8, mInfo.Value % 8, value); }
		}
	}
}
