using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFScrollviewAnimations.Plugin.Abstractions
{

    /// <summary>
    /// Interface for ScrollViewAnimations PCL Animations
    /// </summary>
    public interface IXFScrollviewAnimations : IDisposable
	{
		/// <summary>
		/// Alpha Animation
		/// </summary>
		/// <returns>animationFrame</returns>
		/// <param name="time">time</param>	
		Animation AlphaAnimation(AnimatedView view, int time);
		Animation AngleAnimation(AnimatedView view, int time);
		Animation ColorAnimation(AnimatedView view, int time);
		Animation TransformAnimation(AnimatedView view, int time);
		Animation Transform3DAnimation(AnimatedView view, int time);
		Animation HideAnimation(AnimatedView view, int time);
		Animation ScaleAnimation(AnimatedView view, int time);

		/// <summary>
		/// Frames for time.
		/// </summary>
		/// <returns>The AnimationFrameBase</returns>
		/// <param name="time">Time.</param>
		/// <param name="startKeyFrame">Start key frame.</param>
		/// <param name="endKeyFrame">End key frame.</param>
		AnimationFrameBase FrameForTimeAlpha(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeAngle(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTime3D(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeColor(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeTransform(AnimatedView view, int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeHide(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeScale(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);

	}
}
