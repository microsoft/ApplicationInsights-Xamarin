using System;

using Xamarin.Forms;

namespace XamarinTest
{
	public class XamarinTestDetailView : ContentPage
	{

		public XamarinTestDetailView (string labelText)
		{

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = labelText
					}
				}
			};
		}
	}
}


