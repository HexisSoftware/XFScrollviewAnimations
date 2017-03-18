using System;
using System.Runtime.CompilerServices;

namespace XFScrollviewAnimations.Plugin.Abstractions
{
	public abstract class AnimationFrameBase
	{
		//
		// Properties
		//

		public bool Hidden { get; set; }
		public Single Alpha { get; set; }
		public Single Angle { get; set; }
		public Single Scale { get; set; }
		public int Time { get; set; }


		//
		// Constructors
		//
		//protected AnimationFrameBase();
	}
}
