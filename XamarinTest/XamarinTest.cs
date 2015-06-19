using System;
using Xamarin.Forms;
using AI.XamarinSDK;

#if __ANDROID__
using Android;
#endif

namespace XamarinTest
{
	public class App : Application
	{
		public App ()
		{
			var mainNav = new NavigationPage (new XamarinTestMasterView ());
			MainPage = mainNav;
		}

		protected override void OnStart ()
		{
			string iKey = "a11683ec-3d08-474d-8218-0abca5f7adbb";

			#if __ANDROID__
			Android.App.Activity activity = (Android.App.Activity) Forms.Context;
			ApplicationInsights.Setup (activity.ApplicationContext, activity.Application, iKey);
			#elif __IOS__
			ApplicationInsights.Setup (iKey);
			#endif
			ApplicationInsights.Start ();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

