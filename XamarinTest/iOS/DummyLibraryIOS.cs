using System;

[assembly: Xamarin.Forms.Dependency (typeof (XamarinTest.iOS.DummyLibraryIOS))]

namespace XamarinTest.iOS
{
	public class DummyLibraryIOS : IDummyLibrary
	{
		public DummyLibraryIOS ()
		{
		}

		public void TriggerSignalCrash(){
			DummyLibrary.TriggerSignalCrash();
		}

		public void TriggerExceptionCrash(){
			DummyLibrary.TriggerExceptionCrash();
		}
	}
}

