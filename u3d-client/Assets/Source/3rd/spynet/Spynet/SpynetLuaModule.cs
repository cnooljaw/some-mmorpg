using System;
using UniLua;

namespace Spynet
{
    public class SpynetLuaModule : SpynetModule
    {
    	private ILuaState mLuaState;
        private SpynetService mService;

        public string Name ()
        {
            return "snlua";
        }

		public object Create ()
		{
			Spynet.Log ("SpynetLuaModule Create");
			SpynetLuaModule instance = new SpynetLuaModule ();

			instance.mLuaState = LuaAPI.NewState ();
			instance.mLuaState.L_OpenLibs ();
            instance.mLuaState.L_RequireF (SpynetCore.LIB_NAME, SpynetCore.OpenLib, false);

			return instance;
        }

        public void Destroy ()
        {
        }

        public void Dispatch (object ud, SpynetMessage message)
		{
			Spynet.Log ("SpynetLuaModule Dispatch");

			SpynetLuaModule instance = (SpynetLuaModule)ud;
			Spynet.Log (instance.mLuaState);
			
			Spynet.Log ("SpynetLuaModule set context");
            instance.mLuaState.PushLightUserData (instance.mService);
			instance.mLuaState.SetField (LuaDef.LUA_REGISTRYINDEX, "spynet_context");
			
			Spynet.Log ("SpynetLuaModule set lua path");
			instance.mLuaState.PushString (SpynetConfig.Instance.LuaPath);
			instance.mLuaState.SetGlobal ("LUA_PATH");
			
			Spynet.Log ("SpynetLuaModule set service path");
			instance.mLuaState.PushString (SpynetConfig.Instance.ServicePath);
			instance.mLuaState.SetGlobal ("LUA_SERVICE");
			
			Spynet.Log ("SpynetLuaModule load loader");
			var r = instance.mLuaState.L_LoadFile (SpynetConfig.Instance.Loader);
			Spynet.Log (r);
			Spynet.Log ("SpynetLuaModule call loader : " + message.Data);
			instance.mLuaState.PushString (message.Data);
			r = instance.mLuaState.PCall (1, 0, 0);
			Spynet.Log (r);
		}

		public bool Init (object ud, SpynetService service, string arg)
		{
			Spynet.Log ("SpynetLuaModule Init : " + arg);

            SpynetLuaModule instance = (SpynetLuaModule)ud;
            instance.mService = service;
			service.SetCallback (Dispatch, instance);
            service.SendMessage (service.Handle, arg);
			return true;
        }

    }
}
