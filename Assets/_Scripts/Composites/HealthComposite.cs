using System;
using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Composites
{
	[Serializable]
	public sealed class HealthComposite : IComposite
	{
		[SerializeField] private IntVariable_Health healthData;

		public HealthComposite(IntVariable_Health healthData) => this.healthData = healthData;

		public IntVariable_Health HealthData
		{
			get => healthData;
			set => healthData = value;
		}

		public bool IsDead
		{
			get => _isDead;
			set => _isDead = value;
		}

		[Serializable]
		// ReSharper disable once InconsistentNaming
		public struct HealthEvents
		{
			public GameEvent healthIncreased;
			public GameEvent takesDamage;
			public GameEvent die;
			public GameEvent healthLow;
		}

		[SerializeField] public HealthEvents events;

		/// <summary>
		/// True if the character is dead
		/// </summary>
		private bool _isDead;

		public void SetHealth(int amount)
		{
			if (amount > healthData.MaxValue)
			{
				amount = healthData.MaxValue;
			} else if (amount < 0)
			{
				amount = 0;
			}

			healthData.SetValue(amount);
		}

		public int GetHealth() => healthData.Value;

		private void ReduceHealth(int amount)
		{
			healthData.ApplyChange(-amount);
		}

		public void IncreaseHealth(int amount)
		{
			healthData.ApplyChange(amount);
		}

		public void TakeDamage(int amount)
		{
			// Reduce the current health by the damage amount.
			ReduceHealth(amount);

			// If the player has lost all it's health and the death flag hasn't been set yet...
			if (healthData.Value <= 0)
			{
				if (!_isDead)
				{
					Death();
				}
			} else
			{
				events.takesDamage.Raise();
			}
		}

		private void Death()
		{
			// Set the death flag so this function won't be called again.
			_isDead = true;

			events.die.Raise();
		}
	}
}
