
using System;

using Foundation;
using UIKit;
using ApplicationInsightsIOS;
using TestCrashBindings;

namespace SampleApp
{
	public class ExampleTableViewControllerSource : UITableViewSource
	{
		const int kMSAIIndexCrashSection = 0;
		const int kMSAIIndexTrackSection = 1;
		const int kMSAIIndexAutoCollectionSection = 2;
		const int kMSAIIndexConfigurationSection = 3;

		string cellIdentifier = "cell";

		UINavigationController navigationController;
		UITableView tableView;

		private ExampleAlertViewDelegate alertViewDelegate;

		private UISwitch autoPageViewSwitch = new UISwitch();
		private bool autoPageViewsEnabled = true;

		private UISwitch autoSessionSwitch = new UISwitch();
		private bool autoSessionEnabled = true;

		private string userId;
		private string serverUrl;

		public ExampleTableViewControllerSource (UINavigationController nc, UITableView tableView)
		{
			navigationController = nc;
			this.tableView = tableView;

			autoPageViewSwitch.On = autoPageViewsEnabled;
			autoPageViewSwitch.AddTarget(OnPageViewSwitchChanged, UIControlEvent.ValueChanged);

			autoSessionSwitch.On = autoSessionEnabled;
			autoSessionSwitch.AddTarget(OnSessionSwitchChanged, UIControlEvent.ValueChanged);

			if (ExampleHelper.USE_AI) {
				serverUrl = ApplicationInsights.GetServerUrl();
			}

			userId = "";
		}

		private ExampleAlertViewDelegate GetAlertViewDelegate(){
			if(alertViewDelegate == null){
				alertViewDelegate = new ExampleAlertViewDelegate(this);
			}
			return alertViewDelegate;
		}

		private void OnPageViewSwitchChanged(object sender, EventArgs e)
		{
			autoPageViewsEnabled = autoPageViewSwitch.On;
//			ApplicationInsights.SetAutoPageViewTrackingDisabled(!autoPageViewsEnabled);
		}

		private void OnSessionSwitchChanged(object sender, EventArgs e)
		{
			autoSessionEnabled = autoSessionSwitch.On;
			if (ExampleHelper.USE_AI) {
				ApplicationInsights.SetAutoSessionManagementDisabled (!autoSessionEnabled);
			}
		}

		private void ShowUserIdAlert(){
			UIAlertView alert = new UIAlertView("User", "Enter an user ID", GetAlertViewDelegate(), "Cancel", "OK");
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			alert.Tag = ExampleHelper.kMSAITelemetryAlertTagUserId;
			alert.GetTextField (0).Text = userId;
			alert.Show();
		}

		private void ShowRenewSessionAlert(){
			UIAlertView alert = new UIAlertView("Renew session", "Enter the ID for a new session", GetAlertViewDelegate(), "Cancel", "Renew");
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			alert.Tag = ExampleHelper.kMSAITelemetryAlertTagRenewSession;
			alert.Show();
		}

