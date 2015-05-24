using System;
using System.IO;
using UniLua;
using Spynet;
using UnityEngine;

class Main : MonoBehaviour
{
    void Start()
	{
		string streamingAssetsPath = Application.streamingAssetsPath;
		string dataPath = Application.dataPath;
		LuaFile.AddPathHook ((s) => Path.Combine (Path.Combine (streamingAssetsPath, "LuaRoot"), s));
        LuaFile.AddPathHook ((s) => Path.Combine (dataPath, s));

		SpynetConfig.Instance.Loader = "Source/3rd/spynet/Lualib/loader.lua";
		SpynetConfig.Instance.LuaPath = "Source/3rd/spynet/Lualib/?.lua";
		SpynetConfig.Instance.ServicePath = "?.lua";
		Spynet.Spynet.Start ();
    }
}
