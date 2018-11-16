using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WOFF
{
	class MindQuest : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private NameValueInfo mInfo;

		public MindQuest(NameValueInfo info)
		{
			mInfo = info;
		}

		public String Name
		{
			get { return mInfo.Name; }
		}

		public uint Status
		{
			get
			{
				if (SaveData.Instance().ReadBit(0x370 + mInfo.Value / 8, mInfo.Value % 8)) return 3;
				if (SaveData.Instance().ReadBit(0x368 + mInfo.Value / 8, mInfo.Value % 8)) return 2;
				if (SaveData.Instance().ReadBit(0x360 + mInfo.Value / 8, mInfo.Value % 8)) return 1;
				return 0;
			}

			set
			{
				SaveData.Instance().WriteBit(0x360 + mInfo.Value / 8, mInfo.Value % 8, false);
				SaveData.Instance().WriteBit(0x368 + mInfo.Value / 8, mInfo.Value % 8, false);
				SaveData.Instance().WriteBit(0x370 + mInfo.Value / 8, mInfo.Value % 8, false);
				SaveData.Instance().WriteBit(0x378 + mInfo.Value / 8, mInfo.Value % 8, false);

				if (value > 0) SaveData.Instance().WriteBit(0x360 + mInfo.Value / 8, mInfo.Value % 8, true);
				if (value > 1)
				{
					SaveData.Instance().WriteBit(0x368 + mInfo.Value / 8, mInfo.Value % 8, true);
					SaveData.Instance().WriteBit(0x378 + mInfo.Value / 8, mInfo.Value % 8, true);
				}
				if (value > 2) SaveData.Instance().WriteBit(0x370 + mInfo.Value / 8, mInfo.Value % 8, true);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
			}
		}
	}
}
