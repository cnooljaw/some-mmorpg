using System;

namespace Spynet
{
    class Spynet
    {
        public static void Start (string c)
		{
            SpynetConfig config = new SpynetConfig ();
            config.Load (c);

            SpynetServiceManager.Instance.AddService (config.Bootstrap);
            SpynetServiceManager.Instance.AddService (config.Start);

            SpynetThreadManager.Instance.Start (config.Thread);
		}
    }
}
