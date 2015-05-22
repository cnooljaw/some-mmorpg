using System;
using System.IO;
using UniLua;
using Spynet;

class Main
{
    static void Start()
    {
        LuaFile.AddPathHook ((s) => Path.Combine (Application.persistentDataPath, s));
        LuaFile.AddPathHook ((s) => Path.Combine (Application.dataPath, s));
		SpynetConfig config = new SpynetConfig ();
        config.LuaPath = "Source/3rd/spynet/Lualib/?.lua";
        config.ServicePath = "LuaRoot/?.lua";
		Spynet.Spynet.Start (config);
    }
}
