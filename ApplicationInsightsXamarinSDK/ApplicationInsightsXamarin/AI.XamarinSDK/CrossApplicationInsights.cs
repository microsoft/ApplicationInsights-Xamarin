using System;

namespace AI.XamarinSDK
{
	/// <summary>
	/// This class exposes methods to configure and start the SDK. This is required in order to enable auto collection, crash reporting, and sending of telemetry data.
	/// </summary>
    public class CrossApplicationInsights
	{
        static Lazy<IApplicationInsights> Implementation = new Lazy<IApplicationInsights>(() => CreateApplicationInsights(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IApplicationInsights Current
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


        static IApplicationInsights CreateApplicationInsights()
        {
#if PORTABLE
        return null;
#else
            return new ApplicationInsights();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
	}
}
	