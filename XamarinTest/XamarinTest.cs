using System;
using Xamarin.Forms;
using AI.XamarinSDK;


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
			ApplicationInsights.Setup ("a11683ec-3d08-474d-8218-0abca5f7adbb");
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

