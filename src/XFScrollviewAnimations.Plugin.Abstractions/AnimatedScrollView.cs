using System;
using Xamarin.Forms;

namespace XFScrollviewAnimations.Plugin.Abstractions
{
	public class AnimatedScrollView : ScrollView
	{
		private static int _defaultPageNumber = 1;

		public static readonly BindableProperty PageNumberProperty = BindableProperty.Create(nameof(PageNumber), typeof(int), typeof(AnimatedScrollView), _defaultPageNumber);
		public int PageNumber
		{
			get { return (int)GetValue(PageNumberProperty); }
			set { SetValue(PageNumberProperty, value); }
		}
	}
}
