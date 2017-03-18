using System;
using Xamarin.Forms;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollviewAnimations.Plugin
{
	/// <summary>
	/// Scroll view animations.
	/// </summary>
    public class ScrollViewAnimations : IXFScrollviewAnimations
    {
		/// <summary>
		/// Adds the view.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="positionX">Position x.</param>
		/// <param name="positionY">Position y.</param>
        public void AddView(double width, double height, double positionX, double positionY)
		{
		}

		public void AlphaAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public void AngleAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public void ColorAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTime3D(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeAlpha(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeAngle(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeColor(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeHide(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeScale(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeTransform(CustomView view, int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public void HideAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public void ScaleAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public void Transform3DAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}

		public void TransformAnimation(CustomView view, int time)
		{
			throw new NotImplementedException();
		}
	}
}

