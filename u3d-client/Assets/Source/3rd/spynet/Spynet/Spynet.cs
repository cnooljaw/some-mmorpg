using System;
using UnityEngine;

namespace Spynet
{
    public class Spynet
    {
		public static void Start ()
		{

			SpynetServiceManager.Instance.NewService (SpynetConfig.Instance.Start);
            SpynetThreadManager.Instance.Start ();
		}

		public static void Log (object msg)
		{
			Debug.Log (msg);
		}
    }
}
