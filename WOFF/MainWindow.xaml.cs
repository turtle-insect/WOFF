using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WOFF
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			SaveData.Instance().Open(files[0], false);
			Init();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load(false);
		}

		private void MenuItemFileOpenForce_Click(object sender, RoutedEventArgs e)
		{
			Load(true);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void ToolBarFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load(false);
		}

		private void ToolBarFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void ButtonItem_Click(object sender, RoutedEventArgs e)
		{
			Item item = (sender as Button)?.DataContext as Item;
			if (item == null) return;

			var window = new ChoiceWindow();
			window.ID = item.ID;
			window.ShowDialog();
			item.ID = window.ID;
			if (item.ID == Util.NONE) item.Count = 0;
			else if (item.Count == 0) item.Count = 1;
		}

		private void ButtonMirage_Click(object sender, RoutedEventArgs e)
		{
			var charactor = ListBoxCharactor.SelectedItem as Charactor;
			if (charactor == null) return;

			var window = new ChoiceWindow();
			window.Type = ChoiceWindow.eType.mirage;
			window.ID = charactor.ID;
			window.ShowDialog();
			if(charactor.ID != window.ID)
			{
				Util.InitCharactor(charactor.Address);
				charactor.Clear();
			}
			charactor.ID = window.ID;
		}

		private void Init()
		{
			DataContext = new DataContext();
		}

		private void Load(bool force)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if(SaveData.Instance().Open(dlg.FileName, force) == false)
			{
				MessageBox.Show(Properties.Resources.MessageLoadFail);
				return;
			}

			Init();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MessageSaveFail);
		}
	}
}
