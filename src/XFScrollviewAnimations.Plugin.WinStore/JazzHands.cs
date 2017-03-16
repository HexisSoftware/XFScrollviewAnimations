using XFScrollviewAnimations.Plugin.Abstractions;
using System.Diagnostics;

namespace XFScrollviewAnimations.Plugin
{
    /// <summary>
    /// Vibration implemenation on Windows Store
    /// </summary>
    public class JazzHands : IJazzHands
  {
    /// <summary>
    /// Vibration (no effect windows store)
    /// </summary>
    /// <param name="milliseconds">milliseconds to vibrate for</param>
    public void Vibration(int milliseconds = 500)
    {
      Debug.WriteLine("Vibration not supported on Windows Store apps.");
    }
  }
}
