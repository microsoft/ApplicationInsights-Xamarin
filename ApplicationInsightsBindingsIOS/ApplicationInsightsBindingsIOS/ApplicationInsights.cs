using System;
using ApplicationInsightsIOS;
using Foundation;
using System.Runtime.InteropServices;
using ObjCRuntime;


namespace ApplicationInsightsXamarinIOS
{
	public class ApplicationInsights
	{
		[DllImport ("libc")]
		private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);

		enum Signal {
			SIGBUS = 10,
			SIGSEGV = 11
		}
				
		private static bool _crashManagerDisabled = false;

		private static readonly ApplicationInsights instance = new ApplicationInsights();

		private ApplicationInsights(){}

		public static ApplicationInsights Instance
		{
			get 
			{
				return instance; 
			}
		}
			
		public static void Setup (string instrumentationKey){
			MSAIApplicationInsights.SetupWithInstrumentationKey (instrumentationKey);
		}

		public static void Start (){
			IntPtr sigbus = Marshal.AllocHGlobal (512);
			IntPtr sigsegv = Marshal.AllocHGlobal (512);

			// Store Mono SIGSEGV and SIGBUS handlers
			sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
			sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);
		
			Instance.registerUnhandledExceptionHandler ();
			MSAIApplicationInsights.Start ();

			// Restore Mono SIGSEGV and SIGBUS handlers            
			sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
			sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);
		}

		public static void CrashNaticeLib(){

			MSAICrashManager crashManager = new MSAICrashManager ();
			crashManager.GenerateTestCrash ();
		}

		public static string GetServerUrl (){
			return MSAIApplicationInsights.SharedInstance.ServerURL; 
		}

		public static void SetServerUrl (string serverUrl){
			MSAIApplicationInsights.SharedInstance.ServerURL = serverUrl; 
		}
			
		public static void  SetCrashManagerDisabled (bool crashManagerDisabled){
			_crashManagerDisabled = crashManagerDisabled;
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
			return MSAIApplicationInsights.SharedInstance.AppStoreEnvironment; 
		}

		public static bool GetDebugLogEnabled() {
			return MSAIApplicationInsights.SharedInstance.DebugLogEnabled; 
		}

		public static void SetDebugLogEnabled(bool debugLogEnabled) {
			MSAIApplicationInsights.SharedInstance.DebugLogEnabled = debugLogEnabled; 
		}
	}
}

