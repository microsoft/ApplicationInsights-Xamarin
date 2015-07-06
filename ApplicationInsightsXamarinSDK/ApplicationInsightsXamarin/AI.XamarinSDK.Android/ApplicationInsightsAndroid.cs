using System;
using Android.Runtime;
using Android.App;
using Android.Content;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.Android.ApplicationInsightsAndroid))]

namespace AI.XamarinSDK.Android
{
	public class ApplicationInsightsAndroid : Java.Lang.Object, IApplicationInsights
	{
		private static bool _crashManagerDisabled = false;

		public ApplicationInsightsAndroid (){}

		public void Setup(string instrumentationKey)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Setup (Application.Context, null, instrumentationKey);
		}

		public void Setup (Context context, Application application, string instrumentationKey)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Setup (context, application, instrumentationKey);
		}

		public void Start ()
		{
			registerUnhandledExceptionHandler ();
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Start ();
		}

		public string GetServerUrl ()
		{
			return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.EndpointUrl;
		}

		public void SetServerUrl (string serverUrl)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.EndpointUrl = serverUrl;
		}

		public void  SetCrashManagerDisabled (bool crashManagerDisabled)
		{
			_crashManagerDisabled = crashManagerDisabled;
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetExceptionTrackingDisabled(crashManagerDisabled);
		}

		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetTelemetryDisabled(telemetryManagerDisabled);
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled)
		{
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

		public void SetUserId (string userId)
		{
			ApplicationInsights.SetUserId (userId);
		}

		public void StartNewSession (){
		}

		public void SetSessionExpirationTime (int appBackgroundTime)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.Config.SessionIntervalMs = appBackgroundTime;
		}

		public void RenewSessionWithId (string sessionId)
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.RenewSession (sessionId);
		}

		public bool GetDebugLogEnabled() 
		{
			return Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode;
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) 
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.DeveloperMode = debugLogEnabled;
		}

		private void registerUnhandledExceptionHandler()
		{
			Com.Microsoft.Applicationinsights.Library.ApplicationInsights.SetExceptionTrackingDisabled (true);
			if (!_crashManagerDisabled) {
				AndroidEnvironment.UnhandledExceptionRaiser += OnUnhandledExceptionRaiser;
			}
		}

		public void OnUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
		{
			Exception managedException = (Exception)e.Exception;
			if (managedException != null) {
				TelemetryManager.TrackManagedException (managedException, false);
			}	
		}
	}
}

