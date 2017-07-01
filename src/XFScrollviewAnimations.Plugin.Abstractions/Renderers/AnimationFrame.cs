using System;
using Xamarin.Forms;

namespace XFScrollviewAnimations.Plugin.Abstractions
{
	public class AnimationFrame : AnimationFrameBase
	{
		public int xPosition { get; set; }
		public int yPosition { get; set; }
		public Size frameSize { get; set; }
		public Color frameColor { get; set; }
		public Transform3D Transform = new Transform3D();
	}
}
