using System;
using System.Collections.Generic;
using System.Linq;
using AI.XamarinSDK;
using Foundation;
using UIKit;

namespace XamarinTest.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
//			#if ENABLE_TEST_CLOUD
//			Xamarin.Calabash.Start();
//			#endif

			ApplicationInsights.Setup ("a11683ec-3d08-474d-8218-0abca5f7adbb");
			ApplicationInsights.Start ();
			TelemetryManager.TrackEvent ("Hi");
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

