using System;

[assembly: Xamarin.Forms.Dependency (typeof (XamarinTest.Droid.DummyLibraryAndroid))]

namespace XamarinTest.Droid
{
	public class DummyLibraryAndroid : IDummyLibrary
	{
		public DummyLibraryAndroid ()
		{
		}

		public void TriggerSignalCrash(){
			// TODO: Call android method
		}

		public void TriggerExceptionCrash(){
			// TODO: Call android method
		}
	}
}

