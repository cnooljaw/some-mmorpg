using System;

namespace Spynet
{
    class SpynetMessage
    {
		public uint Source;
        public int Session;
        public byte[] Data;

        public SpynetMessage ()
		{
		}
    }
}
