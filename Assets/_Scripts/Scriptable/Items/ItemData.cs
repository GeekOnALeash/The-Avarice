using com.ArkAngelApps.MyDebug.Exceptions;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using com.ArkAngelApps.UtilityLibraries.Attributes;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Items
{
	public enum ItemType
	{
		Key,
		Food,
		Book,
		Currency,
		Weapon,
		Ammo,
		Clothing,
		FirstAid,
		Quest
	}

	public enum ItemRarity
	{
		Crafted,
		Common,
		Uncommon,
		Rare,
		Unique,
		Epic
	}

	[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable/Items/Item", order = 1)]
	public sealed class ItemData : ScriptableObject
	{
		[TextArea(10, 40)] public string description;
		public new string name;
		public Sprite image;
		public Sprite inventoryIcon;
		public ItemType itemType;
		public ItemRarity itemRarity = ItemRarity.Common;
		public ItemRarityColorData itemRarityColorData;
		public Color color = Color.white;
		[SerializeField] private bool canPickUp = true;

		[ShowWhen(nameof(canPickUp))]
		public bool useOnPickup;

		[ShowWhen(nameof(canPickUp))]
		public bool dropable = true;

		[ShowWhen(nameof(canPickUp))]
		public bool stackable;

		[ShowWhen(nameof(canPickUp))]
		public bool sellable = true;

		public bool usable;

		[ShowWhen(nameof(usable))]
		public bool destroyAfterUse;

		[ShowWhen(nameof(destroyAfterUse))]
		public float destroyAfterUseDelay = 0.1f;

		[ShowWhen(nameof(canPickUp))]
		public int maximumCapacity;

		[ShowWhen(nameof(canPickUp))]
		public int value;

		[ShowWhen(nameof(canPickUp))]
		public int weight;

		internal bool objectChanged;

		public bool CheckItemID(int id) => id == GetInstanceID();

		public int GetItemID() => GetInstanceID();

		[Header("Required Skill Levels")]
		public bool requiredToPickup;

		[ShowWhen(nameof(requiredToPickup))] public SkillTypes requiredPickupSkillType;
		[ShowWhen(nameof(requiredToPickup))] public int requiredPickupSkillLevel;

		public bool requiredToUse;
		[ShowWhen(nameof(requiredToUse))] public SkillTypes requiredUseSkillType;
		[ShowWhen(nameof(requiredToUse))] public int requiredUseSkillLevel;

		internal bool CanPickup()
		{
			if (requiredToPickup)
			{
				return PlayerRuntimeData.Instance.character.experience.GetSkillValue(requiredPickupSkillType) >= requiredPickupSkillLevel;
			}

			return true;
		}

		internal string GetRarityColorHex() => ColorUtility.ToHtmlStringRGBA(GetRarityColor());

		private Color GetRarityColor()
		{
			switch (itemRarity)
			{
				case ItemRarity.Common:
					return itemRarityColorData.common;
				case ItemRarity.Crafted:
					return itemRarityColorData.crafted;
				case ItemRarity.Uncommon:
					return itemRarityColorData.uncommon;
				case ItemRarity.Rare:
					return itemRarityColorData.rare;
				case ItemRarity.Unique:
					return itemRarityColorData.unique;
				case ItemRarity.Epic:
					return itemRarityColorData.epic;
				default:
					// ReSharper disable once HeapView.ObjectAllocation.Evident
					// ReSharper disable once HeapView.BoxingAllocation
					// Disabled ReSharper inspections as this branch is never intended to be reached
					throw new UnexpectedEnumValueException(itemRarity);
			}
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			objectChanged = true;

			// ReSharper disable once InvertIf
			if (useOnPickup)
			{
				canPickUp = true;
				usable = true;
			}
		}
#endif
	}
}