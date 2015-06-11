using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace TestCrashBindings
{

	// @interface ExamplePlugin : NSObject
	[BaseType (typeof(NSObject))]
	interface ExamplePlugin
	{
		// +(void)forceAppCrash;
		[Static]
		[Export ("forceAppCrash")]
		void ForceAppCrash ();
	}
}

