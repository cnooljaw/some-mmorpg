using System;
using UniLua;

namespace Spynet
{
	class SpynetLuaModule : SpynetModule
    {
    	private ILuaState mLuaState;

        string Name ()
        {
            return "snlua";
        }

        public void Create ()
        {
            mLuaState = LuaAPI.NewState ();
            mLuaState.L_OpenLibs ();
        }

        public void Destroy ()
        {
        }

        public void Init ()
        {
        }

    }
}
