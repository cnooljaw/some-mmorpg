using System;

namespace Spynet
{
    interface SpynetModule
    {
        string Name ();
        void Create ();
        void Destroy ();
        void Init ();
    }
}
