using System;
using Plugin.XFScrollviewAnimations.Abstractions;
using UIKit;
using CoreGraphics;

namespace Plugin.XFScrollviewAnimations
{

	public class AnimationFrame : AnimationFrameBase
	{
		public UIColor Color;
		public CGRect Frame;
		public Transform3D Transform = new Transform3D();


	}
}
