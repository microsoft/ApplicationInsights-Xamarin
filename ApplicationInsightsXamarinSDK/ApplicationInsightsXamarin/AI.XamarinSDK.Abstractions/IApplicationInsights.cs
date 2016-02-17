using System;

namespace AI.XamarinSDK.Abstractions
{
	public interface IApplicationInsights
	{
		void Setup (string instrumentationKey);

		void Start ();

		string GetServerUrl ();

		void SetServerUrl (string serverUrl);

		void SetTelemetryManagerDisabled (bool telemetryManagerDisabled);

		void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled);

		void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled);

		void SetUserId (string userId);

		void StartNewSession ();

		void SetSessionExpirationTime (int appBackgroundTime);

		void RenewSessionWithId (string sessionId);

		bool GetDebugLogEnabled() ;

		void SetDebugLogEnabled(bool debugLogEnabled);
	}
}

