using System;
using Xamarin.Forms;

namespace XFScrollviewAnimations.Plugin.Abstractions
{
	public class CustomView : View
	{
		public CustomView()
		{
		}

		public static explicit operator global::Android.Views.View(CustomView v)
		{
			throw new NotImplementedException();
		}
	}
}
