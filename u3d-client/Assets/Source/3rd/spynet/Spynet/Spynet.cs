using System;

namespace Spynet
{
    class Spynet
    {
		private static Spynet sInstance;
    	private SpynetServiceManager mServiceManager;

		static Spynet ()
		{
			sInstance = new Spynet ();
		}

		private void Run (string file)
		{
			mServiceManager = new SpynetServiceManager ();
			var service = new SpynetLuaService (file);
			mServiceManager.AddService (service);
		}

        public static void Start(string file)
        {
			sInstance.Run (file);
        }
    }
}
