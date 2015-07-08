using System;
using UIKit;
using ObjCRuntime;
using Foundation;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Runtime.InteropServices;
using AI.XamarinSDK.Abstractions;

[assembly: Xamarin.Forms.Dependency (typeof (AI.XamarinSDK.iOS.ApplicationInsights))]

namespace AI.XamarinSDK.iOS
{
	[Preserve(AllMembers=true)]
	public class ApplicationInsights : IApplicationInsights
	{

		[DllImport ("libc")]
		private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);
		
		enum Signal {
			SIGBUS = 10,
			SIGSEGV = 11
		}

		private static bool _crashManagerDisabled = false;

		public ApplicationInsights(){}

		public void Setup (string instrumentationKey)
		{
			MSAIApplicationInsights.Setup (instrumentationKey);
			MSAIApplicationInsights.SetAutoSessionManagementDisabled (false);
		}

		public void Start ()
		{
			IntPtr sigbus = Marshal.AllocHGlobal (512);
			IntPtr sigsegv = Marshal.AllocHGlobal (512);

			// Store Mono SIGSEGV and SIGBUS handlers
			sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
			sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);

			MSAIApplicationInsights.Start ();
			registerUnhandledExceptionHandler ();         
			sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
			sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);
		}

		public string GetServerUrl ()
		{
			return MSAIApplicationInsights.SharedInstance.ServerURL; 
		}

		public void SetServerUrl (string serverUrl){
			MSAIApplicationInsights.SharedInstance.ServerURL = serverUrl; 
		}

		public void  SetCrashManagerDisabled (bool crashManagerDisabled)
		{
			_crashManagerDisabled = crashManagerDisabled;
			MSAIApplicationInsights.SetCrashManagerDisabled (crashManagerDisabled);
		}

		public void SetTelemetryManagerDisabled (bool telemetryManagerDisabled)
		{
			MSAIApplicationInsights.SetTelemetryManagerDisabled(telemetryManagerDisabled);
		}

		public void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled)
		{
			MSAIApplicationInsights.SetAutoPageViewTrackingDisabled (autoPageViewTrackingDisabled);
		}

		public void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled)
		{
			MSAIApplicationInsights.SetAutoSessionManagementDisabled (autoSessionManagementDisabled);
		}

		public void SetUserId (string userId)
		{
			MSAIApplicationInsights.SetUserId (userId);
		}

		public void StartNewSession ()
		{
			MSAIApplicationInsights.StartNewSession ();
		}

		public void SetSessionExpirationTime (int appBackgroundTime)
		{
			MSAIApplicationInsights.SetAppBackgroundTimeBeforeSessionExpires ((nuint)appBackgroundTime);
		}

		public void RenewSessionWithId (string sessionId){
			MSAIApplicationInsights.RenewSessionWithId (sessionId);
		}

		public bool GetDebugLogEnabled() 
		{
			return MSAIApplicationInsights.SharedInstance.DebugLogEnabled; 
		}

		public void SetDebugLogEnabled(bool debugLogEnabled) 
		{
			MSAIApplicationInsights.SharedInstance.DebugLogEnabled = debugLogEnabled; 
		}

		private void registerUnhandledExceptionHandler()
		{
			if (!_crashManagerDisabled) {
				System.AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
			}
		}

		public void OnUnhandledException(object e, System.UnhandledExceptionEventArgs args)
		{
			Exception managedException = (Exception) args.ExceptionObject;
			Console.WriteLine (managedException.Source);
			if (managedException != null && !managedException.Source.Equals("Xamarin.iOS")) {
				AI.XamarinSDK.Abstractions.TelemetryManager.TrackManagedException (managedException, false);
			}	
		}
	}
}

