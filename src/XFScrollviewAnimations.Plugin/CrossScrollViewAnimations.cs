using System;
using XFScrollviewAnimations.Plugin.Abstractions;

namespace XFScrollviewAnimations.Plugin
{
    /// <summary>
    /// 
    /// </summary>
    public static class CrossScrollViewAnimations
    {
		static Lazy<IXFScrollviewAnimations> Implementation = new Lazy<IXFScrollviewAnimations>(() => CreateAnimation(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IXFScrollviewAnimations Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IXFScrollviewAnimations CreateAnimation()
        {
		#if PORTABLE
		            return null;
		#else
		            return new ScrollViewAnimations();
		#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the HexisSoftware.Plugins.XFScrollviewAnimations NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
