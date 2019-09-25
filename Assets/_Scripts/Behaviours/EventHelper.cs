using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public sealed class EventHelper : MonoBehaviour
	{
		public UnityEvent onEvent;

		private static void OnEvent([NotNull] UnityEvent unity)
		{
			unity.Invoke();
		}

		public void CallOnEvent()
		{
			OnEvent(onEvent);
		}
	}
}