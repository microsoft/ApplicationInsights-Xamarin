using System;
using ApplicationInsightsIOS;

namespace ApplicationInsightsXamarinIOS
{
	public class ApplicationInsights
	{

		public ApplicationInsights ()
		{
			
		}
			
		public static void Setup (string instrumentationKey){
			MSAIApplicationInsights.SetupWithInstrumentationKey (instrumentationKey);
		}

		public static void Start (){
			MSAIApplicationInsights.Start ();
		}

		public static void CrashNaticeLib(){

			MSAICrashManager crashManager = new MSAICrashManager ();
			crashManager.GenerateTestCrash ();
		}
		public static void SetServerUrl (string serverUrl){
			MSAIApplicationInsights.SharedInstance.ServerURL = serverUrl; 
		}

		public static void  SetCrashManagerDisabled (bool crashManagerDisabled){
			MSAIApplicationInsights.SetCrashManagerDisabled (crashManagerDisabled);
		}

		public static void SetTelemetryManagerDisabled (bool telemetryManagerDisabled){
			MSAIApplicationInsights.SetTelemetryManagerDisabled(telemetryManagerDisabled);
		}

		public static void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled){
			MSAIApplicationInsights.SetAutoPageViewTrackingDisabled (autoPageViewTrackingDisabled);
		}

		public static void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled){
			MSAIApplicationInsights.SetAutoSessionManagementDisabled (autoSessionManagementDisabled);
		}

		public static void SetUserId (string userId){
			MSAIApplicationInsights.SetUserId (userId);
		}

		public static void StartNewSession (){
			MSAIApplicationInsights.StartNewSession ();
		}

		public static void SetSessionExpirationTime (nuint appBackgroundTime){
			MSAIApplicationInsights.SetAppBackgroundTimeBeforeSessionExpires (appBackgroundTime);
		}

		public static void RenewSessionWithId (string sessionId){
			MSAIApplicationInsights.RenewSessionWithId (sessionId);
		}

		public static bool GetAppStoreEnvironment() {
			return true;
		}

		public static void SetAppStoreEnvironment(bool appStoreEnvironment) {

		}

		public static bool GetDebugLogEnabled() {
			return true;
		}

		public static void SetDebugLogEnabled() {
			
		}
	}
}

