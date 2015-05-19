using System;
using UniLua;

namespace Spynet
{
	class SpynetLuaService : SpynetService
    {
    	private ILuaState mLuaState;

    	public void Init ()
    	{
    		mLuaState = LuaAPI.NewState();
			mLuaState.L_OpenLibs();
    	}

		public SpynetLuaService (string file)
		{
		}
    }
}
