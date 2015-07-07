using System;
using DummyLibrary.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (XamarinTest.iOS.DummyLibraryIOS))]

namespace XamarinTest.iOS
{
	public class DummyLibraryIOS :IDummyLibrary
	{
		public DummyLibraryIOS (){}

		public void TriggerSignalCrash(){
			ExamplePlugin.TriggerSignalCrash();
		}

		public void TriggerExceptionCrash(){
			ExamplePlugin.TriggerExceptionCrash();
		}
	}
}

