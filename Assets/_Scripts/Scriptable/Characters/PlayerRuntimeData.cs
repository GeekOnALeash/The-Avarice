using com.ArkAngelApps.TheAvarice.Handlers.Character;
using com.ArkAngelApps.TheAvarice.Scriptable.Items;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Scriptable.Characters
{
	[CreateAssetMenu(fileName = "_PlayerRuntimeData", menuName = "Scriptable/Character/PlayerRuntimeData", order = 2)]
	public sealed class PlayerRuntimeData : SingletonScriptableObject<PlayerRuntimeData>
	{
		public Player character;

		public IntVariable_Health health;
		public ItemContainer itemContainer;

		private const int MaxTraits = 5;
	}
}