using System;
using Xamarin.Forms;
using AI.XamarinSDK.Abstractions;
using System.Collections.Generic;

namespace XamarinTest {

	public class App : Application {
		public App () {
			var mainNav = new NavigationPage (new XamarinTestMasterView ());
			MainPage = mainNav;
		}

		protected override void OnStart () {
			string iKey = null;
			Device.OnPlatform(
				Android: () =>{
					iKey = "<YOUR-IOS-KEY>";
				},
				iOS: () =>{
					iKey = "<YOUR-ANDROID-KEY>";
				}
			);
			ApplicationInsights.Setup (iKey);
			ApplicationInsights.SetDebugLogEnabled (true);
			// Set up common properties
			Dictionary<string, string> commonProperties = new Dictionary<string, string> ();
			commonProperties.Add ("Common Key", "Common Property Value");
			ApplicationInsights.SetCommonProperties (commonProperties);
			ApplicationInsights.Start ();
		}

		protected override void OnSleep () {
			// Handle when your app sleeps
		}

		protected override void OnResume () {
			// Handle when your app resumes
		}
			
	}
}

