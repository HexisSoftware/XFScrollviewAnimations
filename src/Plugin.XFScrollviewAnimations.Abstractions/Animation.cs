using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Plugin.XFScrollviewAnimations.Abstractions
{
	public abstract class Animation
	{
		//protected View AnimView;
		public static List<AnimationFrameBase> KeyFrames;

		public static List<AnimationFrameBase> _timeline;
		// AnimationFrames
		public static int _startTime;
		// in case timeline starts before t=0

		//public Animation (View view)
		public Animation()
		{
			//AnimView = view;
			InitAnimation();
		}

		private void InitAnimation()
		{
			KeyFrames = new List<AnimationFrameBase>();
			_timeline = new List<AnimationFrameBase>();
			_startTime = 0;
		}

		public void AddKeyFrames(List<AnimationFrameBase> keyFrames)
		{
			foreach (AnimationFrameBase keyFrame in keyFrames)
			{
				AddKeyFrame(keyFrame);
			}
		}

		public static void AddKeyFrame(AnimationFrameBase keyFrame)
		{

			Debug.WriteLine(string.Format("Add KeyFrame Time: {0}", keyFrame.Time));

			if (KeyFrames.Count() == 0)
			{
				KeyFrames.Add(keyFrame);
				return;
			}

			// because folks might add keyframes out of order, we have to sort here
			if (keyFrame.Time > ((AnimationFrameBase)KeyFrames.Last()).Time)
			{
				KeyFrames.Add(keyFrame);
			}
			else
			{
				for (int i = 0; i < KeyFrames.Count(); i++)
				{
					if (keyFrame.Time < ((AnimationFrameBase)KeyFrames[i]).Time)
					{
						KeyFrames.Add(keyFrame);// TODO atIndex:i;
						break;
					}
				}
			}

			_timeline = new List<AnimationFrameBase>();
			for (int i = 0; i < KeyFrames.Count() - 1; i++)
			{
				AnimationFrameBase currentKeyFrame = KeyFrames[i];
				AnimationFrameBase nextKeyFrame = KeyFrames[i + 1];

				for (int j = currentKeyFrame.Time + (i == 0 ? 0 : 1); j <= nextKeyFrame.Time; j++)
				{
					var alphaFrame = FrameForTimeAlpha(j, currentKeyFrame, nextKeyFrame);
					if (alphaFrame != null)
						_timeline.Add(alphaFrame);
					
					var angleFrame = FrameForTimeAngle(j, currentKeyFrame, nextKeyFrame);
					if (angleFrame != null)
						_timeline.Add(angleFrame);

					var transform3DFrame = FrameForTime3D(j, currentKeyFrame, nextKeyFrame);
					if (transform3DFrame != null)
						_timeline.Add(transform3DFrame);
					
					var colorFrame = FrameForTimeColor(j, currentKeyFrame, nextKeyFrame);
					if (colorFrame != null)
						_timeline.Add(colorFrame);

					var transformFrame = FrameForTimeTransform(j, currentKeyFrame, nextKeyFrame);
					if (transformFrame != null)
						_timeline.Add(transformFrame);

					var hideFrame = FrameForTimeHide(j, currentKeyFrame, nextKeyFrame);
					if (hideFrame != null)
						_timeline.Add(hideFrame);
				}
			}
			_startTime = ((AnimationFrameBase)KeyFrames[0]).Time;
		}

		public static AnimationFrameBase FrameForTimeAlpha(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			Debug.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
			return startKeyFrame;
		}

		public static AnimationFrameBase FrameForTimeAngle(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			Debug.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
			return startKeyFrame;
		}

		public static AnimationFrameBase FrameForTime3D(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			return startKeyFrame;
		}

		public static AnimationFrameBase FrameForTimeColor(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			return startKeyFrame;
		}

		public static AnimationFrameBase FrameForTimeTransform(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			return startKeyFrame;
		}

		public static AnimationFrameBase FrameForTimeHide(int time,
			AnimationFrameBase startKeyFrame,
			AnimationFrameBase endKeyFrame)
		{
			return startKeyFrame;
		}

		public static AnimationFrameBase AnimationFrameForTime(int time)
		{
			if (time < _startTime)
			{
				return _timeline[0];
			}

			if (time - _startTime < _timeline.Count())
			{
				return _timeline[time - _startTime];
			}

			return _timeline.Last();
		}

		public void Animate(int time)
		{
		}

		public static AnimationFrameBase CountKeyFrames(int time)
		{
			if (Animation.KeyFrames.Count() <= 1) return null;

			var animationFrame = AnimationFrameForTime(time);
			return animationFrame;
		}

		public static Single TweenValueForStartTime(int startTime,
												 int endTime,
												 Single startValue,
												 Single endValue,
												 Single time)
		{
			Single dt = (endTime - startTime);
			Single timePassed = (time - startTime);
			Single dv = (endValue - startValue);
			Single vv = dv / dt;
			return (timePassed * vv) + startValue;
		}

	}
}