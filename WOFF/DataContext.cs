using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WOFF
{
	class DataContext
	{
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

		public DataContext()
		{
			for(uint i = 0; i < 256; i++)
			{
				Items.Add(new Item(0x37590 + i * 8));
			}
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(0x344B8, 4); }
			set { Util.WriteNumber(0x344B8, 4, value, 0, 9999999); }
		}
	}
}
