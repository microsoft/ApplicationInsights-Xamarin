using System;
using Xamarin.Forms;
using AI.XamarinSDK;

namespace XamarinTest
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
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

