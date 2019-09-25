using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Events
{
	[Serializable]
	public sealed class GameEventListener : MonoBehaviour
	{
		public List<EventAndResponse> eventAndResponse = new List<EventAndResponse>();

		private void OnEnable()
		{
			if (eventAndResponse.Count >= 1)
			{
				foreach (EventAndResponse item in eventAndResponse)
				{
					item.gameEvent.RegisterListener(this);
				}
			}
		}

		private void OnDisable()
		{
			if (eventAndResponse.Count >= 1)
			{
				foreach (EventAndResponse item in eventAndResponse)
				{
					item.gameEvent.UnregisterListener(this);
				}
			}
		}

		internal void OnEventRaised(GameEvent passedEvent)
		{
			for (int i = eventAndResponse.Count - 1; i >= 0; i--)
			{
				// Check if the passed event is the correct one
				if (passedEvent == eventAndResponse[i].gameEvent)
				{
					eventAndResponse[i].response.Invoke();
				}
			}
		}
	}

	[Serializable]
	public struct EventAndResponse
	{
		public string name;

		[Tooltip("Event to register with.")]
		public GameEvent gameEvent;

		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent response;
	}
}