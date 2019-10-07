using com.ArkAngelApps.TheAvarice.Abstracts;
using com.ArkAngelApps.TheAvarice.Controllers;
using com.ArkAngelApps.TheAvarice.Scriptable.Items;
using com.ArkAngelApps.TheAvarice.Scriptable.UI;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.ArkAngelApps.TheAvarice.Handlers.Items
{
	[DisallowMultipleComponent]
	public sealed class ItemContainerHandler : CachedTransformBase
	{
		public ItemContainer itemContainer;
		public ItemContainerRuntimeSet itemContainers;

		[Header("Context Messages")]
		[SerializeField]
		private ContextMessageData pickupContextMessage;

		[SerializeField] private ContextMessageData fullContextMessage;

		private void Start()
		{
			itemContainers.Add(this);
			Assert.IsNotNull(itemContainers, "itemContainer is null");
		}

		[UsedImplicitly]
		public void AddItem([NotNull] ItemHandler itemHandler)
		{
			ContextMessageData messageData;
			ItemData item = itemHandler.data;

			var atCapacity = AtMaxCapacity();

			if (atCapacity)
			{
				messageData = fullContextMessage;
			} else
			{
				messageData = pickupContextMessage;

				messageData.SetMessage($"<color=#{item.GetRarityColorHex()}>{item.name}</color> picked up.");
			}

			Controller.UI.contextMessageUI.ShowMessage(messageData);

			if (atCapacity)
			{
				return;
			}

			if (item.itemType == ItemType.Key)
			{
				KeyCardHandler keyCardHandler = itemHandler.GetComponent<KeyCardHandler>();

				keyCardHandler.AddToKeyChain();
			} else
			{
				itemContainer.AddItem(item);
			}

			itemHandler.DestroySelf();
		}

		public void RemoveItem([NotNull] ItemData item)
		{
			itemContainer.RemoveItem(item);
		}

		private bool AtMaxCapacity() => itemContainer.GetListItemCount() >= itemContainer.GetContainterSize();
	}
}