using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Behaviours;
using com.ArkAngelApps.TheAvarice.Scriptable.Objects.Weapons;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Items
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(DamageDealer))]
	public sealed class Weapon : MonoBehaviour
	{
		[SerializeField]
		private WeaponData weaponData;

		[SerializeField] private WeaponSlot activeSlot;

		private Armament[] _primarySlot;
		private Armament[] _secondarySlot;

		private DamageDealer _damageDealer;

		private void Start()
		{
			if (!weaponData)
			{
				return;
			}

			_primarySlot = weaponData.PrimarySlot;
			_secondarySlot = weaponData.SecondarySlot;

			_damageDealer = GetComponent<DamageDealer>();
			Assert.IsNotNull(_damageDealer, "_damageDealer is null");
		}

		// ReSharper disable once ReturnTypeCanBeEnumerable.Local
		private Armament[] GetActiveSlotArmament() => activeSlot == WeaponSlot.Primary ? _primarySlot : _secondarySlot;

		internal void FireActiveSlot(Vector2 position)
		{
			foreach (var armament in GetActiveSlotArmament())
			{
				switch (armament.areaOfEffect)
				{
					case AreaOfEffect.Area:
						Debug.Log("No Area method in switch");
						break;
					case AreaOfEffect.SingleTarget:
						_damageDealer.SingleTarget(armament.damageAmount);
						break;
					case AreaOfEffect.SingleTargetOverTime:
						StartCoroutine(_damageDealer.SingleTargetOverTime(armament.duration, armament.damageAmount));
						break;
					case AreaOfEffect.AreaOverTime:
						Debug.Log("No AreaOverTime method in switch");
						break;
					default:
						// ReSharper disable once HeapView.ObjectAllocation.Evident
						// ReSharper disable once HeapView.BoxingAllocation
						// Disabled ReSharper inspections as this branch is never intended to be reached
						throw new UnexpectedEnumValueException(armament.areaOfEffect);
				}

				armament.FireParticlesAtPosition(position);
			}
		}
	}
}
