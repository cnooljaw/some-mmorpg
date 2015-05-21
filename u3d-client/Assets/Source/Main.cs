using System;
using Spynet;

class Main
{
    static void Start()
    {
		SpynetConfig config = new SpynetConfig ();
		Spynet.Spynet.Start (config);
    }
}
