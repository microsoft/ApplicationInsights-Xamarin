using System;
using System.Collections.Generic;

namespace AI.XamarinSDK
{
	public interface ITelemetryManager
	{
		void TrackEvent (string eventName);

		void TrackEvent (string eventName, Dictionary<string, string> properties);

		void TrackTrace (string message);

		void TrackTrace (string message, Dictionary<string, string> properties);

		void TrackMetric (string metricName, double value);

		void TrackMetric (string metricName, double value, Dictionary<string, string> properties);

		void TrackPageView (string pageName);

		void TrackPageView (string pageName, int duration);

		void TrackPageView (string pageName, int duration, Dictionary<string, string> properties);

        void TrackManagedException (Exception  exception, bool handled);
	}
}