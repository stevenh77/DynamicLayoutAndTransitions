using System;
using System.Windows;
using System.Windows.Controls;

namespace DynamicLayoutAndTransitions
{
	public partial class V3FluidLayout : UserControl
	{
		// NOTE: Not using data binding here because in Silverlight you apparently cannot data bind to the GeneratedDuration property.
		
		public V3FluidLayout()
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

			((VisualTransition)this.PaneVisibilityStates.Transitions[0]).GeneratedDuration = duration;
			((VisualTransition)this.PaneStates.Transitions[0]).GeneratedDuration = duration;
		}
	}
}