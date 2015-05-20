using System;
using System.Collections.Generic;

namespace Spynet
{
    class SpynetModuleManager
    {
		public static SpynetModuleManager Instance;

		static SpynetModuleManager ()
		{
			Instance = new SpynetModuleManager ();
			Instance.Register (new SpynetLuaModule ());
		}



        private Dictionary<string, SpynetModule> mModules;

        public SpynetModuleManager ()
        {
            mModules = new Dictionary<string, SpynetModule> ();
        }

        public void Register (SpynetModule m)
        {
            mModules.Add (m.Name (), m);
        }

		public SpynetModule GetModule (string name)
		{
			if (mModules.ContainsKey (name))
				return mModules[name];
			return null;
		}
    }
}
