using System;
using System.Collections.Generic;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.WinPhone.ApplicationInsights))]

namespace AI.XamarinSDK.WinPhone {
	public class ApplicationInsights : IApplicationInsights {

		public ApplicationInsights (){}

		public void Setup(string instrumentationKey) {
		}

		public void Start () {
		}

		public string GetServerUrl () {
			return null;
		}

		public void SetServerUrl (string serverUrl) {
		}

		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled) {
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled) {
		}

		public void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled) {
		}

		public void SetAuthUserId (string authUserId) {
		}

		public void SetCommonProperties(Dictionary<string, string> properties) {
		}

		public void StartNewSession (){
		}

		public void SetSessionExpirationTime (int appBackgroundTime) {
		}

		public void RenewSessionWithId (string sessionId)
		{
		}

		public bool GetDebugLogEnabled() {
			return false;
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) {
		}
	}
}

