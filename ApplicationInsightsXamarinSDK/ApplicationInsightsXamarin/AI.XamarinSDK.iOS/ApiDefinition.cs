using System;
using Foundation;
using ObjCRuntime;
using AI.XamarinSDK;

namespace AI.XamarinSDK.iOS
{
	// @interface MSAIApplicationInsights : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAIApplicationInsights
	{

		// +(void)setupWithInstrumentationKey:(NSString *)instrumentationKey;
		[Static]
		[Export ("setupWithInstrumentationKey:")]
		void Setup (string instrumentationKey);

		// +(void)start;
		[Static]
		[Export ("start")]
		void Start ();

		// +(MSAIApplicationInsights *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MSAIApplicationInsights SharedInstance { get; }

		// @property (nonatomic, strong) NSString * serverURL;
		[Export ("serverURL", ArgumentSemantic.Strong)]
		string ServerURL { get; set; }

		// +(void)setTelemetryManagerDisabled:(BOOL)telemetryManagerDisabled;
		[Static]
		[Export ("setTelemetryManagerDisabled:")]
		void SetTelemetryManagerDisabled (bool telemetryManagerDisabled);

		// +(void)setAutoPageViewTrackingDisabled:(BOOL)autoPageViewTrackingDisabled;
		[Static]
		[Export ("setAutoPageViewTrackingDisabled:")]
		void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled);

		// +(void)setAutoSessionManagementDisabled:(BOOL)autoSessionManagementDisabled;
		[Static]
		[Export ("setAutoSessionManagementDisabled:")]
		void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled);

		// +(void)setUserId:(NSString *)userId;
		[Static]
		[Export ("setUserId:")]
		void SetUserId (string userId);

		// +(void)startNewSession;
		[Static]
		[Export ("startNewSession")]
		void StartNewSession ();

		// +(void)setAppBackgroundTimeBeforeSessionExpires:(NSUInteger)appBackgroundTimeBeforeSessionExpires;
		[Static]
		[Export ("setAppBackgroundTimeBeforeSessionExpires:")]
		void SetAppBackgroundTimeBeforeSessionExpires (nuint appBackgroundTimeBeforeSessionExpires);

		// +(void)renewSessionWithId:(NSString *)sessionId;
		[Static]
		[Export ("renewSessionWithId:")]
		void RenewSessionWithId (string sessionId);

		// @property (getter = isDebugLogEnabled, assign, nonatomic) BOOL debugLogEnabled;
		[Export ("debugLogEnabled")]
		bool DebugLogEnabled { [Bind ("isDebugLogEnabled")] get; set; }
	}

	// @interface MSAITelemetryManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAITelemetryManager
	{
		// +(void)trackEventWithName:(NSString *)eventName;
		[Static]
		[Export ("trackEventWithName:")]
		void TrackEvent (string eventName);

		// +(void)trackEventWithName:(NSString *)eventName properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackEventWithName:properties:")]
		void TrackEvent (string eventName, NSDictionary properties);

		// +(void)trackTraceWithMessage:(NSString *)message;
		[Static]
		[Export ("trackTraceWithMessage:")]
		void TrackTrace (string message);

		// +(void)trackTraceWithMessage:(NSString *)message properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackTraceWithMessage:properties:")]
		void TrackTrace (string message, NSDictionary properties);

		// +(void)trackMetricWithName:(NSString *)metricName value:(double)value;
		[Static]
		[Export ("trackMetricWithName:value:")]
		void TrackMetric (string metricName, double value);

		// +(void)trackMetricWithName:(NSString *)metricName value:(double)value properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackMetricWithName:value:properties:")]
		void TrackMetric (string metricName, double value, NSDictionary properties);

		// +(void)trackPageView:(NSString *)pageName;
		[Static]
		[Export ("trackPageView:")]
		void TrackPageView (string pageName);

		// +(void)trackPageView:(NSString *)pageName duration:(long)duration;
		[Static]
		[Export ("trackPageView:duration:")]
		void TrackPageView (string pageName, nint duration);

		// +(void)trackPageView:(NSString *)pageName duration:(long)duration properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackPageView:duration:properties:")]
		void TrackPageView (string pageName, nint duration, NSDictionary properties);

	}
}
