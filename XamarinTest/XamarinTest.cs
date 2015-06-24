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
			#if __IOS__
			String iKey = "a11683ec-3d08-474d-8218-0abca5f7adbb";
			ApplicationInsights.Setup (iKey);
			ApplicationInsights.SetServerUrl ("http://dc-int.services.visualstudio.com/v2/track");
			ApplicationInsights.Start ();
			#elif __ANDROID__
			ApplicationInsights.Setup (Android.App.Application.Context, (Android.App.Application)Android.App.Application.Context , "ca946245-ea1c-4e64-a7ea-a824f8109797");
			ApplicationInsights.SetServerUrl ("http://dc-int.services.visualstudio.com/v2/track");
			ApplicationInsights.Start ();
			#endif


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

