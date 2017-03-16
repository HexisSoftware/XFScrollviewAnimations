using System;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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
