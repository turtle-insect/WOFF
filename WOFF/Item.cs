using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WOFF
{
	class Item : INotifyPropertyChanged
	{
		private readonly uint mAddress;
		public event PropertyChangedEventHandler PropertyChanged;

		public Item(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 2); }
			set
			{
				Util.WriteNumber(mAddress + 4, 2, value, 0, 999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
