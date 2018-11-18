using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WOFF
{
	class Place : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public NameValueInfo mInfo;

		public Place(NameValueInfo info)
		{
			mInfo = info;
		}

		public String Name
		{
			get { return mInfo.Name; }
		}

		public bool Visit
		{
			get { return SaveData.Instance().ReadBit(0x4F0 + mInfo.Value / 8, mInfo.Value % 8); }
			set
			{
				SaveData.Instance().WriteBit(0x4F0 + mInfo.Value / 8, mInfo.Value % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Visit)));
			}
		}
	}
}