		private void ShowServerUrlAlert(){
			UIAlertView alert = new UIAlertView("Telemetry server", "Enter a new server url", GetAlertViewDelegate(), "Cancel", "OK");
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			alert.Tag = ExampleHelper.kMSAITelemetryAlertTagServerUrl;
			alert.GetTextField (0).Text = serverUrl;
			alert.Show();
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 4;
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			switch (section) {
			case kMSAIIndexCrashSection:
				return "Crash Reporting";
			case kMSAIIndexTrackSection:
				return "Track Telemetry Data";
			case kMSAIIndexAutoCollectionSection:
				return "Auto Collection";
			default:
				return "Configuration";
			}
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			switch (section) {
			case kMSAIIndexCrashSection:
				return 3;
			case kMSAIIndexTrackSection:
				return 3;
			case kMSAIIndexAutoCollectionSection:
				return 4;
			default:
				return 2;
			}
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath){

			nint section = indexPath.Section;
			nint row = indexPath.Row;

			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			cell.AccessoryView = null;
			cell.Accessory = UITableViewCellAccessory.None;
			cell.DetailTextLabel.Text = "";

			if (section == kMSAIIndexCrashSection) {

				if (row == 0) {
					cell.TextLabel.Text = "Native unhandled exception";
				} else if (row == 1) {
					cell.TextLabel.Text = "Throw managed unhandled exception";
				}else if (row == 2) {
					cell.TextLabel.Text = "Managed exception: Null Ref";
				}

			} else if (section == kMSAIIndexTrackSection) {

				if (row == 0) {
					cell.TextLabel.Text = "Track event";
				} else if (row == 1) {
					cell.TextLabel.Text = "Track trace";
				} else if (row == 2) {
					cell.TextLabel.Text = "Track metric";
				}

			} else if (section == kMSAIIndexAutoCollectionSection) {

				if (row == 0) {
					cell.TextLabel.Text = "Auto session management";
					cell.AccessoryView = autoSessionSwitch;
				} else if (row == 1) {
					cell.TextLabel.Text = "Start new session";
				} else if (row == 2) {
					cell.TextLabel.Text = "Auto page views";
					cell.AccessoryView = autoPageViewSwitch;
				} else if (row == 3) {
					cell.TextLabel.Text = "Trigger page view";
					cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				}

			} else if (section == kMSAIIndexConfigurationSection) {

				if (row == 0) {
					cell.TextLabel.Text = "Server url";
					cell.DetailTextLabel.Text = serverUrl;
				} else if (row == 1) {
					cell.TextLabel.Text = "User Id";
					cell.DetailTextLabel.Text = userId;
				}
			}
				
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			nint section = indexPath.Section;
			nint row = indexPath.Row;

			if (section == kMSAIIndexCrashSection) {

				if (row == 0) {
					ExamplePlugin.ForceAppCrash ();
				} else if (row == 1) {
					FirstExampleMethod ();
				} else if (row == 2) {
					CreateNullRefException ();
				}

			} else if (section == kMSAIIndexTrackSection) {

				if (row == 0) {
					
						TelemetryManager.TrackEvent ("My Event");

				} else if (row == 1) {
					if (ExampleHelper.USE_AI) {
						TelemetryManager.TrackTrace ("My Trace");
					}
				} else if (row == 2) {
					if (ExampleHelper.USE_AI) {
						TelemetryManager.TrackMetric ("My Metric", 2.0);
					}
				}

			} else if (section == kMSAIIndexAutoCollectionSection) {

				if (row == 1) {
					ShowRenewSessionAlert ();
				} else if (row == 3) {
					UIViewController vc = new UIViewController ();
					vc.Title = "Detail View Controller";
					if(navigationController != null){
						vc.View.BackgroundColor = UIColor.White;
						navigationController.PushViewController (vc, true);
					}
				}

			} else if (section == kMSAIIndexConfigurationSection) {

				if (row == 0) {
					ShowServerUrlAlert ();
				} else if (row == 1) {
					ShowUserIdAlert ();
				}

			}
		}

		class ExampleAlertViewDelegate : UIAlertViewDelegate {

			private ExampleTableViewControllerSource outerClass;

			public ExampleAlertViewDelegate(ExampleTableViewControllerSource outerClass){
				this.outerClass = outerClass;
			}

			public override void Clicked (UIAlertView alertview, nint buttonIndex)
			{
				if (buttonIndex == 0) {
					return;
				}

				switch (alertview.Tag) {
				case ExampleHelper.kMSAITelemetryAlertTagRenewSession:{
						string sessionId = alertview.GetTextField (0).Text;
						if (ExampleHelper.USE_AI) {
							ApplicationInsights.RenewSessionWithId (sessionId);
						}			
						break;
					}
				case ExampleHelper.kMSAITelemetryAlertTagUserId:{
						string userId = alertview.GetTextField (0).Text;
						outerClass.userId = userId;
						outerClass.tableView.ReloadData();
						break;
					}

				case ExampleHelper.kMSAITelemetryAlertTagServerUrl:{
						string serverUrl = alertview.GetTextField (0).Text;
						outerClass.serverUrl = serverUrl;
						outerClass.tableView.ReloadData();
						break;
					}
				}
			}
		}

		public void FirstExampleMethod(){
			SecondExampleMethod();
		}

		public void SecondExampleMethod(){
			ThirdExampleMethod();
		}

		public void ThirdExampleMethod(){
			LastExampleMethod ();
		}

		public void LastExampleMethod(){
			throw new Exception("Managed unhandled Exception");
		}

		public void CreateNullRefException(){
			try {
				object o = null;
				o.GetHashCode ();
			} catch {
				// Catch block isn't called with crash reporting enabled.
				// Instead, the app will crash.
			}
		}
	}
}

