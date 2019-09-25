using System.Collections;
using com.ArkAngelApps.TheAvarice.Handlers.Character;
using com.ArkAngelApps.TheAvarice.Handlers.Items;
using JetBrains.Annotations;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Behaviours
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Weapon))]
	public sealed class DamageDealer : ColliderHelper
	{
		public ColliderType colliderType;

		private Health _targetHealth;
		private Weapon _weapon;

		private void Awake()
		{
			if (colliderType == ColliderType.Trigger || colliderType == ColliderType.Both)
			{
				CheckForTrigger();
			}
		}

		private void Start()
		{
			_weapon = GetComponent<Weapon>();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (colliderType != ColliderType.Trigger || colliderType != ColliderType.Both)
			{
				return;
			}

			if (!CheckColision(other.GetComponent<Collider2D>()))
			{
				return;
			}

			_targetHealth = other.gameObject.GetComponent<Health>();

			if (!_targetHealth)
			{
				return;
			}

			if (Physics.Raycast(transform.position, transform.forward, out var hit))
			{
				_weapon.FireActiveSlot(hit.point);
				return;
			}

			// This generally should not be called, but is here as a failsafe for the raycast.
			_weapon.FireActiveSlot(other.transform.position);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (colliderType != ColliderType.Collision)
			{
				return;
			}

			if (!CheckColision(other.collider))
			{
				return;
			}

			_targetHealth = other.gameObject.GetComponent<Health>();

			if (!_targetHealth)
			{
				return;
			}

			Vector3 contact = other.contacts[0].point;

			_weapon.FireActiveSlot(contact);
		}

		internal void SingleTarget(int amount)
		{
			_targetHealth.HealthHelper.TakeDamage(amount);
		}

		internal IEnumerator SingleTargetOverTime(int duration, int totalDamage)
		{
			int amount = totalDamage / duration;

			int totalDamageDealt = 0;

			while (totalDamageDealt < totalDamage)
			{
				_targetHealth.HealthHelper.TakeDamage(amount);
				totalDamageDealt += amount;
				yield return new WaitForSeconds(duration);
			}
		}
	}
}
