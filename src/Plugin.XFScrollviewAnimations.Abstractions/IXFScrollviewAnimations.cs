using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plugin.XFScrollviewAnimations.Abstractions
{

    /// <summary>
    /// Interface for ScrollViewAnimations PCL Animations
    /// </summary>
    public interface IXFScrollviewAnimations
	{
		/// <summary>
		/// Alpha Animation
		/// </summary>
		/// <returns>animationFrame</returns>
		/// <param name="time">time</param>	
		void AlphaAnimation(CustomView view, int time);
		void AngleAnimation(CustomView view, int time);
		void ColorAnimation(CustomView view, int time);
		void TransformAnimation(CustomView view, int time);
		void Transform3DAnimation(CustomView view, int time);
		void HideAnimation(CustomView view, int time);
		void ScaleAnimation(CustomView view, int time);

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
		AnimationFrameBase FrameForTimeTransform(CustomView view, int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeHide(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);
		AnimationFrameBase FrameForTimeScale(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame);

	}
}
