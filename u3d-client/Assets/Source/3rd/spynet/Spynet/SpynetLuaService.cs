using System;
using UniLua;

namespace Spynet
{
    class SpynetLuaService
    {
    	private ILuaState mLuaState;

    	public void Init ()
    	{
    		mLuaState = LuaAPI.NewState();
			mLuaState.L_OpenLibs();
    	}
    }
}
