using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using UIKit;
using ObjCRuntime;
using Foundation;
using Xamarin.Forms;

using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.iOS.ApplicationInsights))]

namespace AI.XamarinSDK.iOS {
	[Preserve(AllMembers=true)]
	public class ApplicationInsights : IApplicationInsights {

		public ApplicationInsights() {}

		public static void Init() {
			var forceLoad = new ApplicationInsights ();
		}

		public void Setup (string instrumentationKey) {
			MSAIApplicationInsights.Setup (instrumentationKey);
		}

		public void Start () {
			MSAIApplicationInsights.Start ();
		}

		public string GetServerUrl () {
			return MSAIApplicationInsights.SharedInstance.ServerURL; 
		}

		public void SetServerUrl (string serverUrl) {
			MSAIApplicationInsights.SharedInstance.ServerURL = serverUrl; 
		}

		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled) {
			MSAIApplicationInsights.SetTelemetryManagerDisabled(telemetryManagerDisabled);
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled) {
			MSAIApplicationInsights.SetAutoPageViewTrackingDisabled (autoPageViewTrackingDisabled);
		}

		public void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled) {
			MSAIApplicationInsights.SetAutoSessionManagementDisabled (autoSessionManagementDisabled);
		}

		public void SetAuthUserId (string authUserId) {
			MSAIApplicationInsights.SetUser (delegate (MSAIUser user) {
				user.SetAuthUserId(authUserId);
			});
		}

		public void SetCommonProperties(Dictionary<string, string> properties) {
			MSAITelemetryManager.SetCommonProperties (Utils.ConvertToNSDictionary (properties));
		}

		public void StartNewSession () {
			MSAIApplicationInsights.StartNewSession ();
		}

		public void SetSessionExpirationTime (int appBackgroundTime) {
			MSAIApplicationInsights.SetAppBackgroundTimeBeforeSessionExpires ((nuint)appBackgroundTime);
		}

		public void RenewSessionWithId (string sessionId){
			MSAIApplicationInsights.RenewSessionWithId (sessionId);
		}

		public bool GetDebugLogEnabled() {
			return MSAIApplicationInsights.SharedInstance.DebugLogEnabled; 
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) {
			MSAIApplicationInsights.SharedInstance.DebugLogEnabled = debugLogEnabled; 
		}
	}
}

