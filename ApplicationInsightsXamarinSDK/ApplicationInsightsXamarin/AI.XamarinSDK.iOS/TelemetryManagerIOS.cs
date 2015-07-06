using System;
using UIKit;
using ObjCRuntime;
using Foundation;
using System.Collections.Generic;using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.iOS.TelemetryManagerIOS))]

namespace AI.XamarinSDK.iOS
{

	public class TelemetryManagerIOS : ITelemetryManager
	{

		public TelemetryManagerIOS(){}

		public void TrackEvent (string eventName)
		{
			MSAITelemetryManager.TrackEvent (eventName);
		}

		public void TrackEvent (string eventName, Dictionary<string, string> properties)
		{
			MSAITelemetryManager.TrackEvent (eventName, Utils.ConvertToNSDictionary (properties));
		}

		public void TrackTrace (string message)
		{
			MSAITelemetryManager.TrackTrace (message);
		}

		public void TrackTrace (string message, Dictionary<string, string> properties)
		{
			MSAITelemetryManager.TrackTrace (message, Utils.ConvertToNSDictionary (properties));
		}

		public void TrackMetric (string metricName, double value)
		{
			MSAITelemetryManager.TrackMetric (metricName, value);
		}

		public void TrackMetric (string metricName, double value, Dictionary<string, string> properties)
		{
			MSAITelemetryManager.TrackMetric (metricName, value, Utils.ConvertToNSDictionary (properties));
		}

		public void TrackPageView (string pageName)
		{
			MSAITelemetryManager.TrackPageView (pageName);
		}

		public void TrackPageView (string pageName, int duration)
		{
			MSAITelemetryManager.TrackPageView (pageName, duration);
		}

		public void TrackPageView (string pageName, int duration, Dictionary<string, string> properties)
		{
			MSAITelemetryManager.TrackPageView (pageName, duration, Utils.ConvertToNSDictionary (properties));
		}

		public void TrackManagedException (Exception  exception, bool handled)
		{
			if (exception != null) {
				string type = exception.GetType ().Name;
				string stacktrace = exception.StackTrace;
				string message = exception.Message;
				MSAITelemetryManager.TrackManagedException (type, message, stacktrace, handled);
			}	
		}
	}
}

