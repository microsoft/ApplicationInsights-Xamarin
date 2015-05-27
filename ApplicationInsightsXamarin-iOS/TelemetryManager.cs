using System;
using ApplicationInsightsIOS;
using ObjCRuntime;
using Foundation;

namespace ApplicationInsightsXamarinIOS
{
	public class TelemetryManager
	{

		public static void TrackEvent (string eventName){
			MSAITelemetryManager.TrackEventWithName (eventName);
		}

		public static void TrackEvent (string eventName, NSDictionary properties){
			MSAITelemetryManager.TrackEventWithName (eventName, properties);
		}

		public static void TrackEvent (string eventName, NSDictionary properties, NSDictionary measurements){
			MSAITelemetryManager.TrackEventWithName (eventName, properties, measurements);
		}

		public static void TrackTrace (string message){
			MSAITelemetryManager.TrackTraceWithMessage (message);
		}

		public static void TrackTrace (string message, NSDictionary properties){
			MSAITelemetryManager.TrackTraceWithMessage (message, properties);
		}

		public static void TrackMetric (string metricName, double value){
			MSAITelemetryManager.TrackMetricWithName (metricName, value);
		}

		public static void TrackMetric (string metricName, double value, NSDictionary properties){
			MSAITelemetryManager.TrackMetricWithName (metricName, value, properties);
		}

		public static void TrackPageView (string pageName){
			MSAITelemetryManager.TrackPageView (pageName);
		}

		public static void TrackPageView (string pageName, nint duration){
			MSAITelemetryManager.TrackPageView (pageName, duration);
		}

		public static void TrackPageView (string pageName, nint duration, NSDictionary properties){
			MSAITelemetryManager.TrackPageView (pageName, duration, properties);
		}

		public static void TrackException (NSException exception){
			MSAITelemetryManager.TrackException (exception);
		}
	}
}

