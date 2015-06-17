using System;
using Xamarin.Forms;
using AI.XamarinSDK;

namespace XamarinTest
{
	public class App : Application
	{
		public App ()
		{
			var mainNav = new NavigationPage (new XamarinTestTableView ());
			MainPage = mainNav;
		}

		protected override void OnStart ()
		{
			TelemetryManager.TrackEvent ("My Shared Event");
			ApplicationInsights.RenewSessionWithId ("MySession");
			ApplicationInsights.SetUserId ("Christoph");
			TelemetryManager.TrackMetric ("My custom metric", 2.2);
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

