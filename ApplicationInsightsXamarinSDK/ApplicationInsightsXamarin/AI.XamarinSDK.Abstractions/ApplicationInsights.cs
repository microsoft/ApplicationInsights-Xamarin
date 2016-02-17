using System;
using Xamarin.Forms;

namespace AI.XamarinSDK.Abstractions
{
	/// <summary>
	/// This class exposes methods to configure and start the SDK. This is required in order to enable auto collection, crash reporting, and sending of telemetry data.
	/// </summary>
	public class ApplicationInsights
	{

		private static readonly IApplicationInsights target = GetTarget();
		
		private ApplicationInsights() {}

		/// <summary>
		/// Setup the SDK with the instrumentation key of your app.
		/// </summary>
		/// <param name="instrumentationKey">The instrumentation key of your app.</param>
		public static void Setup (string instrumentationKey)
		{
			if (Utils.IsSupportedPlatform ()) {
				target.Setup (instrumentationKey);
			}
		}

		/// <summary>
		/// Starts the SDK. This should be called after setup().
		/// </summary>
		public static void Start ()
		{
			if (Utils.IsSupportedPlatform()) {
				target.Start ();
			}
		}

		/// <summary>
		/// Gets the server URL
		/// </summary>
		/// <returns>The server URL.</returns>
		public static string GetServerUrl ()
		{
			if (Utils.IsSupportedPlatform()) {
				return target.GetServerUrl ();
			}
			return null;
		}

		/// <summary>
		/// Sets the server URL.
		/// </summary>
		/// <param name="serverUrl">Server URL.</param>
		public static void SetServerUrl (string serverUrl)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetServerUrl (serverUrl);
			}
		}

		/// <summary>
		/// Configures the tracking of custom events. This method should be called in between setup() and start()
		/// </summary>
		/// <param name="telemetryManagerDisabled">If set to <c>true</c> the telemetry manager disabled. Default is <c>false</c>.</param>
		public static void SetTelemetryManagerDisabled (bool telemetryManagerDisabled)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetTelemetryManagerDisabled (telemetryManagerDisabled);
			}
		}

		/// <summary>
		/// Configures the auto collection of page views. This method should be called in between setup() and start()
		/// </summary>
		/// <param name="autoPageViewTrackingDisabled">If set to <c>true</c> auto page view tracking will be disabled. Default is <c>false</c>.</param>
		public static void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetAutoPageViewTrackingDisabled  (autoPageViewTrackingDisabled);
			}
		}

		/// <summary>
		/// Configures the auto session management. This method should be called in between setup() and start()
		/// </summary>
		/// <param name="autoSessionManagementDisabled">If set to <c>true</c> the auto session management will be disabled. Default is <c>false</c>.</param>
		public static void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetAutoSessionManagementDisabled  (autoSessionManagementDisabled);
			}
		}

		/// <summary>
		/// Sets a custom user identifier.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		public static void SetUserId (string userId)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetUserId  (userId);
			}
		}

		/// <summary>
		/// Forces the SDK to start a new session.
		/// </summary>
		public static void StartNewSession ()
		{
			if (Utils.IsSupportedPlatform()) {
				target.StartNewSession  ();
			}
		}

		/// <summary>
		/// Sets the time for session renewal. If the app stays in background longer than that, a new session will be created automatically. This is only available with auto session management enabled
		/// </summary>
		/// <param name="appBackgroundTime">The interval at which sessions are renewed.</param>
		public static void SetSessionExpirationTime (int appBackgroundTime)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetSessionExpirationTime (appBackgroundTime);
			}
		}

		/// <summary>
		/// Manually renews the session with a custom identifier.
		/// </summary>
		/// <param name="sessionId">Custom session identifier.</param>
		public static void RenewSessionWithId (string sessionId)
		{
			if (Utils.IsSupportedPlatform()) {
				target.RenewSessionWithId (sessionId);
			}
		}

		/// <summary>
		/// Gets the debug log enabled.
		/// </summary>
		/// <returns><c>true</c>, if debug log is enabled, <c>false</c> otherwise.</returns>
		public static bool GetDebugLogEnabled()
		{
			if (Utils.IsSupportedPlatform()) {
				return target.GetDebugLogEnabled ();
			}
			return false;
		}

		/// <summary>
		/// Sets the debug log enabled.
		/// </summary>
		/// <param name="debugLogEnabled">If set to <c>true</c> debug log is enabled.</param>
		public static void SetDebugLogEnabled(bool debugLogEnabled)
		{
			if (Utils.IsSupportedPlatform()) {
				target.SetDebugLogEnabled (debugLogEnabled);
			}
		}

		private static IApplicationInsights GetTarget(){
			if (Utils.IsSupportedPlatform ()) {
				return DependencyService.Get<IApplicationInsights> ();
			}
			return null;
		}
	}
}
	