using System;

using Xamarin.Forms;

namespace XamarinTest
{
	public class XamarinTestTableView : ContentPage
	{
		public XamarinTestTableView ()
		{

			Title = "Xamarin SDK";
			NavigationPage.SetHasNavigationBar (this, true);

			// The root page of your application
			Content = new TableView {
				Intent = TableIntent.Settings,
				Root = new TableRoot {
					new TableSection ("Crash reproting") {
						new TextCell { Text = "Managed unhandled exception" },
						new TextCell { Text = "Managed handled exception" },
						new TextCell { Text = "Unmanaged unhandled exception" }
					},
					new TableSection ("Telemetry data") {
						new TextCell { Text = "Track event" },
						new TextCell { Text = "Track message" },
						new TextCell { Text = "Track metric" }
					},
					new TableSection ("Page views") {
						new TextCell { Text = "Track page view" },
						new TextCell { Text = "Trigger auto page view" },
						new SwitchCell { Text = "Auto page view tracking", On = true }
					},
					new TableSection ("Sessions") {
						new TextCell { Text = "Renew session" },
						new SwitchCell { Text = "Auto session management", On = true }
					},
					new TableSection ("Configuration") {
						new EntryCell { Label = "User ID", Placeholder = "My user ID" },
						new EntryCell { Label = "Server URL", Placeholder = "My server URL" }
					},
				},
			};
		}
	}
}


