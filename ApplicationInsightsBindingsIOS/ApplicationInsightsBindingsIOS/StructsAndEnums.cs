using ObjCRuntime;

namespace ApplicationInsightsIOS
{
	public struct MSAICrashManagerCallbacks
	{
		//unsafe void* context;

		//unsafe MSAICrashManagerPostCrashSignalCallback* handleSignal;
	}

	[Native]
	public enum MSAIDependencyKind : long
	{
		undefined = 0,
		http_only = 1,
		http_any = 2,
		s_q_l = 3
	}

	[Native]
	public enum MSAISeverityLevel : long
	{
		verbose = 0,
		information = 1,
		warning = 2,
		error = 3,
		critical = 4
	}

	[Native]
	public enum MSAIDataPointType : long
	{
		measurement = 0,
		aggregation = 1
	}

	[Native]
	public enum MSAIDependencySourceType : long
	{
		undefined = 0,
		aic = 1,
		apmc = 2
	}

	[Native]
	public enum MSAICrashErrorReason : long
	{
		ErrorUnknown,
		APIAppVersionRejected,
		APIReceivedEmptyResponse,
		APIErrorWithStatusCode
	}

	[Native]
	public enum MSAIErrorReason : long
	{
		MSAIErrorUnknown
	}
}
