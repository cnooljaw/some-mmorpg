using System;

namespace Spynet
{
    class SpynetService
    {
		public uint Handle;
		public delegate void DispatchCallbackFunc ();

		private DispatchCallbackFunc mCallback;
		private object mCallbackData;

		public SpynetService (uint handle)
		{
			Handle = handle;
		}

		public bool Init (SpynetModule module, string arg)
		{
			object instance = module.Create ();
			bool ok = module.Init (instance, this, arg);
			return ok;
		}

		public void SetCallback (DispatchCallbackFunc func, object ud)
		{
			mCallback = func;
			mCallbackData = ud;
		}

        public bool Dispatch ()
        {
            return false;
        }
    }
}
