using System;
using System.Threading;

namespace Spynet
{
    class SpynetThreadManager
	{
		public static SpynetThreadManager Instance;
		
		static SpynetThreadManager ()
		{
			Instance = new SpynetThreadManager ();
		}




        private Thread[] mWorkerThreads;

        private void WorkerFunc ()
        {
            while (true)
            {
                bool ok = SpynetMessageManager.Instance.Dispatch ();
                if (ok == false)
                {
                    Thread.Sleep (1);
                }

                if (SpynetServiceManager.Instance.Empty ())
                {
                    break;
                }
            }
        }

        public void Start ()
        {
			int thread = SpynetConfig.Instance.Thread;

            mWorkerThreads = new Thread[thread];
            for (int i = 0; i < thread; i++)
            {
                mWorkerThreads[i] = new Thread (new ThreadStart (WorkerFunc));
                mWorkerThreads[i].Start ();
            }
        }
    }
}
