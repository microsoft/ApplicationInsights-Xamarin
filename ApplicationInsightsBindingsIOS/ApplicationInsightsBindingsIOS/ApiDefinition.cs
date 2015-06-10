using System;
using Foundation;
using ObjCRuntime;
using ApplicationInsightsIOS;

namespace ApplicationInsightsIOS
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

		// @property (nonatomic, strong) NSString * serverURL;
		[Export ("serverURL", ArgumentSemantic.Strong)]
		string ServerURL { get; set; }

		// +(void)setCrashManagerDisabled:(BOOL)crashManagerDisabled;
		[Static]
		[Export ("setCrashManagerDisabled:")]
		void SetCrashManagerDisabled (bool crashManagerDisabled);

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

		// +(NSString *)version;
		[Static]
		[Export ("version")]
		string Version { get; }

		// +(NSString *)build;
		[Static]
		[Export ("build")]
		string Build { get; }
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

//		// -(void)setCrashCallbacks:(MSAICrashManagerCallbacks *)callbacks;
//		[Export ("setCrashCallbacks:")]
//		unsafe void SetCrashCallbacks (MSAICrashManagerCallbacks* callbacks);

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

		// +(void)trackManagedException:(MSAIExceptionData *)exceptionData;
		[Static]
		[Export ("trackManagedException:")]
		void TrackManagedException (MSAIExceptionData exceptionData);
	}

	// @interface MSAIOrderedDictionary : NSMutableDictionary
	[BaseType (typeof(NSMutableDictionary))]
	interface MSAIOrderedDictionary
	{
		// -(instancetype)initWithCapacity:(NSUInteger)numItems;
		[Export ("initWithCapacity:")]
		IntPtr Constructor (nuint numItems);

		// -(void)setObject:(id)anObject forKey:(id)aKey;
		[Export ("setObject:forKey:")]
		void SetObject (NSObject anObject, NSObject aKey);
	}

	// @interface MSAIObject : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface MSAIObject : INSCoding
	{
		// -(MSAIOrderedDictionary *)serializeToDictionary;
		[Export ("serializeToDictionary")]
		MSAIOrderedDictionary SerializeToDictionary { get; }

		// -(NSString *)serializeToString;
		[Export ("serializeToString")]
		string SerializeToString { get; }
	}

	// @interface MSAITelemetryData : MSAIObject <NSCoding>
	[BaseType (typeof(MSAIObject))]
	interface MSAITelemetryData : INSCoding
	{
		// @property (readonly, copy, nonatomic) NSString * envelopeTypeName;
		[Export ("envelopeTypeName")]
		string EnvelopeTypeName { get; }

		// @property (readonly, copy, nonatomic) NSString * dataTypeName;
		[Export ("dataTypeName")]
		string DataTypeName { get; }

		// @property (nonatomic, strong) NSNumber * version;
		[Export ("version", ArgumentSemantic.Strong)]
		NSNumber Version { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSDictionary * properties;
		[Export ("properties", ArgumentSemantic.Strong)]
		NSDictionary Properties { get; set; }
	}

	// @interface MSAIDomain : MSAITelemetryData <NSCoding>
	[BaseType (typeof(MSAITelemetryData))]
	interface MSAIDomain : INSCoding
	{
	}

	// @interface MSAIExceptionDetails : MSAIObject <NSCoding>
	[BaseType (typeof(MSAIObject))]
	interface MSAIExceptionDetails : INSCoding
	{
		// @property (nonatomic, strong) NSNumber * exceptionDetailsId;
		[Export ("exceptionDetailsId", ArgumentSemantic.Strong)]
		NSNumber ExceptionDetailsId { get; set; }

		// @property (nonatomic, strong) NSNumber * outerId;
		[Export ("outerId", ArgumentSemantic.Strong)]
		NSNumber OuterId { get; set; }

		// @property (nonatomic, strong) NSString * typeName;
		[Export ("typeName", ArgumentSemantic.Strong)]
		string TypeName { get; set; }

		// @property (nonatomic, strong) NSString * message;
		[Export ("message", ArgumentSemantic.Strong)]
		string Message { get; set; }

		// @property (assign, nonatomic) BOOL hasFullStack;
		[Export ("hasFullStack")]
		bool HasFullStack { get; set; }

		// @property (nonatomic, strong) NSString * stack;
		[Export ("stack", ArgumentSemantic.Strong)]
		string Stack { get; set; }

		// @property (nonatomic, strong) NSMutableArray * parsedStack;
		[Export ("parsedStack", ArgumentSemantic.Strong)]
		NSMutableArray ParsedStack { get; set; }
	}

	// @interface MSAIExceptionData : MSAIDomain <NSCoding>
	[BaseType (typeof(MSAIDomain))]
	interface MSAIExceptionData : INSCoding
	{
		// @property (readonly, copy, nonatomic) NSString * envelopeTypeName;
		[Export ("envelopeTypeName")]
		string EnvelopeTypeName { get; }

		// @property (readonly, copy, nonatomic) NSString * dataTypeName;
		[Export ("dataTypeName")]
		string DataTypeName { get; }

		// @property (nonatomic, strong) NSString * handledAt;
		[Export ("handledAt", ArgumentSemantic.Strong)]
		string HandledAt { get; set; }

		// @property (nonatomic, strong) NSMutableArray * exceptions;
		[Export ("exceptions", ArgumentSemantic.Strong)]
		NSMutableArray Exceptions { get; set; }

		// @property (assign, nonatomic) MSAISeverityLevel severityLevel;
		[Export ("severityLevel", ArgumentSemantic.Assign)]
		long SeverityLevel { get; set; }

		// @property (nonatomic, strong) MSAIOrderedDictionary * measurements;
		[Export ("measurements", ArgumentSemantic.Strong)]
		MSAIOrderedDictionary Measurements { get; set; }
	}
		
	partial interface Constants
	{
		// extern NSString *const kMSAICrashErrorDomain;
		[Field ("kMSAICrashErrorDomain")]
		NSString kMSAICrashErrorDomain { get; }
	}
		
	partial interface Constants
	{
		// extern NSString *const kMSAIErrorDomain;
		[Field ("kMSAIErrorDomain")]
		NSString kMSAIErrorDomain { get; }
	}
}
