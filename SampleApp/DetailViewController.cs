
using System;
using System.Collections;
using Foundation;
using UIKit;

using ApplicationInsightsXamarinIOS;

namespace SampleApp
{
	public partial class DetailViewController : UIViewController
	{
		public DetailViewController () : base ("DetailViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
		}
	}
}

