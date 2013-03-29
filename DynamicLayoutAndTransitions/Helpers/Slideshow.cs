using System;
using System.Collections.Generic;
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
	public class Slideshow : ItemsControl
	{
		public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(Slideshow), new PropertyMetadata(0));
		public int SelectedIndex
		{
    		get { return (int) base.GetValue(SelectedIndexProperty); }
    		set { base.SetValue(SelectedIndexProperty, value); }
		}
 
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(Slideshow), new PropertyMetadata(null));
		public object SelectedItem
		{
    		get { return base.GetValue(SelectedItemProperty); }
    		set { base.SetValue(SelectedItemProperty, value); }
		}
 
		public static readonly DependencyProperty TransitionStyleProperty = DependencyProperty.Register("TransitionStyle", typeof(Style), typeof(Slideshow), new PropertyMetadata(null));
		public Style TransitionStyle
		{
			get { return (Style)GetValue(TransitionStyleProperty); }
			set { SetValue(TransitionStyleProperty, value); }
		}

		public static readonly DependencyProperty ReversedProperty = DependencyProperty.Register("Reversed", typeof(bool), typeof(Slideshow), new PropertyMetadata(false));
		public bool Reversed
		{
			get { return (bool)GetValue(ReversedProperty); }
			set { SetValue(ReversedProperty, value); }
		}

		public static readonly DependencyProperty InCarouselModeProperty = DependencyProperty.Register("InCarouselMode", typeof(bool), typeof(Slideshow), new PropertyMetadata(true));
		public bool InCarouselMode
		{
			get { return (bool)GetValue(InCarouselModeProperty); }
			set { SetValue(InCarouselModeProperty, value); }
		}

		public Slideshow()
		{
		}
		
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this.SelectedItem = this.Items[this.SelectedIndex];
			
			Button prevButton = this.GetTemplateChild("PreviousButton") as Button;
			if (prevButton != null)
			{
				prevButton.Click += new System.Windows.RoutedEventHandler(prevButton_Click);
			}

			Button nextButton = this.GetTemplateChild("NextButton") as Button;
			if (nextButton != null)
			{
				nextButton.Click += new System.Windows.RoutedEventHandler(nextButton_Click);
			}
		}

		private void prevButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Reversed = this.InCarouselMode;
			this.SelectedIndex = (this.SelectedIndex - 1 + this.Items.Count) % (this.Items.Count);
			this.SelectedItem = this.Items[this.SelectedIndex];
		}

		private void nextButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Reversed = false;
			this.SelectedIndex = (this.SelectedIndex + 1) % (this.Items.Count);
			this.SelectedItem = this.Items[this.SelectedIndex];
		}
	}
}