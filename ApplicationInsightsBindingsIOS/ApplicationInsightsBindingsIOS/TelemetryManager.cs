using System;
using ApplicationInsightsIOS;
using ObjCRuntime;
using Foundation;

namespace ApplicationInsightsIOS
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

		public static void TrackManagedException (Exception  exception, bool handled){
			if (exception != null) {
				string type = exception.GetType ().Name;
				string stacktrace = exception.StackTrace;
				string message = exception.Message;
				MSAITelemetryManager.TrackManagedException (type, message, stacktrace, handled);
			}	
		}
	}
}