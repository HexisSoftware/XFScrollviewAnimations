using System;
using Xamarin.Forms;

namespace XFScrollviewAnimations.Plugin.Abstractions
{
	public class AnimatedScrollView : ScrollView
	{
		private static int _defaultPageNumber = 1;

		public static readonly BindableProperty NumberOfPageProperty = BindableProperty.Create(nameof(NumberOfPage), typeof(int), typeof(AnimatedScrollView), _defaultPageNumber);
		public int NumberOfPage
		{
			get { return (int)GetValue(NumberOfPageProperty); }
			set { SetValue(NumberOfPageProperty, value); }
		}
	}
}
