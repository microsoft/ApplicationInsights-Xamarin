using Foundation;

namespace DummyLibraryIOS
{
	// @interface ExamplePlugin : NSObject
	[BaseType (typeof(NSObject))]
	interface ExamplePlugin
	{
		// +(void)triggerExceptionCrash;
		[Static]
		[Export ("triggerExceptionCrash")]
		void TriggerExceptionCrash ();

		// +(void)triggerSignalCrash;
		[Static]
		[Export ("triggerSignalCrash")]
		void TriggerSignalCrash ();
	}
}
