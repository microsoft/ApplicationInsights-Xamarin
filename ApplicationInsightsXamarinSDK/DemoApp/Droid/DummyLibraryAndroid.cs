using System;
using Com.Microsoft.AI.Xamarinexample;
using Xamarin.Forms;
using Android.App;

[assembly: Xamarin.Forms.Dependency (typeof (XamarinTest.Droid.DummyLibraryAndroid))]

namespace XamarinTest.Droid
{
	public class DummyLibraryAndroid : Java.Lang.Object, IDummyLibrary
	{
		public DummyLibraryAndroid ()
		{
		}

		public void TriggerExceptionCrash(){
			ExampleClass library = new ExampleClass();
			library.ForceAppCrash ((Activity) Forms.Context);
		}
	}
}

