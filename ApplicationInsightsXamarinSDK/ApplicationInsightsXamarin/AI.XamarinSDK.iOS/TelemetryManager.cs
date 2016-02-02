using System;
using UIKit;
using ObjCRuntime;
using Foundation;
using System.Collections.Generic;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(AI.XamarinSDK.iOS.TelemetryManager))]
namespace AI.XamarinSDK.iOS
{
	[Preserve(AllMembers = true)]
	public class TelemetryManager : ITelemetryManager
	{

		public TelemetryManager()
		{
		}

		public void TrackEvent(string eventName)
		{
			MSAITelemetryManager.TrackEvent(eventName);
		}

		public void TrackEvent(string eventName, Dictionary<string, string> properties)
		{
			if (properties != null)
				MSAITelemetryManager.TrackEvent(eventName, Utils.ConvertToNSDictionary(properties));
			else
				MSAITelemetryManager.TrackEvent(eventName);
		}

		public void TrackTrace(string message)
		{
			MSAITelemetryManager.TrackTrace(message);
		}

		public void TrackTrace(string message, Dictionary<string, string> properties)
		{
			if (properties != null)
				MSAITelemetryManager.TrackTrace(message, Utils.ConvertToNSDictionary(properties));
			else
				MSAITelemetryManager.TrackTrace(message);
		}

		public void TrackMetric(string metricName, double value)
		{
			MSAITelemetryManager.TrackMetric(metricName, value);
		}

		public void TrackMetric(string metricName, double value, Dictionary<string, string> properties)
		{
			if (properties != null)
				MSAITelemetryManager.TrackMetric(metricName, value, Utils.ConvertToNSDictionary(properties));
			else
				MSAITelemetryManager.TrackMetric(metricName, value);
		}

		public void TrackPageView(string pageName)
		{
			MSAITelemetryManager.TrackPageView(pageName);
		}

		public void TrackPageView(string pageName, int duration)
		{
			MSAITelemetryManager.TrackPageView(pageName, duration);
		}

		public void TrackPageView(string pageName, int duration, Dictionary<string, string> properties)
		{
			if (properties != null)
				MSAITelemetryManager.TrackPageView(pageName, duration, Utils.ConvertToNSDictionary(properties));
			else
				MSAITelemetryManager.TrackPageView(pageName, duration);
		}

		public void TrackManagedException(Exception  exception, bool handled)
		{
			if (exception != null)
			{
				string type = exception.GetType().Name;
				string stacktrace = exception.StackTrace ?? string.Empty;
				string message = exception.Message;
				MSAITelemetryManager.TrackManagedException(type, message, stacktrace, handled);
			}	
		}
	}
}

