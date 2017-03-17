using System;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AnimatedView), typeof(AnimatedViewAndroidRenderer))]
namespace XFScrollviewAnimations.Plugin
{
	public class AnimatedViewAndroidRenderer : ViewRenderer
	{
		public AnimatedViewAndroidRenderer()
		{
		}
	}
}
