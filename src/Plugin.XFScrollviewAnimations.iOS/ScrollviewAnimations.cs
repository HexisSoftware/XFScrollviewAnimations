using System;

using Plugin.XFScrollviewAnimations.Abstractions;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using CoreAnimation;
using System.Drawing;

namespace Plugin.XFScrollviewAnimations
{
	/// <summary>
	/// iOS implementation to handle scrollview and view animations
	/// </summary>
	public class ScrollViewAnimations : IXFScrollviewAnimations
	{
		/// <summary>
		/// Set of all animations
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="time">Time.</param>
		/// 
		public void AlphaAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);

			AnimationFrame animationFrameAlpha = Animation.AnimationFrameForTime(time) as AnimationFrame;
			nativeView.Alpha = animationFrameAlpha.Alpha;
		}

		public void AngleAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);


			var animationFrameAngle = Animation.AnimationFrameForTime(time);
			nativeView.Transform = CGAffineTransform.MakeRotation(animationFrameAngle.Angle);
		}

		public void Transform3DAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);

			AnimationFrame aFrame = (AnimationFrame)Animation.AnimationFrameForTime(time);
			if (aFrame.Transform == null)
				return;

			CATransform3D transform = CATransform3D.Identity;
			transform.m34 = aFrame.Transform.M34;

			transform = CATransform3D.MakeRotation(
				aFrame.Transform.Rotate.Angle,
				aFrame.Transform.Rotate.X,
				aFrame.Transform.Rotate.Y,
				aFrame.Transform.Rotate.Z);

			// Scale
			transform.m11 = aFrame.Transform.Scale.Sx;
			transform.m22 = aFrame.Transform.Scale.Sy;
			transform.m33 = aFrame.Transform.Scale.Sz;

			// Translate
			transform.m41 = aFrame.Transform.Translate.Tx;
			transform.m42 = aFrame.Transform.Translate.Ty;
			transform.m43 = aFrame.Transform.Translate.Tz;

			//			transform.Rotate (
			//				aFrame.Transform.Rotate.Angle,
			//				aFrame.Transform.Rotate.X,
			//				aFrame.Transform.Rotate.Y,
			//				aFrame.Transform.Rotate.Z);
			//			transform.Scale (
			//				aFrame.Transform.Scale.Sx,
			//				aFrame.Transform.Scale.Sy,
			//				aFrame.Transform.Scale.Sz);
			//
			//			transform.Translate (
			//				aFrame.Transform.Translate.Tx,
			//				aFrame.Transform.Translate.Ty,
			//				aFrame.Transform.Translate.Tz);

			nativeView.Layer.Transform = transform;
		}


		public void TransformAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);

			AnimationFrame animationFrameTranform = Animation.AnimationFrameForTime(time) as AnimationFrame;

			// Store the current transform
			CGAffineTransform tempTransform = nativeView.Transform;

			// Reset rotation to 0 to avoid warping
			nativeView.Transform = CGAffineTransform.MakeRotation(0);
			nativeView.Frame = animationFrameTranform.Frame;

			// Return to original transform
			nativeView.Transform = tempTransform;
		}

		public void ColorAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);


			AnimationFrame colorAnimationFrame = Animation.AnimationFrameForTime(time) as AnimationFrame;
			nativeView.BackgroundColor = colorAnimationFrame.Color;
		}

		public void HideAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);
			nativeView.Hidden = animationFrame.Hidden;
		}

		public void ScaleAnimation(CustomView view, int time)
		{
			var animationFrame = Animation.CountKeyFrames(time);
			if (animationFrame == null) return;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);
			float scale = animationFrame.Scale;
			nativeView.Transform = CGAffineTransform.MakeScale(scale, scale);
		}

		/// <summary>
		/// Converts the forms to native.
		/// </summary>
		/// <returns>The forms to native.</returns>
		/// <param name="view">View.</param>
		/// <param name="size">Size.</param>
		public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
		{
			var renderer = Platform.CreateRenderer(view);

			renderer.NativeView.Frame = size;

			renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
			renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

			renderer.Element.Layout(size.ToRectangle());

			var nativeView = renderer.NativeView;

			nativeView.SetNeedsLayout();

			return nativeView;
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

		public AnimationFrameBase FrameForTime3D(int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Transform = new Transform3D();
			animationFrame.Transform.M34 = startKeyFrame.Transform.M34;


			//if (startKeyFrame.Transform.Translate != null) {
			Transform3DTranslate translate = new Transform3DTranslate();
			translate.Tx = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Tx, endKeyFrame.Transform.Translate.Tx, time);
			translate.Ty = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Ty, endKeyFrame.Transform.Translate.Ty, time);
			translate.Tz = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Tz, endKeyFrame.Transform.Translate.Tz, time);
			animationFrame.Transform.Translate = translate;
			//}

			//if (startKeyFrame.Transform.Rotate != null) {
			Transform3DRotate rotate = new Transform3DRotate();
			rotate.Angle = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Angle, endKeyFrame.Transform.Rotate.Angle, time);
			rotate.X = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.X, endKeyFrame.Transform.Rotate.X, time);
			rotate.Y = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Y, endKeyFrame.Transform.Rotate.Y, time);
			rotate.Z = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Z, endKeyFrame.Transform.Rotate.Z, time);
			animationFrame.Transform.Rotate = rotate;
			//}


			//if (startKeyFrame.Transform.Scale != null) {
			Transform3DScale scale = new Transform3DScale();
			scale.Sx = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sx, endKeyFrame.Transform.Scale.Sx, time);
			scale.Sy = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sy, endKeyFrame.Transform.Scale.Sy, time);
			scale.Sz = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sz, endKeyFrame.Transform.Scale.Sz, time);
			animationFrame.Transform.Scale = scale;
			//}
			return animationFrame;
		}


		public AnimationFrameBase FrameForTimeColor(int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{

			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			AnimationFrame animationFrame = new AnimationFrame();
			float startRed = 0.0f, startBlue = 0.0f, startGreen = 0.0f, startAlpha = 0.0f;
			float endRed = 0.0f, endBlue = 0.0f, endGreen = 0.0f, endAlpha = 0.0f;

			if (GetRed(startRed, startGreen, startBlue, startAlpha, startKeyFrame.Color) &&
				GetRed(endRed, endGreen, endBlue, endAlpha, endKeyFrame.Color))
			{
				float red = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startRed, endRed, time);
				float green = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startGreen, endGreen, time);
				float blue = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startBlue, endBlue, time);
				float alpha = Animation.TweenValueForStartTime(startKeyFrame.Time, endKeyFrame.Time, startAlpha, endAlpha, time);
				animationFrame.Color = UIColor.FromRGBA(red, green, blue, alpha);
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
		private bool GetRed(nfloat red, nfloat green, nfloat blue, nfloat alpha, UIColor color)
		{

			nfloat white;

			color.GetRGBA(out red, out green, out blue, out alpha);

			if (red != null && green != null && blue != null && alpha != null)
			{
				return true;
			}
			else if (color.GetWhite(out white, out alpha))
			{
				// Redundant?
				red = white;
				green = white;
				blue = white;
				return true;
			}

			return false;
		}



		public AnimationFrameBase FrameForTimeTransform(CustomView view, int time, AnimationFrameBase startKeyFrameBase, AnimationFrameBase endKeyFrameBase)
		{
			var startKeyFrame = startKeyFrameBase as AnimationFrame;
			var endKeyFrame = endKeyFrameBase as AnimationFrame;

			int startTime = startKeyFrame.Time;
			int endTime = endKeyFrame.Time;
			CGRect startLocation = startKeyFrame.Frame;
			CGRect endLocation = endKeyFrame.Frame;

			CGRect nativeViewSize = new CGRect(view.X, view.Y, view.Width, view.Height);
			UIView nativeView = ConvertFormsToNative(view, nativeViewSize);
			CGRect frame = nativeView.Frame;
			frame.Location =
				new PointF(
					Animation.TweenValueForStartTime(startTime, endTime, (Single)startLocation.GetMinX(), (Single)endLocation.GetMinX(), time),
					Animation.TweenValueForStartTime(startTime, endTime, (Single)startLocation.GetMinY(), (Single)endLocation.GetMinY(), time));
			frame.Size =
				new SizeF(Animation.TweenValueForStartTime(startTime, endTime, (Single)startLocation.Width, (Single)endLocation.Width, time),
					Animation.TweenValueForStartTime(startTime, endTime, (Single)startLocation.Height, (Single)endLocation.Height, time));

			AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Frame = frame;

			return animationFrame;
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

	}
}