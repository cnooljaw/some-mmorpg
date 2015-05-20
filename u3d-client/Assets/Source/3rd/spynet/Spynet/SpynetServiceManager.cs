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
		private uint mAvailableId;

		public SpynetServiceManager ()
		{
			mServices = new Dictionary<uint, SpynetService> ();
			mAvailableId = 1;
		}

        public void AddService (string module, string arg)
        {
			SpynetModule m = SpynetModuleManager.Instance.GetModule (module);
			if (m == null)
				return;

			object instance = m.Create ();

			lock (this)
			{
				while (mServices.ContainsKey (mAvailableId))
				{
					mAvailableId++;
				}

				SpynetService service = new SpynetService(mAvailableId);
				bool ok = m.Init (instance, service, arg);
				if (ok)
				{
					mServices.Add (service.Id, service);
					SpynetMessageManager.Instance.Push (service);
				}
				else
				{
				}
			}
        }
    }
}
