using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOFF
{
	class DataContext
	{
		public DataContext()
		{

		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(0x3B760, 4); }
			set { Util.WriteNumber(0x3B760, 4, value, 0, 9999999); }
		}
	}
}
