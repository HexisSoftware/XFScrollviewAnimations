using System;

using XFScrollviewAnimations.Plugin.Abstractions;
using Android.OS;
using Android.Content;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace XFScrollviewAnimations.Plugin
{
	/// <summary>
	/// Android implementation to handle scrollview and view animations
	/// </summary>
	public class ScrollViewAnimations : Animation, IXFScrollviewAnimations
	{
		/// <summary>
		/// Set of all animations
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="time">Time.</param>
		/// 

		public Android.Views.View nativeView;

		public Animation AlphaAnimation(AnimatedView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return null;


            var renderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, renderer);

			nativeView = renderer.ViewGroup.RootView;

			nativeView.Alpha = animationFrame.Alpha;

			return this;
		}

		public Animation AngleAnimation(AnimatedView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return null;

			var renderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, renderer);

			nativeView = renderer.ViewGroup.RootView;

			nativeView.Rotation = animationFrame.Angle;

			return this;
		}

		public Animation ColorAnimation(AnimatedView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return null;

			var renderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, renderer);

			nativeView = renderer.ViewGroup.RootView;

			AnimationFrame colorAnimationFrame = Animation.AnimationFrameForTime(time) as AnimationFrame;
			nativeView.SetBackgroundColor(colorAnimationFrame.Color);

			return this;
		}

		public Animation HideAnimation(AnimatedView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return null;

			var renderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, renderer);

			nativeView = renderer.ViewGroup.RootView;

			AnimationFrame hideAnimationFrame = Animation.AnimationFrameForTime(time) as AnimationFrame;
			nativeView.Visibility = hideAnimationFrame.Visibility;

			return this;
		}

		public Animation ScaleAnimation(AnimatedView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return null;

			var renderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, renderer);

			nativeView = renderer.ViewGroup.RootView;

			AnimationFrame scaleAnimationFrame = Animation.AnimationFrameForTime(time) as AnimationFrame;
			float scale = scaleAnimationFrame.Scale;
			//nativeView.Transform = CGAffineTransform.MakeScale (scale, scale);
			return this;
		}

		public AnimationFrameBase FrameForTimeAlpha(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			var animationFrame = new AnimationFrame();
			animationFrame.Alpha = Animation.TweenValueForStartTime(startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Alpha,
				endKeyFrame.Alpha,
				time);

			return animationFrame;
		}

		public AnimationFrameBase FrameForTimeAngle(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			var animationFrame = new AnimationFrame();
			animationFrame.Alpha = Animation.TweenValueForStartTime(startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Angle,
				endKeyFrame.Angle,
				time);

			return animationFrame;
		}


		public AnimationFrameBase FrameForTimeColor(int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			AnimationFrame animationFrame = new AnimationFrame();
			int startRed = 0, startBlue = 0, startGreen = 0, startAlpha = 0;
			int endRed = 0, endBlue = 0, endGreen = 0, endAlpha = 0;

			if (GetRGBA(out startRed, out startGreen, out startBlue, out startAlpha, startKeyFrame.Color) &&
				GetRGBA(out endRed, out endGreen, out endBlue, out endAlpha, endKeyFrame.Color))
			{

				int red = (int)(Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startRed, endRed, time));
				int green = (int)(Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startGreen, endGreen, time));
				int blue = (int)(Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startBlue, endBlue, time));
				int alpha = (int)(Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startAlpha, endAlpha, time));

				animationFrame.Color = Android.Graphics.Color.Argb(alpha, red, green, blue);

			}

			return animationFrame;
		}

		/// <summary>
		/// Gets the red.
		/// </summary>
		/// <returns><c>true</c>, if red was gotten, <c>false</c> otherwise.</returns>
		/// <param name="red">Red.</param>
		/// <param name="green">Green.</param>
		/// <param name="blue">Blue.</param>
		/// <param name="alpha">Alpha.</param>
		/// <param name="color">Color.</param>

		private bool GetRGBA(out int red, out int green, out int blue, out int alpha, Android.Graphics.Color color)
		{
			red = ((color >> 16) & 0xFF);
			green = ((color >> 8) & 0xFF);
			blue = ((color >> 0) & 0xFF);
			alpha = ((color >> 32) & 0xFF);

			if (red != null && green != null && blue != null && alpha != null)
				return true;

			return false;
		}


		public AnimationFrameBase FrameForTimeHide(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Hidden = (time == startKeyFrame.Time ? startKeyFrame : endKeyFrame).Hidden;

			return animationFrame;
		}

		public AnimationFrameBase FrameForTimeScale(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			var animationFrame = new AnimationFrame();
			animationFrame.Scale = Animation.TweenValueForStartTime(startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Scale,
				endKeyFrame.Scale,
				time);

			return animationFrame;
		}

		public Animation TransformAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Animation Transform3DAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTime3D(int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public AnimationFrameBase FrameForTimeTransform(AnimatedView view, int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}


        #region IDisposable implementation
        /// <summary>
        /// Dispose of class and parent classes
        /// </summary>
        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose up
		/// </summary>
		private bool disposed = false;
		/// <summary>
		/// Dispose method
		/// </summary>
		/// <param name="disposing"></param>
		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					//dispose only
				}

				disposed = true;
			}
		}
		#endregion
	}
}