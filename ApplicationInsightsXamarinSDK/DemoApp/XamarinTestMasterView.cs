using System;
using Xamarin.Forms;
using AI.XamarinSDK.Abstractions;
using System.Collections.Generic;

namespace XamarinTest
{
	public class XamarinTestMasterView : ContentPage
	{

		TableView tableView;
		SwitchCell autoSessionManagementCell;
		SwitchCell autoPageViewsCell;
		EntryCell serverURLCell;
		EntryCell userIDCell;

		enum TelemetryType
		{
			None,
			Event,
			Message,
			Metric,
			PageView,
			Session
		};

		public XamarinTestMasterView ()
		{

			SetupActionCells ();

			// Set up navigation
			Title = "Xamarin SDK";
			NavigationPage.SetHasNavigationBar (this, true);

			// Set up common properties
			Dictionary<string, string> commonProperties = new Dictionary<string, string> ();
			commonProperties.Add ("Common Key", "Common Property Value");
			ApplicationInsights.SetCommonProperties (commonProperties);

			// Set up page
			tableView = new TableView {
				Intent = TableIntent.Settings,
				Root = new TableRoot {
					new TableSection ("Telemetry data") {
						new TextCell { 
							Text = "Track event",
							Command = new Command (() => TrackTelemetryData(TelemetryType.Event))
						},
						new TextCell { 
							Text = "Track message" ,
							Command = new Command (() => TrackTelemetryData(TelemetryType.Message))
						},
						new TextCell { 
							Text = "Track metric",
							Command = new Command (() => TrackTelemetryData(TelemetryType.Metric))
						}
					},
					new TableSection ("Page views") {
						new TextCell { 
							Text = "Track page view" ,
							Command = new Command (() => TrackTelemetryData(TelemetryType.PageView))
						},
						#if __IOS__
						new TextCell { 
							Text = "Trigger auto page view" ,

							Command = new Command (() => Navigation.PushAsync (new XamarinTestDetailView("Page view triggered")))
						},
						#endif
						autoPageViewsCell
					},
					new TableSection ("Sessions") {
						autoSessionManagementCell
					},
					new TableSection ("Configuration") {
						userIDCell,
						serverURLCell
					},
				},
			};

			Content = tableView;
		}

		private void SetupActionCells(){

			// Set up switch cells
			autoSessionManagementCell = new SwitchCell { 
				Text = "Auto session management", 
				On = true ,
			};
			autoSessionManagementCell.OnChanged += (sender, ea) => {
				ApplicationInsights.SetAutoSessionManagementDisabled(!autoSessionManagementCell.On);
			};

			autoPageViewsCell = new SwitchCell { 
				Text = "Auto page view tracking", 
				On = true ,
			};
			autoPageViewsCell.OnChanged += (sender, ea) => {
				ApplicationInsights.SetAutoPageViewTrackingDisabled(!autoPageViewsCell.On);
			};

			// TODO: also update ApplicationInsights config if input field lost focus
			serverURLCell = new EntryCell(){ 
				Label = "Server URL", 
				Placeholder = "Custom server URL" 
			};
			serverURLCell.Completed += (sender, ea) => {
				ApplicationInsights.SetServerUrl(serverURLCell.Text);
			};

			userIDCell = new EntryCell(){ 
				Label = "User ID", 
				Placeholder = "Custom user ID"
			};
			userIDCell.Completed += (sender, ea) => {
				ApplicationInsights.SetAuthUserId(userIDCell.Text);
			};
		}

		private void TrackTelemetryData(TelemetryType type){

			switch (type) {
			case TelemetryType.Event:
				Dictionary<string, string> properties = new Dictionary<string, string> ();
				properties.Add ("Xamarin Key", "Custom Property Value");
				TelemetryManager.TrackEvent ("My custom event", properties);
				break;
			case TelemetryType.Metric:
				TelemetryManager.TrackMetric ("My custom metric", 2.2);
				break;
			case TelemetryType.Message:
				TelemetryManager.TrackTrace ("My custom message");
				break;
			case TelemetryType.PageView:
				TelemetryManager.TrackPageView ("My custom page view", 100);
				break;
			case TelemetryType.Session:
				ApplicationInsights.RenewSessionWithId (new DateTime().Date.ToString());
				break;
			default:
				break;
			}
		}
	}
}


