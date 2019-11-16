using System.Collections.Generic;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Events
{
	[CreateAssetMenu(fileName = "NewEvent", menuName = "Scriptable/Events/GameEvent", order = 1)]
	public sealed class GameEvent : ScriptableObject
	{
		/// <summary>
		/// The list of listeners that this event will notify if it is raised.
		/// </summary>
		private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

		public void Raise()
		{
			for (int i = _eventListeners.Count - 1; i >= 0; i--)
			{
				_eventListeners[i].OnEventRaised(this);
			}
		}

		internal void RegisterListener(GameEventListener listener)
		{
			if (!_eventListeners.Contains(listener))
			{
				_eventListeners.Add(listener);
			}
		}

		internal void UnregisterListener(GameEventListener listener)
		{
			if (_eventListeners.Contains(listener))
			{
				_eventListeners.Remove(listener);
			}
		}
	}
}