using System;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewAndroidRenderer))]
namespace XFScrollviewAnimations.Plugin
{
	public class CustomViewAndroidRenderer : ViewRenderer
	{
		public CustomViewAndroidRenderer()
		{
		}
	}
}
