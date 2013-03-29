using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DynamicLayoutAndTransitions
{
	public partial class Pane : UserControl
	{
		public Pane()
		{
			InitializeComponent();
			this.Loaded +=new System.Windows.RoutedEventHandler(Pane_Loaded);
		}
		
		public string Title { get; set; }

		private void Pane_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			this.TitleHeader.Text = this.Title;
		}
	}
}