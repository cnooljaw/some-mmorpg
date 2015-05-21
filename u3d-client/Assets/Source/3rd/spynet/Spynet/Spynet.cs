using System;

namespace Spynet
{
    class Spynet
    {
		public static void Start (SpynetConfig config)
		{
            SpynetServiceManager.Instance.NewService (config.Start);
            SpynetThreadManager.Instance.Start (config.Thread);
		}
    }
}
