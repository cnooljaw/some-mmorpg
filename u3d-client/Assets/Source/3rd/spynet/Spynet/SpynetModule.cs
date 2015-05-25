using System;

namespace Spynet
{
    public interface SpynetModule
    {
        string Name ();
		object Create ();
        void Destroy ();
		bool Init (object instance, SpynetService service, string arg);
    }
}
