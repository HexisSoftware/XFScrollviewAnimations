using System;
using Plugin.XFScrollviewAnimations;
using Plugin.XFScrollviewAnimations.Abstractions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewiOSRenderer))]
namespace Plugin.XFScrollviewAnimations
{
	public class CustomViewiOSRenderer : ViewRenderer
	{
		public CustomViewiOSRenderer()
		{
		}
	}
}
