using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WOFF
{
    class Jewel : INotifyPropertyChanged
	{
		private readonly uint mAddress;
		public event PropertyChangedEventHandler PropertyChanged;

		public Jewel(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 4, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
			set
			{
				Util.WriteNumber(mAddress, 2, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
