using System;

namespace Spynet
{
    public class SpynetConfig
	{
		public static SpynetConfig Instance;
		
		static SpynetConfig ()
		{
			Instance = new SpynetConfig ();
		}
		
		
		
		

        public string Start;
		public int Thread;
        public string LuaPath;
        public string ServicePath;
		public string Loader;

		public SpynetConfig ()
        {
            Start = "snlua main";
            Thread = 2;
        }
    }
}
