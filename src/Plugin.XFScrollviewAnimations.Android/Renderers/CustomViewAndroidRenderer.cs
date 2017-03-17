using System;
using Plugin.XFScrollviewAnimations;
using Plugin.XFScrollviewAnimations.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewAndroidRenderer))]
namespace Plugin.XFScrollviewAnimations
{
	public class CustomViewAndroidRenderer : ViewRenderer
	{
		public CustomViewAndroidRenderer()
		{
		}
	}
}
