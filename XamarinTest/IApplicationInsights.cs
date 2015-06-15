using System;
using Android.App;
using Android.Content;

namespace XamarinTest
{
	public interface IApplicationInsights
	{
		void Setup (string instrumentationKey);

		void Setup (Context context, Application application, string instrumentationKey);

		void Start ();

		string GetServerUrl ();

		void SetServerUrl (string serverUrl);

		void SetCrashManagerDisabled (bool crashManagerDisabled);

		void SetTelemetryManagerDisabled (bool telemetryManagerDisabled);

		void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled);

		void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled);

		void SetUserId (string userId);

		void StartNewSession ();

		void SetSessionExpirationTime (int appBackgroundTime);

		void RenewSessionWithId (string sessionId);

		bool GetAppStoreEnvironment() ;

		bool GetDebugLogEnabled() ;

		void SetDebugLogEnabled(bool debugLogEnabled);
	}
}

