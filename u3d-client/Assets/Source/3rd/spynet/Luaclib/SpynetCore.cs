using System;
using UniLua;

namespace Spynet
{
    public static class SpynetCore
    {
        public const string LIB_NAME = "spynet.core";

        private const int CALLBACK_FUNC_INDEX = 9527;

        public static void CallbackWrapper (object ud, SpynetMessage message)
        {
        }

        public static int Callback (ILuaState lua)
        {
            SpynetService service = (SpynetService)lua.ToUserData (lua.UpvalueIndex (1));

            lua.L_CheckType (1, LuaType.LUA_TFUNCTION);
            lua.SetTop (1);
            lua.RawSetI (LuaDef.LUA_REGISTRYINDEX, CALLBACK_FUNC_INDEX);

            lua.RawGetI (LuaDef.LUA_REGISTRYINDEX, LuaDef.LUA_RIDX_MAINTHREAD);
            ILuaState gl = lua.ToThread (-1);

            service.SetCallback (CallbackWrapper, gl);

            return 0;
        }

        public static int OpenLib (ILuaState lua)
        {
            var t = new NameFuncPair[]
            {
                new NameFuncPair("callback", Callback),
            };

            lua.L_NewLibTable (t);
            lua.GetField (LuaDef.LUA_REGISTRYINDEX, "spynet_context");
            if (lua.ToUserData (-1) == null)
            {
                return lua.L_Error ("please init spynet_context first");
            }
            lua.L_SetFuncs (t, 1);

            return 1;
        }
    }
}
