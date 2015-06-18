using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace DummyLibrary.iOS
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

