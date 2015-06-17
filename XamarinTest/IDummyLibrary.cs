using System;

namespace XamarinTest
{
	public interface IDummyLibrary
	{
		void TriggerSignalCrash();

		void TriggerExceptionCrash();
	}
}

