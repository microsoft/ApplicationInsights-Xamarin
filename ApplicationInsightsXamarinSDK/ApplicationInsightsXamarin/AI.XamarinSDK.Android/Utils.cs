using System;
using Android.Runtime;

namespace AI.XamarinSDK.Android
{
	public class Utils
	{
		public static readonly string[] JAVA_EXCEPTION_PREFIXES = {"java.lang.", "android."};

		public static bool IsManagedException(Exception exception){
			string exceptionType = exception.GetBaseException ().GetType ().ToString ();
			foreach (string prefix in JAVA_EXCEPTION_PREFIXES) {
				if (exceptionType.ToLower ().StartsWith (prefix)) {
					return false;
				}
			}
			return true;
		}

	}
}

