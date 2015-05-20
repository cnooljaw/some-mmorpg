using System;
using System.Collections.Generic;

namespace Spynet
{
    class SpynetModuleManager
    {
        private Dictionary<string, SpynetModule> mModules;

        public SpynetModuleManager ()
        {
            mModules = new Dictionary<string, SpynetModule> ();
        }

        public void Register (SpynetModule m)
        {
            mModules.Add (m.Name (), m);
        }
    }
}
