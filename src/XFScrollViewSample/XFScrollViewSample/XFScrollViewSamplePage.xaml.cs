using Xamarin.Forms;
using XFScrollviewAnimations.Plugin;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollViewSample
{
	public partial class XFScrollViewSamplePage : ContentPage
	{
		public XFScrollViewSamplePage()
		{
			InitializeComponent();

			var animatedView = new AnimatedView();
			animatedView.BackgroundColor = Color.Black;
			animatedView.WidthRequest = 50;
			animatedView.HeightRequest = 50;

			var scrollView = new AnimatedScrollView();
			scrollView.NumberOfPage = 2;
			scrollView.Content = new StackLayout
			{
				Children = {
					animatedView
				}
			};

			//Animations
			//var alphaAnimation = new CrossScrollViewAnimations();
			//Animator.Add
			var alphaAnimation = CrossScrollViewAnimations.Current.AlphaAnimation(animatedView, 1);
			var animator = new Animator();

			animator.AddAnimation(alphaAnimation);

			alphaAnimation.AddKeyFrame(new AnimationFrame()
			{
				Time = TimeForPage(1),
				Alpha = 0.0f
			});
			alphaAnimation.AddKeyFrame(new AnimationFrame()
			{
				Time = TimeForPage(2),
				Alpha = 1.0f
			});
		}
		 

		int TimeForPage(float page)
		{
			return (int)(this.Content.Width * (page - 1));
		}
	}
}
