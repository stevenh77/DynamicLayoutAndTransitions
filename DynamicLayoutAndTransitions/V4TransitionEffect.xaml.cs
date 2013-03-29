using System;
using System.Windows;
using System.Windows.Controls;

namespace DynamicLayoutAndTransitions
{
	public partial class V4TransitionEffect : UserControl
	{
		// NOTE: Not using data binding here because in Silverlight you apparently cannot data bind to the GeneratedDuration property.
		
		public V4TransitionEffect()
		{
			InitializeComponent();
			this.UpdateTransitionDuration();
			this.BehaviorSpeed.ValueChanged += BehaviorSpeed_ValueChanged;
		}

		private void BehaviorSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.UpdateTransitionDuration();
		}
		
		private void UpdateTransitionDuration()
		{
			Duration duration = new Duration(TimeSpan.FromSeconds(this.BehaviorSpeed.Value));

			foreach (VisualTransition transition in this.States.Transitions)
			{
				transition.GeneratedDuration = duration;
			}
		}
	}
}