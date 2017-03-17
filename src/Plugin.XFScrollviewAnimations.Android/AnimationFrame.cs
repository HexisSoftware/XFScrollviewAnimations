using System;
using System.Drawing;
using Android.Views;
using Plugin.XFScrollviewAnimations.Abstractions;

namespace Plugin.XFScrollviewAnimations
{
	public class AnimationFrame : AnimationFrameBase
	{
		public RectangleF Frame = new RectangleF();
		public ViewStates Visibility;
		public Android.Graphics.Color Color;
	}
}
