using System;

namespace Spynet
{
    class Spynet
    {
    	SpynetServiceManager mServiceManager;

        public static void Start(string file)
        {
        	mServiceManager = new SpynetServiceManager ();
        	var service = new SpynetLuaService (file);
        	mServiceManager.AddService (service);
        }
    }
}
