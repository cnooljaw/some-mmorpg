using System;
using System.Collections.Generic;

namespace Spynet
{
    class SpynetMessageManager
	{
		public static SpynetMessageManager Instance;
		
		static SpynetMessageManager ()
		{
			Instance = new SpynetMessageManager ();
		}




        Queue<SpynetService> mServiceQueue;

        public SpynetMessageManager ()
        {
            mServiceQueue = new Queue<SpynetService> ();
        }

        public bool Dispatch ()
        {
            SpynetService service = null;
            lock (mServiceQueue)
            {
                if (mServiceQueue.Count == 0)
                    return false;

                service = mServiceQueue.Dequeue ();
            }

            bool more = service.Dispatch ();
            service.SetActive (more);

            return more;
        }

		public void Active (SpynetService service)
		{
            lock (mServiceQueue)
            {
                mServiceQueue.Enqueue (service);
            }
		}
    }
}
