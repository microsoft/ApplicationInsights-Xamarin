using System;
using System.Collections.Generic;

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

		void SetAuthUserId (string authUserId);

		void SetCommonProperties (Dictionary<string, string> properties);

		void StartNewSession ();

		void SetSessionExpirationTime (int appBackgroundTime);

		void RenewSessionWithId (string sessionId);

		bool GetDebugLogEnabled() ;

		void SetDebugLogEnabled(bool debugLogEnabled);
	}
}

