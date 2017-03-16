using System;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollviewAnimations.Plugin
{
    /// <summary>
    /// Implementation to vibrate device
    /// </summary>
    public class ScrollViewAnimations : IScrollViewAnimations
    {
        /// <summary>
        /// Vibrate device with default length
        /// </summary>
        /// <param name="milliseconds">Ignored (iOS doesn't expose)</param>
        public void AddView(double width, double height, double positionX, double positionY)
		{
		}
    }
}

