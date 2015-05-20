using System;

namespace Spynet
{
    class Spynet
    {
        private SpynetModuleManager mModuleManager;
        private SpynetMessageManager mMessageManager;
        private SpynetThreadManager mThreadManager;
    	private SpynetServiceManager mServiceManager;

        public Spynet()
        {
            mModuleManager.Register (new SpynetLuaModule ());
        }

        public void Start (string module, string file)
		{
            mMessageManager = new SpynetMessageManager();

			mServiceManager = new SpynetServiceManager ();
            mServiceManager.AddService (module, file);

            mThreadManager = new SpynetThreadManager();
            mThreadManager.Run();
		}
    }
}
