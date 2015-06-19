using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class DummyLibrary
	{
		public DummyLibrary ()
		{
		}

		#if __IOS__
		public static void TriggerSignalCrash(){
			DependencyService.Get<IDummyLibrary> ().TriggerSignalCrash ();
		}
		#endif

		public static void TriggerExceptionCrash(){
			DependencyService.Get<IDummyLibrary> ().TriggerExceptionCrash ();
		}
	}
}

