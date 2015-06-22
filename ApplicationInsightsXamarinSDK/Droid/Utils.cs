using System;
using Android.Runtime;

namespace AI.XamarinSDK.Android
{
	public class Utils
	{
		public Utils ()
		{
		}

		public static bool IsManagedException(Exception exception){
			// TODO: Check exception type (java.lang., android.) or exception source (entry assembly name) to determine whether the exception is thrown by managed or unmanaged code.
			return exception.Source.Equals("XamarinTest.Droid")
		}

	}
}

