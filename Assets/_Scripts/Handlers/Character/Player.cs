using com.ArkAngelApps.TheAvarice.Handlers.Items;
using com.ArkAngelApps.TheAvarice.Scriptable.Characters;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Character
{
	public sealed class Player : CharacterHandler
	{
		public ItemContainerHandler itemContainer;

		public override void Awake()
		{
			base.Awake();

			PlayerRuntimeData.Instance.character = this;
		}

		private void OnEnable()
		{
			Assert.IsNotNull(itemContainer, $"{itemContainer} itemContainer is null");
		}
	}
}