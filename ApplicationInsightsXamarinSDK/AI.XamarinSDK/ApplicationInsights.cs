using System;

#if __ANDROID__
using Android.App;
using Android.Content;
#endif

namespace AI.XamarinSDK
{
	public class ApplicationInsights
	{

		private static readonly IApplicationInsights target = Xamarin.Forms.DependencyService.Get<IApplicationInsights> ();

		private ApplicationInsights() {}

		public static void Setup (string instrumentationKey){
			target.Setup (instrumentationKey);
		}

		#if __ANDROID__
		public static void Setup (Context context, Application application, string instrumentationKey){
			target.Setup (context, application, instrumentationKey);
		}
		#endif

		public static void Start (){
			target.Start ();
		}

		public static string GetServerUrl (){
			return target.GetServerUrl ();
		}

		public static void SetServerUrl (string serverUrl){
			target.SetServerUrl (serverUrl);
		}

		public static void SetCrashManagerDisabled (bool crashManagerDisabled){
			target.SetCrashManagerDisabled (crashManagerDisabled);
		}

		public static void SetTelemetryManagerDisabled (bool telemetryManagerDisabled){
			target.SetTelemetryManagerDisabled (telemetryManagerDisabled);
		}

		public static void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled){
			target.SetAutoPageViewTrackingDisabled  (autoPageViewTrackingDisabled);
		}

		public static void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled){
			target.SetAutoSessionManagementDisabled  (autoSessionManagementDisabled);
		}

		public static void SetUserId (string userId){
			target.SetUserId  (userId);
		}

		public static void StartNewSession (){
			target.StartNewSession  ();
		}

		public static void SetSessionExpirationTime (int appBackgroundTime){
			target.SetSessionExpirationTime (appBackgroundTime);
		}

		public static void RenewSessionWithId (string sessionId){
			target.RenewSessionWithId (sessionId);
		}

		public static bool GetAppStoreEnvironment(){
			return target.GetAppStoreEnvironment ();
		}

		public static bool GetDebugLogEnabled(){
			return target.GetDebugLogEnabled ();
		}

		public static void SetDebugLogEnabled(bool debugLogEnabled){
			target.SetDebugLogEnabled (debugLogEnabled);
		}
	}
}

