
using System;

using Foundation;
using UIKit;
using ApplicationInsightsXamarinIOS;

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

		private UISwitch autoPageViewSwitch = new UISwitch();
		private bool autoPageViewsEnabled = true;

		private UISwitch autoSessionSwitch = new UISwitch();
		private bool autoSessionEnabled = true;

		public ExampleTableViewControllerSource (UINavigationController nc)
		{
			navigationController = nc;

			autoPageViewSwitch.On = autoPageViewsEnabled;
			autoPageViewSwitch.AddTarget(OnPageViewSwitchChanged, UIControlEvent.ValueChanged);

			autoSessionSwitch.On = autoSessionEnabled;
			autoSessionSwitch.AddTarget(OnSessionSwitchChanged, UIControlEvent.ValueChanged);
		}

		private void OnPageViewSwitchChanged(object sender, EventArgs e)
		{
			autoPageViewsEnabled = autoPageViewSwitch.On;
			ApplicationInsights.SetAutoPageViewTrackingDisabled(!autoPageViewsEnabled);
		}

		private void OnSessionSwitchChanged(object sender, EventArgs e)
		{
			autoSessionEnabled = autoSessionSwitch.On;
			ApplicationInsights.SetAutoSessionManagementDisabled(!autoSessionEnabled);
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
				return 2;
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
					cell.TextLabel.Text = "Managed unhandled exception";
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
				} else if (row == 1) {
					cell.TextLabel.Text = "User Id";
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
					// TODO: Trigger native crash
				} else if (row == 1) {
					throw new Exception("Managed unhandled Exception");
				}

			} else if (section == kMSAIIndexTrackSection) {

				if (row == 0) {
					TelemetryManager.TrackEvent ("My Event");
				} else if (row == 1) {
					TelemetryManager.TrackTrace ("My Trace");
				} else if (row == 2) {
					TelemetryManager.TrackMetric ("My Metric", 2.0);
				}

			} else if (section == kMSAIIndexAutoCollectionSection) {

				if (row == 1) {
					// TODO: Show session alert;
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
					// TODO: Show server url alert
				} else if (row == 1) {
					// TODO Show user id alert
				}

			}
		}

	}

}

