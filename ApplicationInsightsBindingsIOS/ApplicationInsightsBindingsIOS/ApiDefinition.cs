using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace ApplicationInsightsBindingsIOS
{
	// @interface MSAIApplicationInsights : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAIApplicationInsights
	{
		// +(void)setup;
		[Static]
		[Export ("setup")]
		void Setup ();

		// +(void)setupWithInstrumentationKey:(NSString *)instrumentationKey;
		[Static]
		[Export ("setupWithInstrumentationKey:")]
		void SetupWithInstrumentationKey (string instrumentationKey);

		// +(void)start;
		[Static]
		[Export ("start")]
		void Start ();

		// +(MSAIApplicationInsights *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MSAIApplicationInsights SharedInstance { get; }

		// -(void)setup;
		[Export ("setup")]
		void Setup ();

		// -(void)setupWithInstrumentationKey:(NSString *)instrumentationKey;
		[Export ("setupWithInstrumentationKey:")]
		void SetupWithInstrumentationKey (string instrumentationKey);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// @property (nonatomic, strong) NSString * serverURL;
		[Export ("serverURL", ArgumentSemantic.Strong)]
		string ServerURL { get; set; }

		// @property (getter = isCrashManagerDisabled, nonatomic) BOOL crashManagerDisabled;
		[Export ("crashManagerDisabled")]
		bool CrashManagerDisabled { [Bind ("isCrashManagerDisabled")] get; set; }

		// +(void)setCrashManagerDisabled:(BOOL)crashManagerDisabled;
		[Static]
		[Export ("setCrashManagerDisabled:")]
		void SetCrashManagerDisabled (bool crashManagerDisabled);

		// @property (getter = isTelemetryManagerDisabled, nonatomic) BOOL telemetryManagerDisabled;
		[Export ("telemetryManagerDisabled")]
		bool TelemetryManagerDisabled { [Bind ("isTelemetryManagerDisabled")] get; set; }

		// +(void)setTelemetryManagerDisabled:(BOOL)telemetryManagerDisabled;
		[Static]
		[Export ("setTelemetryManagerDisabled:")]
		void SetTelemetryManagerDisabled (bool telemetryManagerDisabled);

		// @property (getter = isAutoPageViewTrackingDisabled, nonatomic) BOOL autoPageViewTrackingDisabled;
		[Export ("autoPageViewTrackingDisabled")]
		bool AutoPageViewTrackingDisabled { [Bind ("isAutoPageViewTrackingDisabled")] get; set; }

		// +(void)setAutoPageViewTrackingDisabled:(BOOL)autoPageViewTrackingDisabled;
		[Static]
		[Export ("setAutoPageViewTrackingDisabled:")]
		void SetAutoPageViewTrackingDisabled (bool autoPageViewTrackingDisabled);

		// @property (getter = isAutoSessionManagementDisabled, nonatomic) BOOL autoSessionManagementDisabled;
		[Export ("autoSessionManagementDisabled")]
		bool AutoSessionManagementDisabled { [Bind ("isAutoSessionManagementDisabled")] get; set; }

		// +(void)setAutoSessionManagementDisabled:(BOOL)autoSessionManagementDisabled;
		[Static]
		[Export ("setAutoSessionManagementDisabled:")]
		void SetAutoSessionManagementDisabled (bool autoSessionManagementDisabled);

		// +(void)setUserId:(NSString *)userId;
		[Static]
		[Export ("setUserId:")]
		void SetUserId (string userId);

		// -(void)setUserId:(NSString *)userId;
		[Export ("setUserId:")]
		void SetUserId (string userId);

		// +(void)startNewSession;
		[Static]
		[Export ("startNewSession")]
		void StartNewSession ();

		// -(void)startNewSession;
		[Export ("startNewSession")]
		void StartNewSession ();

		// +(void)setAppBackgroundTimeBeforeSessionExpires:(NSUInteger)appBackgroundTimeBeforeSessionExpires;
		[Static]
		[Export ("setAppBackgroundTimeBeforeSessionExpires:")]
		void SetAppBackgroundTimeBeforeSessionExpires (nuint appBackgroundTimeBeforeSessionExpires);

		// -(void)setAppBackgroundTimeBeforeSessionExpires:(NSUInteger)appBackgroundTimeBeforeSessionExpires;
		[Export ("setAppBackgroundTimeBeforeSessionExpires:")]
		void SetAppBackgroundTimeBeforeSessionExpires (nuint appBackgroundTimeBeforeSessionExpires);

		// +(void)renewSessionWithId:(NSString *)sessionId;
		[Static]
		[Export ("renewSessionWithId:")]
		void RenewSessionWithId (string sessionId);

		// -(void)renewSessionWithId:(NSString *)sessionId;
		[Export ("renewSessionWithId:")]
		void RenewSessionWithId (string sessionId);

		// @property (readonly, getter = isAppStoreEnvironment, nonatomic) BOOL appStoreEnvironment;
		[Export ("appStoreEnvironment")]
		bool AppStoreEnvironment { [Bind ("isAppStoreEnvironment")] get; }

		// @property (getter = isDebugLogEnabled, assign, nonatomic) BOOL debugLogEnabled;
		[Export ("debugLogEnabled")]
		bool DebugLogEnabled { [Bind ("isDebugLogEnabled")] get; set; }

		// +(void)testIdentifier;
		[Static]
		[Export ("testIdentifier")]
		void TestIdentifier ();

		// -(void)testIdentifier;
		[Export ("testIdentifier")]
		void TestIdentifier ();

		// +(NSString *)version;
		[Static]
		[Export ("version")]
		string Version { get; }

		// -(NSString *)version;
		[Export ("version")]
		string Version { get; }

		// +(NSString *)build;
		[Static]
		[Export ("build")]
		string Build { get; }

		// -(NSString *)build;
		[Export ("build")]
		string Build { get; }
	}

	// @interface MSAICrashManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAICrashManager
	{
		// +(instancetype)sharedManager;
		[Static]
		[Export ("sharedManager")]
		MSAICrashManager SharedManager ();

		// @property (assign, nonatomic) BOOL isSetupCorrectly;
		[Export ("isSetupCorrectly")]
		bool IsSetupCorrectly { get; set; }

		// @property (assign, nonatomic, setter = setCrashManagerDisabled:) BOOL isCrashManagerDisabled;
		[Export ("isCrashManagerDisabled")]
		bool IsCrashManagerDisabled { get; [Bind ("setCrashManagerDisabled:")] set; }

		// @property (assign, nonatomic) BOOL machExceptionHandlerEnabled;
		[Export ("machExceptionHandlerEnabled")]
		bool MachExceptionHandlerEnabled { get; set; }

		// @property (assign, nonatomic) BOOL onDeviceSymbolicationEnabled;
		[Export ("onDeviceSymbolicationEnabled")]
		bool OnDeviceSymbolicationEnabled { get; set; }

		// @property (assign, nonatomic) BOOL appNotTerminatingCleanlyDetectionEnabled;
		[Export ("appNotTerminatingCleanlyDetectionEnabled")]
		bool AppNotTerminatingCleanlyDetectionEnabled { get; set; }

		// -(void)setCrashCallbacks:(MSAICrashManagerCallbacks *)callbacks;
		[Export ("setCrashCallbacks:")]
		unsafe void SetCrashCallbacks (MSAICrashManagerCallbacks* callbacks);

		// @property (readonly, nonatomic) BOOL didCrashInLastSession;
		[Export ("didCrashInLastSession")]
		bool DidCrashInLastSession { get; }

		// @property (readonly, nonatomic, strong) MSAICrashDetails * lastSessionCrashDetails;
		[Export ("lastSessionCrashDetails", ArgumentSemantic.Strong)]
		MSAICrashDetails LastSessionCrashDetails { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeintervalCrashInLastSessionOccured;
		[Export ("timeintervalCrashInLastSessionOccured")]
		double TimeintervalCrashInLastSessionOccured { get; }

		// @property (readonly, nonatomic) BOOL didReceiveMemoryWarningInLastSession;
		[Export ("didReceiveMemoryWarningInLastSession")]
		bool DidReceiveMemoryWarningInLastSession { get; }

		// @property (readonly, getter = getIsDebuggerAttached, nonatomic) BOOL debuggerIsAttached;
		[Export ("debuggerIsAttached")]
		bool DebuggerIsAttached { [Bind ("getIsDebuggerAttached")] get; }

		// -(void)generateTestCrash;
		[Export ("generateTestCrash")]
		void GenerateTestCrash ();
	}

	// @protocol MSAICrashManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MSAICrashManagerDelegate
	{
		// @optional -(void)crashManagerWillSendCrashReport;
		[Export ("crashManagerWillSendCrashReport")]
		void CrashManagerWillSendCrashReport ();

		// @optional -(void)crashManagerDidFailWithError:(NSError *)error;
		[Export ("crashManagerDidFailWithError:")]
		void CrashManagerDidFailWithError (NSError error);

		// @optional -(void)crashManagerDidFinishSendingCrashReport;
		[Export ("crashManagerDidFinishSendingCrashReport")]
		void CrashManagerDidFinishSendingCrashReport ();

		// @optional -(BOOL)considerAppNotTerminatedCleanlyReportForCrashManager;
		[Export ("considerAppNotTerminatedCleanlyReportForCrashManager")]
		bool ConsiderAppNotTerminatedCleanlyReportForCrashManager { get; }
	}

	// @interface MSAICrashDetails : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAICrashDetails
	{
		// @property (readonly, nonatomic, strong) NSString * incidentIdentifier;
		[Export ("incidentIdentifier", ArgumentSemantic.Strong)]
		string IncidentIdentifier { get; }

		// @property (readonly, nonatomic, strong) NSString * reporterKey;
		[Export ("reporterKey", ArgumentSemantic.Strong)]
		string ReporterKey { get; }

		// @property (readonly, nonatomic, strong) NSString * signal;
		[Export ("signal", ArgumentSemantic.Strong)]
		string Signal { get; }

		// @property (readonly, nonatomic, strong) NSString * exceptionName;
		[Export ("exceptionName", ArgumentSemantic.Strong)]
		string ExceptionName { get; }

		// @property (readonly, nonatomic, strong) NSString * exceptionReason;
		[Export ("exceptionReason", ArgumentSemantic.Strong)]
		string ExceptionReason { get; }

		// @property (readonly, nonatomic, strong) NSDate * appStartTime;
		[Export ("appStartTime", ArgumentSemantic.Strong)]
		NSDate AppStartTime { get; }

		// @property (readonly, nonatomic, strong) NSDate * crashTime;
		[Export ("crashTime", ArgumentSemantic.Strong)]
		NSDate CrashTime { get; }

		// @property (readonly, nonatomic, strong) NSString * osVersion;
		[Export ("osVersion", ArgumentSemantic.Strong)]
		string OsVersion { get; }

		// @property (readonly, nonatomic, strong) NSString * osBuild;
		[Export ("osBuild", ArgumentSemantic.Strong)]
		string OsBuild { get; }

		// @property (readonly, nonatomic, strong) NSString * appBuild;
		[Export ("appBuild", ArgumentSemantic.Strong)]
		string AppBuild { get; }

		// -(BOOL)isAppKill;
		[Export ("isAppKill")]
		bool IsAppKill { get; }
	}

	// @interface PageViewLogging (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_PageViewLogging
	{
	}

	// @interface MSAICategoryContainer : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAICategoryContainer
	{
		// +(void)activateCategory;
		[Static]
		[Export ("activateCategory")]
		void ActivateCategory ();
	}

	// @interface MSAITelemetryManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MSAITelemetryManager
	{
		// +(instancetype)sharedManager;
		[Static]
		[Export ("sharedManager")]
		MSAITelemetryManager SharedManager ();

		// +(void)trackEventWithName:(NSString *)eventName;
		[Static]
		[Export ("trackEventWithName:")]
		void TrackEventWithName (string eventName);

		// +(void)trackEventWithName:(NSString *)eventName properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackEventWithName:properties:")]
		void TrackEventWithName (string eventName, NSDictionary properties);

		// +(void)trackEventWithName:(NSString *)eventName properties:(NSDictionary *)properties measurements:(NSDictionary *)measurements;
		[Static]
		[Export ("trackEventWithName:properties:measurements:")]
		void TrackEventWithName (string eventName, NSDictionary properties, NSDictionary measurements);

		// +(void)trackTraceWithMessage:(NSString *)message;
		[Static]
		[Export ("trackTraceWithMessage:")]
		void TrackTraceWithMessage (string message);

		// +(void)trackTraceWithMessage:(NSString *)message properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackTraceWithMessage:properties:")]
		void TrackTraceWithMessage (string message, NSDictionary properties);

		// +(void)trackMetricWithName:(NSString *)metricName value:(double)value;
		[Static]
		[Export ("trackMetricWithName:value:")]
		void TrackMetricWithName (string metricName, double value);

		// +(void)trackMetricWithName:(NSString *)metricName value:(double)value properties:(NSDictionary *)properties;
		[Static]
		[Export ("trackMetricWithName:value:properties:")]
		void TrackMetricWithName (string metricName, double value, NSDictionary properties);

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

		// +(void)trackException:(NSException *)exception;
		[Static]
		[Export ("trackException:")]
		void TrackException (NSException exception);

		// -(void)trackEventWithName:(NSString *)eventName;
		[Export ("trackEventWithName:")]
		void TrackEventWithName (string eventName);

		// -(void)trackEventWithName:(NSString *)eventName properties:(NSDictionary *)properties;
		[Export ("trackEventWithName:properties:")]
		void TrackEventWithName (string eventName, NSDictionary properties);

		// -(void)trackEventWithName:(NSString *)eventName properties:(NSDictionary *)properties measurements:(NSDictionary *)measurements;
		[Export ("trackEventWithName:properties:measurements:")]
		void TrackEventWithName (string eventName, NSDictionary properties, NSDictionary measurements);

		// -(void)trackTraceWithMessage:(NSString *)message;
		[Export ("trackTraceWithMessage:")]
		void TrackTraceWithMessage (string message);

		// -(void)trackTraceWithMessage:(NSString *)message properties:(NSDictionary *)properties;
		[Export ("trackTraceWithMessage:properties:")]
		void TrackTraceWithMessage (string message, NSDictionary properties);

		// -(void)trackMetricWithName:(NSString *)metricName value:(double)value;
		[Export ("trackMetricWithName:value:")]
		void TrackMetricWithName (string metricName, double value);

		// -(void)trackMetricWithName:(NSString *)metricName value:(double)value properties:(NSDictionary *)properties;
		[Export ("trackMetricWithName:value:properties:")]
		void TrackMetricWithName (string metricName, double value, NSDictionary properties);

		// -(void)trackPageView:(NSString *)pageName;
		[Export ("trackPageView:")]
		void TrackPageView (string pageName);

		// -(void)trackPageView:(NSString *)pageName duration:(long)duration;
		[Export ("trackPageView:duration:")]
		void TrackPageView (string pageName, nint duration);

		// -(void)trackPageView:(NSString *)pageName duration:(long)duration properties:(NSDictionary *)properties;
		[Export ("trackPageView:duration:properties:")]
		void TrackPageView (string pageName, nint duration, NSDictionary properties);

		// -(void)trackException:(NSException *)exception;
		[Export ("trackException:")]
		void TrackException (NSException exception);
	}
}
