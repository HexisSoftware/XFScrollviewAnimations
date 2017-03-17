using System;
using Foundation;
using ObjCRuntime;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AnimatedScrollView), typeof(AnimatedScrollViewiOSRenderer))]
namespace XFScrollviewAnimations.Plugin
{

	public interface IAnimatedScrollViewController
	{
		NSObject WeakDelegate { get; set; }
		void AnimatedScrollViewControllerDidScrollToEnd(AnimatedScrollViewiOSRenderer animatedScrollViewController);
		void AnimatedScrollViewControllerDidEndDraggingAtEnd(AnimatedScrollViewiOSRenderer animatedScrollViewController);
	}

	public class AnimatedScrollViewiOSRenderer : ScrollViewRenderer
	{
		public Animator Animator { get; set; }
		public UIScrollView ScrollView { get; set; }

		public IAnimatedScrollViewController animatedScrolledService;

		private bool _isAtEnd;
		private UIScrollView nativeScrollView { get; set; }

		static nfloat MaxContentOffsetXForScrollView(UIScrollView scrollView)
		{
			return scrollView.ContentSize.Width + scrollView.ContentInset.Right - scrollView.Bounds.Width;
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (this.NativeView == null)
			{
				return;
			}

			nativeScrollView = (UIScrollView)this.NativeView;
			_isAtEnd = false;
			Animator = new Animator();

			ScrollView = new UIScrollView(nativeScrollView.Bounds);
			ScrollView.Scrolled += (sender, args) =>
		   {
			   Animator.Animate(Convert.ToInt32(ScrollView.ContentOffset.X));

			   _isAtEnd = ScrollView.ContentOffset.X >= MaxContentOffsetXForScrollView(ScrollView);

				//animatedScrolledService = ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidScrollToEnd:")))
			   {
					//animatedScrolledService.AnimatedScrollViewControllerDidScrollToEnd(this);
				}
		   };

			ScrollView.ScrollAnimationEnded += (sender, args) =>
			{
				//WeakDelegate = scrollView.Delegate;
				//animatedScrolledService =  ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidEndDraggingAtEnd:")))
				{
					//animatedScrolledService.AnimatedScrollViewControllerDidEndDraggingAtEnd(this);
				}
			};

			nativeScrollView.Add(ScrollView);
		}
	}
}
