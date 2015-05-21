using System;

namespace Spynet
{
    class SpynetConfig
    {
        public string Start;
        public int Thread;

		public SpynetConfig ()
        {
            Start = "snlua main";
            Thread = 2;
        }
    }
}
