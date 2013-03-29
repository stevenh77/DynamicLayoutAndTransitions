using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DynamicLayoutAndTransitions
{
	public class ColorModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private SolidColorBrush brush;
		private string text;

		public ColorModel(Color color)
		{
			this.Brush = new SolidColorBrush(color);
		}

		public SolidColorBrush Brush
		{
			get { return this.brush; }
			set
			{
				this.brush = value;
				this.text = this.brush.Color.ToString();
				this.OnColorChanged();
			}
		}

		public string Text
		{
			get { return this.text; }
		}

		private void OnColorChanged()
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs("Brush"));
				this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
			}
		}
	}
}