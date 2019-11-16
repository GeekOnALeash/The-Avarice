using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Items
{
	[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable/Items/Item Rarity Colors", order = 5)]
	public class ItemRarityColorData : ScriptableObject
	{
		public Color crafted;
		public Color common;
		public Color uncommon;
		public Color rare;
		public Color unique;
		public Color epic;
	}
}