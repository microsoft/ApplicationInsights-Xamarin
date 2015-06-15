using System;
using Android.App;
using Android.Content;
using Xamarin.Forms;

namespace XamarinTest
{
	public class ApplicationInsights
	{
		public ApplicationInsights(){}

		public static void Setup (string instrumentationKey){
			DependencyService.Get<IApplicationInsights> ().Setup (instrumentationKey);
		}

		public static void Setup (Context context, Android.App.Application application, string instrumentationKey){
			DependencyService.Get<IApplicationInsights> ().Setup (context, application, instrumentationKey);
		}

		public static void Start (){
			DependencyService.Get<IApplicationInsights> ().Start ();
		}

		public static string GetServerUrl (){
			DependencyService.Get<IApplicationInsights> ().GetServerUrl ();
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
			DependencyService.Get<IApplicationInsights> ().GetAppStoreEnvironment ();
		}

		public static bool GetDebugLogEnabled(){
			DependencyService.Get<IApplicationInsights> ().GetDebugLogEnabled ();
		}

		public static void SetDebugLogEnabled(bool debugLogEnabled){
			DependencyService.Get<IApplicationInsights> ().SetDebugLogEnabled (debugLogEnabled);
		}
	}
}

