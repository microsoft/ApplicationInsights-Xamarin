using System;
using System.Collections.Generic;
using Android;
using Android.Runtime;
using Android.App;
using Android.Content;
using Xamarin.Forms;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.Android.ApplicationInsights))]
namespace AI.XamarinSDK.Android  {
	
	[Preserve(AllMembers=true)]
	public class ApplicationInsights : Java.Lang.Object, IApplicationInsights {

		public ApplicationInsights (){}

		public void Setup(string instrumentationKey) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Setup (((Activity)Forms.Context).Application, ((Activity)Forms.Context).Application, instrumentationKey);
		}

		public void Start () {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Start ();
		}

		public string GetServerUrl () {
			return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Configuration.EndpointUrl;
		}

		public void SetServerUrl (string serverUrl)	{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Configuration.EndpointUrl = serverUrl;
		}
			
		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled)	{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetTelemetryDisabled(telemetryManagerDisabled);
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled)	{
			if (autoPageViewTrackingDisabled) {
				Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DisableAutoPageViewTracking();
			} else {
				Com.Microsoft.Applicationinsights.Library.ApplicationInsights.EnableAutoPageViewTracking();
			}
		}

		public void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled)
		{
			if (autoSessionManagementDisabled) {
				Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DisableAutoSessionManagement();
			} else {
				Com.Microsoft.Applicationinsights.Library.ApplicationInsights.EnableAutoSessionManagement();
			}
		}

		public void SetAuthUserId (string authUserId) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.TelemetryContext.AuthenticatedUserId = authUserId;
		}

		public void SetCommonProperties(Dictionary<string, string> properties) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.CommonProperties = properties;
		}

		public void StartNewSession () {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.RenewSession (null);
		}

		public void SetSessionExpirationTime (int appBackgroundTime) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Configuration.SessionIntervalMs = appBackgroundTime;
		}

		public void RenewSessionWithId (string sessionId) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.RenewSession (sessionId);
		}

		public bool GetDebugLogEnabled() {
			return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode;
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) {
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode = debugLogEnabled;
		}
	}
}

