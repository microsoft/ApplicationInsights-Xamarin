using System;

namespace XamarinTest
{
	public class DummyLibrary
	{
		public DummyLibrary ()
		{
		}

		public static void TriggerSignalCrash(){
			Xamarin.Forms.DependencyService.Get<IDummyLibrary> ().TriggerSignalCrash();
		}

		public static void TriggerExceptionCrash(){
			Xamarin.Forms.DependencyService.Get<IDummyLibrary> ().TriggerExceptionCrash();
		}
	}
}

