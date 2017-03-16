using System;
using XFScrollviewAnimations.Plugin.Abstractions;
using UIKit;
using CoreGraphics;

namespace XFScrollviewAnimations.Plugin
{

	public class AnimationFrame : AnimationFrameBase
	{
		public UIColor Color;
		public CGRect Frame;
		public Transform3D Transform = new Transform3D();


	}
}
