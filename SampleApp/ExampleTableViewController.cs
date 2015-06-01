using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SampleApp
{
	partial class ExampleTableViewController : UITableViewController
	{


		public ExampleTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.Source = new ExampleTableViewControllerSource();
		}
	}
}
