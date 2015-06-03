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
			
		private void registerUnhandledExceptionHandler(){
			if (!_crashManagerDisabled) {
				System.AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
//				Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			}
		}
			
		public void OnUnhandledException(object e, System.UnhandledExceptionEventArgs args){

//			Exception exception = (Exception)e;
//			var name = ".NET crash";
//			var msg = e.ToString();
//			if(e is Exception) {
//				name = string.Format("{0}: {1}", e.GetType().FullName, (e as Exception).Message);
//			}
//			name = name.Replace("%", "%%");
//			msg = msg.Replace("%", "%%");
//			var nse = new NSException(name, msg, null);
//			var sel = new Selector("raise");
//			Messaging.void_objc_msgSend(nse.Handle, sel.Handle);
//			if(!exception.Source.Equals("Xamarin.iOS")){
//				TelemetryManager.TrackManagedException(exception.Message);
//			}

			Console.WriteLine ((e as Exception).Source);
		}
	}
}

