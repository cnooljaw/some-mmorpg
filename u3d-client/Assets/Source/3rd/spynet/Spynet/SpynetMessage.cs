using System;

namespace Spynet
{
    class SpynetMessage
    {
		public uint Source;
        public uint Destination;
        public string Data;

        public SpynetMessage (uint src, uint dest, string data)
		{
            Source = src;
            Destination = dest;
            Data = data;
		}
    }
}
