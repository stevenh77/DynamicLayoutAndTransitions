using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DynamicLayoutAndTransitions
{
	public partial class V4LayoutStates : UserControl
	{
		private Random r = new Random();
		private ObservableCollection<ColorModel> colors = new ObservableCollection<ColorModel>();
		
		public ObservableCollection<ColorModel> Colors { get { return this.colors; } }
		
		public V4LayoutStates()
		{
			InitializeComponent();
			this.DataContext = colors;
		}

		private void AddColor(object sender, System.Windows.RoutedEventArgs e)
		{
			ColorModel color = new ColorModel(Color.FromArgb(255, (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256)));
			this.Colors.Insert(r.Next(this.Colors.Count + 1), color);
		}

		private void RemoveColor(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this.Colors.Count > 0)
			{
				this.Colors.RemoveAt(r.Next(this.Colors.Count));
			}
		}
	}
}