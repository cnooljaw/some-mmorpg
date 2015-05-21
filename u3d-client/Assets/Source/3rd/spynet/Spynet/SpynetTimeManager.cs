using System;
using System.Threading;

namespace Spynet
{
    class SpynetTimeManager
	{
		public static SpynetTimeManager Instance;

        static SpynetTimeManager ()
		{
            Instance = new SpynetTimeManager ();
		}




        private Thread mTimerThread;

        private void TimerFunc ()
        {
            while (true)
            {
                if (true)
                {
                    Thread.Sleep (1);
                }

                if (SpynetServiceManager.Instance.Empty ())
                {
                    break;
                }
            }
        }

        public void Start (int thread)
        {
            mTimerThread = new Thread (new ThreadStart (TimerFunc));
            mTimerThread.Start ();
        }
    }
}
