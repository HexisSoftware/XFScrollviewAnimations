using System;
using System.Drawing;
using Android.Views;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollviewAnimations.Plugin
{
	public class AnimationFrame : AnimationFrameBase
	{
		public RectangleF Frame = new RectangleF();
		public ViewStates Visibility;
		public Android.Graphics.Color Color;
	}
}
