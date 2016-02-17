using System;
using System.Collections.Generic;
using Android;
using Android.Runtime;
using Android.App;
using Android.Content;
using AI.XamarinSDK.Abstractions;
using Com.Microsoft.Applicationinsights.Library;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.Android.TelemetryManager))]
namespace AI.XamarinSDK.Android
{
	[Preserve(AllMembers=true)]
	public class TelemetryManager : Java.Lang.Object, ITelemetryManager {

		public TelemetryManager() {}

		public void TrackEvent (string eventName) {
			TelemetryClient.Instance.TrackEvent (eventName);
		}

		public void TrackEvent (string eventName, Dictionary<string, string> properties) {
			TelemetryClient.Instance.TrackEvent (eventName, properties);
		}

		public void TrackTrace (string message)	{
			TelemetryClient.Instance.TrackTrace (message);
		}

		public void TrackTrace (string message, Dictionary<string, string> properties) {
			TelemetryClient.Instance.TrackTrace (message, properties);
		}

		public void TrackMetric (string metricName, double value) {
			TelemetryClient.Instance.TrackMetric (metricName, value);
		}

		public void TrackMetric (string metricName, double value, Dictionary<string, string> properties) {
			TelemetryClient.Instance.TrackMetric (metricName, value);
		}

		public void TrackPageView (string pageName)	{
			TelemetryClient.Instance.TrackPageView (pageName);
		}

		public void TrackPageView (string pageName, int duration) {
			TelemetryClient.Instance.TrackPageView (pageName);
		}

		public void TrackPageView (string pageName, int duration, Dictionary<string, string> properties) {
			TelemetryClient.Instance.TrackPageView (pageName, properties);
		}
	}
}

