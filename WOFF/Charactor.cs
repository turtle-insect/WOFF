using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WOFF
{
	class Charactor : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;
		public Charactor(uint address)
		{
			mAddress = address;
		}

		public uint Address
		{
			get { return mAddress; }
		}

		public void Clear()
		{
			Name = "";
			Exp = 0;
			HP = 0;
			AP = 0;
			SP = 0;
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

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 4); }
			set
			{
				Util.WriteNumber(mAddress + 4, 4, value, 0, 9999999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Exp)));
			}
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 8, 4); }
			set
			{
				Util.WriteNumber(mAddress + 8, 4, value, 0, 99999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HP)));
			}
		}

		public uint AP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 12, 4); }
			set
			{
				Util.WriteNumber(mAddress + 12, 4, value, 0, 99999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AP)));
			}
		}

		public String Name
		{
			get { return SaveData.Instance().ReadText(mAddress + 16, 18); }
			set
			{
				SaveData.Instance().WriteText(mAddress + 16, 18, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}

		public uint SP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 300, 2); }
			set
			{
				Util.WriteNumber(mAddress + 300, 2, value, 0, 999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SP)));
			}
		}
	}
}
