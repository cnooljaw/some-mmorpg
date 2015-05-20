using System;
using UniLua;

namespace Spynet
{
	class SpynetLuaModule : SpynetModule
    {
    	private ILuaState mLuaState;

        public string Name ()
        {
            return "snlua";
        }

		public object Create ()
        {
			SpynetLuaModule instance = new SpynetLuaModule ();

			instance.mLuaState = LuaAPI.NewState ();
			instance.mLuaState.L_OpenLibs ();

			return instance;
        }

        public void Destroy ()
        {
        }

		public bool Init (object instance, SpynetService service, string arg)
        {
			return true;
        }

    }
}
