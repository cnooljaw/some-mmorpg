using System;

namespace Spynet
{
    class SpynetService
    {
		public uint Id;

		public SpynetService (uint id)
		{
			Id = id;
		}

        public bool Dispatch ()
        {
            return false;
        }
    }
}
