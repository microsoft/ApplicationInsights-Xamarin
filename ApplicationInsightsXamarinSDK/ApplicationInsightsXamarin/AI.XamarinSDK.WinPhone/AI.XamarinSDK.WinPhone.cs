using System;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.WinPhone.ApplicationInsightsWinPhone))]

namespace AI.XamarinSDK.WinPhone
{
	public class ApplicationInsightsWinPhone : IApplicationInsights
	{
		private static bool _crashManagerDisabled = false;

		public ApplicationInsightsWinPhone (){}

		public void Setup(string instrumentationKey)
		{
		}

		public void Start ()
		{
		}

		public string GetServerUrl ()
		{
			return null;
		}

		public void SetServerUrl (string serverUrl)
		{
		}

		public void  SetCrashManagerDisabled (bool crashManagerDisabled)
		{
		}

		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled)
		{
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled)
		{
		}

		public void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled)
		{
		}

		public void SetUserId (string userId)
		{
		}

		public void StartNewSession (){
		}

		public void SetSessionExpirationTime (int appBackgroundTime)
		{
		}

		public void RenewSessionWithId (string sessionId)
		{
		}

		public bool GetDebugLogEnabled() 
		{
			return false;
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) 
		{
		}
	}
}

