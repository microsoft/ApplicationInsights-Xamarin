using System;

#if __ANDROID__
using Android.App;
using Android.Content;
#endif

namespace AI.XamarinSDK
{
	public class ApplicationInsights
	{
		public ApplicationInsights(){}

		public static void Setup (string instrumentationKey){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().Setup (instrumentationKey);
		}

		#if __ANDROID__
		public static void Setup (Context context, Application application, string instrumentationKey){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().Setup (context, application, instrumentationKey);
		}
		#endif

		public static void Start (){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().Start ();
		}

		public static string GetServerUrl (){
			return Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().GetServerUrl ();
		}

		public static void SetServerUrl (string serverUrl){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetServerUrl (serverUrl);
		}

		public static void SetCrashManagerDisabled (bool crashManagerDisabled){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetCrashManagerDisabled (crashManagerDisabled);
		}

		public static void SetTelemetryManagerDisabled (bool telemetryManagerDisabled){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetTelemetryManagerDisabled (telemetryManagerDisabled);
		}

		public static void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetAutoPageViewTrackingDisabled  (autoPageViewTrackingDisabled);
		}

		public static void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetAutoSessionManagementDisabled  (autoSessionManagementDisabled);
		}

		public static void SetUserId (string userId){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetUserId  (userId);
		}

		public static void StartNewSession (){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().StartNewSession  ();
		}

		public static void SetSessionExpirationTime (int appBackgroundTime){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetSessionExpirationTime (appBackgroundTime);
		}

		public static void RenewSessionWithId (string sessionId){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().RenewSessionWithId (sessionId);
		}

		public static bool GetAppStoreEnvironment(){
			return Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().GetAppStoreEnvironment ();
		}

		public static bool GetDebugLogEnabled(){
			return Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().GetDebugLogEnabled ();
		}

		public static void SetDebugLogEnabled(bool debugLogEnabled){
			Xamarin.Forms.DependencyService.Get<IApplicationInsights> ().SetDebugLogEnabled (debugLogEnabled);
		}
	}
}

