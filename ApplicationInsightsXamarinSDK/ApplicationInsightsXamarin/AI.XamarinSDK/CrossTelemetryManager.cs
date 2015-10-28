using System;
using System.Collections.Generic;

namespace AI.XamarinSDK
{
	/// <summary>
	/// This class exposes functions to track differnt types of telemetry data. Tracked data will be created, persisted, and sent to the server.
	/// </summary>
	public abstract class CrossTelemetryManager
	{
        static Lazy<ITelemetryManager> Implementation = new Lazy<ITelemetryManager>(() => CreateTelemetryManager(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static ITelemetryManager Current
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


        static ITelemetryManager CreateTelemetryManager()
        {
#if PORTABLE
            return null;
#else
            return new TelemetryManager();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
	}
}
