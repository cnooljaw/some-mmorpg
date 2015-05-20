using System;

namespace Spynet
{
    interface SpynetModule
    {
        string Name ();
		object Create ();
        void Destroy ();
		bool Init (object instance, SpynetService service, string arg);
    }
}
