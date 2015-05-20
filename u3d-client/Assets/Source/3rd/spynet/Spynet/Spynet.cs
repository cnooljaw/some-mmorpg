using System;

namespace Spynet
{
    class Spynet
    {
       public static void Start (string module, string file)
		{
			SpynetServiceManager.Instance.AddService (module, file);
			SpynetThreadManager.Instance.Start();
		}
    }
}
