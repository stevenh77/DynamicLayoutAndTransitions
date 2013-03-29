﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.ColorModelData
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class ColorModelData { }
#else

	public class ColorModelData : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public ColorModelData()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/DynamicLayoutAndTransitions;component/SampleData/ColorModelData/ColorModelData.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private ColorModels _ColorModels = new ColorModels();

		public ColorModels ColorModels
		{
			get
			{
				return this._ColorModels;
			}
		}
	}

	public class ColorModelsItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Brush = string.Empty;

		public string Brush
		{
			get
			{
				return this._Brush;
			}

			set
			{
				if (this._Brush != value)
				{
					this._Brush = value;
					this.OnPropertyChanged("Brush");
				}
			}
		}

		private string _Text = string.Empty;

		public string Text
		{
			get
			{
				return this._Text;
			}

			set
			{
				if (this._Text != value)
				{
					this._Text = value;
					this.OnPropertyChanged("Text");
				}
			}
		}
	}

	public class ColorModels : System.Collections.ObjectModel.ObservableCollection<ColorModelsItem>
	{ 
	}
#endif
}
