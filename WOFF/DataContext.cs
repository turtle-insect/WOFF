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
		public ObservableCollection<Item> BattleItems { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Item> OtherItems { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Charactor> Charactors { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Member> Party { get; set; } = new ObservableCollection<Member>();
		public ObservableCollection<Medal> Medals { get; set; } = new ObservableCollection<Medal>();
		public ObservableCollection<Jewel> Jewels { get; set; } = new ObservableCollection<Jewel>();
		public ObservableCollection<MindQuest> Minds { get; set; } = new ObservableCollection<MindQuest>();

		public DataContext()
		{
			for(uint i = 0; i < 256; i++)
			{
				BattleItems.Add(new Item(0x37590 + i * 8));
			}

			for (uint i = 0; i < 1024; i++)
			{
				OtherItems.Add(new Item(0x37D90 + i * 8));
			}

			for (uint i = 0; i < 200; i++)
			{
				Charactors.Add(new Charactor(0x700 + i * 1062));
			}

			for (uint i = 0; i < 120; i++)
			{
				Jewels.Add(new Jewel(0x46380 + i * 8));
			}

			for (uint i = 0; i < 12; i++)
			{
				Party.Add(new Member(0x6D0 + i * 4));
			}

			foreach(var info in Info.Instance().Minds)
			{
				Minds.Add(new MindQuest(info));
			}

			foreach (var info in Info.Instance().Medals)
			{
				Medals.Add(new Medal(info));
			}
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(0x344B8, 4); }
			set { Util.WriteNumber(0x344B8, 4, value, 0, 9999999); }
		}
	}
}
