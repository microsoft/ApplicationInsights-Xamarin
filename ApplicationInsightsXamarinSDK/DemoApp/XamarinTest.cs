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
			string iKey = null;
			Device.OnPlatform(
				Android: () =>{
					iKey = "<YOUR-ANDROID-KEY>";
				},
				iOS: () =>{
					iKey = "<YOUR-IOS-KEY>";
				}
			);
			ApplicationInsights.Setup (iKey);
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

