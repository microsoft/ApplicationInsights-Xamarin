using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace AI.XamarinSDK
{
	public class TelemetryManager
	{
		public TelemetryManager(){}

		public static void TrackEvent (string eventName)
		{
			DependencyService.Get<ITelemetryManager>().TrackEvent(eventName);
		}

		public static void TrackEvent (string eventName, Dictionary<string, string> properties){
			DependencyService.Get<ITelemetryManager>().TrackEvent(eventName, properties);
		}

		public static void TrackEvent (string eventName, Dictionary<string, string> properties, Dictionary<string, double> measurements){
			DependencyService.Get<ITelemetryManager>().TrackEvent(eventName, properties, measurements);
		}

		public static void TrackTrace (string message){
			DependencyService.Get<ITelemetryManager>().TrackTrace(message);
		}

		public static void TrackTrace (string message, Dictionary<string, string> properties){
			DependencyService.Get<ITelemetryManager>().TrackTrace(message, properties);
		}

		public static void TrackMetric (string metricName, double value){
			DependencyService.Get<ITelemetryManager>().TrackMetric(metricName, value);
		}

		public static void TrackMetric (string metricName, double value, Dictionary<string, string> properties){
			DependencyService.Get<ITelemetryManager>().TrackMetric(metricName, value, properties);
		}

		public static void TrackPageView (string pageName){
			DependencyService.Get<ITelemetryManager>().TrackPageView(pageName);
		}

		public static void TrackPageView (string pageName, int duration){
			DependencyService.Get<ITelemetryManager>().TrackPageView(pageName, duration);
		}

		public static void TrackPageView (string pageName, int duration, Dictionary<string, string> properties){
			DependencyService.Get<ITelemetryManager>().TrackPageView(pageName, duration, properties);
		}

		public static void TrackManagedException (Exception  exception, bool handled){
			DependencyService.Get<ITelemetryManager>().TrackManagedException(exception, handled);
		}
	}
}
