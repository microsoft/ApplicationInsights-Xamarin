using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class DummyLibrary
	{
		public DummyLibrary ()
		{
		}

		public static void TriggerSignalCrash(){
			DependencyService.Get<IDummyLibrary> ().TriggerSignalCrash ();
		}

		public static void TriggerExceptionCrash(){
			DependencyService.Get<IDummyLibrary> ().TriggerExceptionCrash ();
		}
	}
}

