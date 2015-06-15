using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinTest.Droid
{
	[Activity (Label = "XamarinTest.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			ApplicationInsights.Setup (this.ApplicationContext, this.Application, "a11683ec-3d08-474d-8218-0abca5f7adbb");
			ApplicationInsights.Start ();
			TelemetryManager.TrackEvent ("My Android Event");

			LoadApplication (new App ());
		}
	}
}

