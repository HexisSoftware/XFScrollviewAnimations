using System;
using Xamarin.Forms;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollviewAnimations.Plugin
{
	/// <summary>
	/// Scroll view animations.
	/// </summary>
    public class ScrollViewAnimations : Abstractions.Animation, IXFScrollviewAnimations
    {
		/// <summary>
		/// Adds the view.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="positionX">Position x.</param>
		/// <param name="positionY">Position y.</param>
        public Abstractions.Animation AddView(double width, double height, double positionX, double positionY)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation AlphaAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation AngleAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation ColorAnimation(AnimatedView view, int time)
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

		public AnimationFrameBase FrameForTimeTransform(AnimatedView view, int time, AnimationFrameBase startKeyFrame, AnimationFrameBase endKeyFrame)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation HideAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation ScaleAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation Transform3DAnimation(AnimatedView view, int time)
		{
			throw new NotImplementedException();
		}

		public Abstractions.Animation TransformAnimation(AnimatedView view, int time)
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

