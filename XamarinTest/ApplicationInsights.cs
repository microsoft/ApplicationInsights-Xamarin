using System;
using Xamarin.Forms;

#if __ANDROID__
using Android.App;
using Android.Content;
#endif

namespace XamarinTest
{
	public class ApplicationInsights
	{
		public ApplicationInsights(){}

		public static void Setup (string instrumentationKey){
			DependencyService.Get<IApplicationInsights> ().Setup (instrumentationKey);
		}

		#if __ANDROID__
		public static void Setup (Context context, Application application, string instrumentationKey){
			DependencyService.Get<IApplicationInsights> ().Setup (context, application, instrumentationKey);
		}
		#endif

		public static void Start (){
			DependencyService.Get<IApplicationInsights> ().Start ();
		}

		public static string GetServerUrl (){
			return DependencyService.Get<IApplicationInsights> ().GetServerUrl ();
		}

		public static void SetServerUrl (string serverUrl){
			DependencyService.Get<IApplicationInsights> ().SetServerUrl (serverUrl);
		}

		public static void SetCrashManagerDisabled (bool crashManagerDisabled){
			DependencyService.Get<IApplicationInsights> ().SetCrashManagerDisabled (crashManagerDisabled);
		}

		public static void SetTelemetryManagerDisabled (bool telemetryManagerDisabled){
			DependencyService.Get<IApplicationInsights> ().SetTelemetryManagerDisabled (telemetryManagerDisabled);
		}

		public static void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled){
			DependencyService.Get<IApplicationInsights> ().SetAutoPageViewTrackingDisabled  (autoPageViewTrackingDisabled);
		}

		public static void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled){
			DependencyService.Get<IApplicationInsights> ().SetAutoSessionManagementDisabled  (autoSessionManagementDisabled);
		}

		public static void SetUserId (string userId){
			DependencyService.Get<IApplicationInsights> ().SetUserId  (userId);
		}

		public static void StartNewSession (){
			DependencyService.Get<IApplicationInsights> ().StartNewSession  ();
		}

		public static void SetSessionExpirationTime (int appBackgroundTime){
			DependencyService.Get<IApplicationInsights> ().SetSessionExpirationTime (appBackgroundTime);
		}

		public static void RenewSessionWithId (string sessionId){
			DependencyService.Get<IApplicationInsights> ().RenewSessionWithId (sessionId);
		}

		public static bool GetAppStoreEnvironment(){
			return DependencyService.Get<IApplicationInsights> ().GetAppStoreEnvironment ();
		}

		public static bool GetDebugLogEnabled(){
			return DependencyService.Get<IApplicationInsights> ().GetDebugLogEnabled ();
		}

		public static void SetDebugLogEnabled(bool debugLogEnabled){
			DependencyService.Get<IApplicationInsights> ().SetDebugLogEnabled (debugLogEnabled);
		}
	}
}

