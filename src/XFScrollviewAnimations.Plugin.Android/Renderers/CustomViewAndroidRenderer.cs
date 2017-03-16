using System;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewiOSRenderer))]
namespace XFScrollviewAnimations.Plugin
{
	public class CustomViewiOSRenderer : ViewRenderer
	{
		public CustomViewiOSRenderer()
		{
		}
	}
}
