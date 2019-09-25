using System;
using com.ArkAngelApps.TheAvarice.MyEditor.Extensions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	public enum ColliderType
	{
		Collision,
		Trigger,
		Both
	}

	[RequireComponent(typeof(Collider2D))]
	public class ColliderHelper : BaseBehaviour
	{
		[Tooltip("Layers that can interact with the collider/trigger")]
		public LayerMask layers;

		[Serializable]
		public struct EventFields
		{
			public UnityEvent onEnterEvent, onStayEvent, onExitEvent;
		}

		[Space(10)] public EventFields events;

		private Collider2D _collidedObject;

		protected void CheckForTrigger()
		{
			var colliders = GetComponents<Collider2D>();
			Assert.IsNotNull(colliders, "No Collider2D found.");

			foreach (var item in colliders)
			{
				if (item.isTrigger)
				{
					return;
				}
			}

			Debug.LogError("No Trigger found");
		}

		public void OnEnter()
		{
			OnEvent(events.onEnterEvent);
		}

		public void OnStay()
		{
			OnEvent(events.onStayEvent);
		}

		public void OnExit()
		{
			OnEvent(events.onExitEvent);
		}

		private static void OnEvent([NotNull] UnityEvent unityEvent)
		{
			unityEvent.Invoke();
		}

		protected bool CheckColision(Collider2D other)
		{
			if (!enabled)
			{
				return false;
			}

			if (!layers.Contains(other.gameObject))
			{
				return false;
			}

			_collidedObject = other;
			return true;
		}

		/// <summary>
		/// Gets the Collider2D from the last trigger.
		/// </summary>
		/// <returns>Collider2D</returns>
		public Collider2D GetCollider() => _collidedObject;
	}
}