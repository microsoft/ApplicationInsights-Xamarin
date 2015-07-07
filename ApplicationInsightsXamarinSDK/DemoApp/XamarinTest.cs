using System;
using Xamarin.Forms;
using AI.XamarinSDK.Abstractions;

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
			ApplicationInsights.Setup ("");
			//ApplicationInsights.Setup ("ijhch");
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

