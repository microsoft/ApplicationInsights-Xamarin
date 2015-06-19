using System;

namespace XamarinTest
{
	public interface IDummyLibrary
	{
		#if __IOS__
		void TriggerSignalCrash();
		#endif

		void TriggerExceptionCrash();
	}
}

