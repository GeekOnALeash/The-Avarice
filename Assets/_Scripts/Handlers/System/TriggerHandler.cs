using com.ArkAngelApps.TheAvarice.Behaviours;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public sealed class TriggerHandler : ColliderHelper
	{
		[Tooltip("This will only trigger when a collider interacts with the trigger.")]
		public bool ignoreTrigger;

		private void Awake()
		{
			CheckForTrigger();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (ignoreTrigger && other.isTrigger)
			{
				return;
			}
			
			if (CheckColision(other))
			{
				OnEnter();
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (ignoreTrigger && other.isTrigger)
			{
				return;
			}
			
			if (CheckColision(other))
			{
				OnStay();
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (ignoreTrigger && other.isTrigger)
			{
				return;
			}
			
			if (CheckColision(other))
			{
				OnExit();
			}
		}
	}
}