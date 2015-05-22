using System;
using System.Collections.Generic;

namespace Spynet
{
    class SpynetServiceManager
	{
		public static SpynetServiceManager Instance;
		
		static SpynetServiceManager ()
		{
			Instance = new SpynetServiceManager ();
		}
		
		
		

		private Dictionary<uint, SpynetService> mServices;
		private uint mNextTryHandle;

		public SpynetServiceManager ()
		{
			mServices = new Dictionary<uint, SpynetService> ();
			mNextTryHandle = 1;
		}

		private uint FindFreeHandle ()
		{
			lock (this)
			{
				while (mNextTryHandle == 0 || mServices.ContainsKey (mNextTryHandle))
				{
					mNextTryHandle++;
				}
				return mNextTryHandle;
			}
		}

		private void AddService (SpynetService service)
		{
			lock (this)
			{
				mServices.Add (service.Handle, service);
			}
		}

        private SpynetService GetService (uint handle)
        {
            lock (this)
            {
                if (mServices.ContainsKey (handle))
                    return mServices[handle];
            }
            return null;
        }

		public void NewService (string cmd)
        {
            string[] words = cmd.Split (' ');
            string module = words[0];
            string arg = words[1];

			SpynetModule m = SpynetModuleManager.Instance.GetModule (module);
			if (m == null)
				return;

			uint handle = FindFreeHandle ();
			SpynetService service = new SpynetService(handle);
			bool ok = service.Init (m, arg);
			if (ok)
			{
				AddService (service);
                service.SetActive (true);
			}
        }

        public bool Empty ()
        {
            return (mServices.Count == 0);
        }

        public void SendMessage (uint src, uint dest, string data)
        {
            SpynetMessage message = new SpynetMessage (src, dest, data);
            SpynetService target = GetService (dest);
            if (target != null)
            {
                target.PushMessage (message);
                target.SetActive (true);
            }
        }
    }
}
