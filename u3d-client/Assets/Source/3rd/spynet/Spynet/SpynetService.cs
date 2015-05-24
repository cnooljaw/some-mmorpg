using System;
using System.Collections.Generic;

namespace Spynet
{
    class SpynetService
    {
		public uint Handle;
		public delegate void DispatchCallbackFunc (object ud, SpynetMessage message);

		private DispatchCallbackFunc mCallback;
		private object mCallbackData;
        private bool mActive;
        private Queue<SpynetMessage> mMessageQueue;

		public SpynetService (uint handle)
		{
			Handle = handle;
            mActive = false;
            mMessageQueue = new Queue<SpynetMessage> ();
		}

		public bool Init (SpynetModule module, string arg)
		{
			Spynet.Log ("SpynetService Init");
			object instance = module.Create ();
			bool ok = module.Init (instance, this, arg);
			return ok;
		}

		public void SetCallback (DispatchCallbackFunc func, object ud)
		{
			mCallback = func;
			mCallbackData = ud;
		}

        public void SetActive (bool active)
        {
            if (mActive != active)
            {
                if (active)
                {
                    SpynetMessageManager.Instance.Active (this);
                }
                mActive = active;
            }
        }

        public void SendMessage (uint dest, string data)
		{
			Spynet.Log ("SpynetService SendMessage from " + Handle + " to " + dest + " : " + data);
            SpynetServiceManager.Instance.SendMessage (Handle, dest, data);
        }

        public void PushMessage (SpynetMessage message)
        {
            lock (mMessageQueue)
			{
				Spynet.Log ("SpynetService PushMessage");
                mMessageQueue.Enqueue (message);
            }
        }

        public bool Dispatch ()
        {
            lock (mMessageQueue)
            {
                if (mMessageQueue.Count == 0)
                    return false;
				
				Spynet.Log ("SpynetService Dispatch");
                SpynetMessage message = mMessageQueue.Dequeue ();
                if (mCallback != null)
                {
                    mCallback (mCallbackData, message);
                }
            }
            return true;
        }
    }
}
