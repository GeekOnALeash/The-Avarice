using com.ArkAngelApps.MyDebug.Exceptions;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Objects.Weapons
{
	public enum WeaponSlot
	{
		Primary,
		Secondary
	}


	public enum WeaponType
	{
		Contact,
		Ranged,
		Explosive,
		Trap
	}

	[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/In-Game/Weapon", order = 6)]
	public sealed class WeaponData : ScriptableObject
	{
		public string weaponName;
		public string weaponDescription;
		public Sprite weaponSprite;

		[SerializeField] private WeaponType weaponType;

		// ReSharper disable once ConvertToAutoProperty
		internal WeaponType WeaponType => weaponType;

		[SerializeField] private Armament[] primarySlot;

		// ReSharper disable once ConvertToAutoProperty
		internal Armament[] PrimarySlot => primarySlot;

		[SerializeField] private Armament[] secondarySlot;

		// ReSharper disable once ConvertToAutoProperty
		internal Armament[] SecondarySlot => secondarySlot;
	}
}
