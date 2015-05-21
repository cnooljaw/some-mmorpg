using System;

namespace Spynet
{
    class SpynetConfig
    {
        public string Bootstrap;
        public string Start;
        public int Thread;

        public void Load (string file)
        {
            Bootstrap = "snlua bootstrap";
            Start = "snlua main";
            Thread = 2;
        }
    }
}
