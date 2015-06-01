
using System;

using Foundation;
using UIKit;

namespace SampleApp
{
	public class ExampleTableViewControllerSource : UITableViewSource
	{
		const int kMSAIIndexCrashSection = 0;
		const int kMSAIIndexTrackSection = 1;
		const int kMSAIIndexAutoCollectionSection = 2;
		const int kMSAIIndexConfigurationSection = 3;

		string cellIdentifier = "cell";

		private UISwitch autoPageViewSwitch = new UISwitch();
		private bool autoPageViewsEnabled = true;

		private UISwitch autoSessionSwitch = new UISwitch();
		private bool autoSessionEnabled = true;

		public ExampleTableViewControllerSource ()
		{
			autoPageViewSwitch.On = autoPageViewsEnabled;
			autoSessionSwitch.On = autoSessionEnabled;
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
		}

	}

}

