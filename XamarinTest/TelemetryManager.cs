using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class TelemetryManager
	{
		public TelemetryManager(){}

		public static void TrackEvent (string eventName)
		{
			DependencyService.Get<ITelemetryManager>().TrackEvent(eventName);
		}
	}
}

