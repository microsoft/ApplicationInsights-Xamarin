using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace AI.XamarinSDK.Abstractions
{
	/// <summary>
	/// This class exposes functions to track differnt types of telemetry data. Tracked data will be created, persisted, and sent to the server.
	/// </summary>
	public class TelemetryManager
	{
		public TelemetryManager(){}

		/// <summary>
		/// Tracks a custom event object
		/// </summary>
		/// <param name="eventName">The name of the custom event.</param>
		public static void TrackEvent (string eventName)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackEvent(eventName);
			}
		}

		/// <summary>
		/// Tracks a custom event object
		/// </summary>
		/// <param name="eventName">The name of the custom event.</param>
		/// <param name="properties">Custom properties that should be added to this event.</param>
		public static void TrackEvent (string eventName, Dictionary<string, string> properties)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackEvent(eventName, properties);
			}
		}

		/// <summary>
		/// Tracks a custom message
		/// </summary>
		/// <param name="message">The message to be tracked.</param>
		public static void TrackTrace (string message)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackTrace(message);
			}
		}

		/// <summary>
		/// Tracks a custom message
		/// </summary>
		/// <param name="message">The message to be tracked.</param>
		/// <param name="properties">Custom properties that should be added to this message.</param>
		public static void TrackTrace (string message, Dictionary<string, string> properties)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackTrace(message, properties);
			}
		}

		/// <summary>
		/// Tracks a custom metric.
		/// </summary>
		/// <param name="metricName">The name of the metric.</param>
		/// <param name="value">The numeric metric value.</param>
		public static void TrackMetric (string metricName, double value)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackMetric(metricName, value);
			}
		}

		/// <summary>
		/// Tracks a custom metric.
		/// </summary>
		/// <param name="metricName">The name of the metric.</param>
		/// <param name="value">The numeric metric value.</param>
		/// <param name="properties">Custom properties that should be added to this metric.</param>
		public static void TrackMetric (string metricName, double value, Dictionary<string, string> properties)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackMetric(metricName, value, properties);
			}
		}

		/// <summary>
		/// Tracks a page view.
		/// </summary>
		/// <param name="pageName">The name of the page.</param>
		public static void TrackPageView (string pageName)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackPageView(pageName);
			}
		}

		/// <summary>
		/// Tracks a page view.
		/// </summary>
		/// <param name="pageName">The name of the page.</param>
		/// <param name="duration">The time the page was visible to the user</param>
		public static void TrackPageView (string pageName, int duration)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackPageView(pageName, duration);
			}
		}

		/// <summary>
		/// Tracks a page view.
		/// </summary>
		/// <param name="pageName">The name of the page.</param>
		/// <param name="duration">The time the page was visible to the user</param>
		/// <param name="properties">Custom properties that should be added to this page view object.</param>
		public static void TrackPageView (string pageName, int duration, Dictionary<string, string> properties)
		{
			if (Utils.IsSupportedPlatform ()) {
				DependencyService.Get<ITelemetryManager>().TrackPageView(pageName, duration, properties);
			}
		}
	}
}
