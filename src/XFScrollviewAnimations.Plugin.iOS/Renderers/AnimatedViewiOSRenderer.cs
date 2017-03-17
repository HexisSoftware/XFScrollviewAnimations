using System;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AnimatedView), typeof(AnimatedViewiOSRenderer))]
namespace XFScrollviewAnimations.Plugin
{
	public class AnimatedViewiOSRenderer : ViewRenderer
	{
		public AnimatedViewiOSRenderer()
		{
		}
	}
}
